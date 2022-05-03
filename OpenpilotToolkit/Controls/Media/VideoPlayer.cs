using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibVLCSharp.Shared;
using LibVLCSharp.WinForms;
using Renci.SshNet.Sftp;


namespace OpenpilotToolkit.Controls.Media
{
    public partial class VideoPlayer : UserControl
    {
        private LibVLC _libVlc;
        private SftpFileStream _currentStream;
        
        private int _currentSegment = 0;
        private MediaList _mediaList;

        private int _currentPlayer = 1;

        public VideoPlayer()
        {
            InitializeComponent();
        }

        public void Initialize(LibVLC libVlc)
        {
            _libVlc = libVlc;
            vlcVideoView1.MediaPlayer = new MediaPlayer(libVlc);
            vlcVideoView2.MediaPlayer = new MediaPlayer(libVlc);
            if (vlcVideoView1.MediaPlayer != null)
            {
                vlcVideoView1.MediaPlayer.PositionChanged += MediaPlayerOnPositionChanged;
                vlcVideoView1.MediaPlayer.Playing += MediaPlayerOnPlaying;
                vlcVideoView1.MediaPlayer.EndReached += MediaPlayerOnEndReached;
            }

            if (vlcVideoView2.MediaPlayer != null)
            {
                vlcVideoView2.MediaPlayer.PositionChanged += MediaPlayerOnPositionChanged2;
                vlcVideoView2.MediaPlayer.Playing += MediaPlayerOnPlaying2;
                vlcVideoView2.MediaPlayer.EndReached += MediaPlayerOnEndReached2;
            }

            vlcVideoView1.MediaPlayer.EnableMouseInput = false;
            vlcVideoView2.MediaPlayer.EnableMouseInput = false;
        }

        private void MediaPlayerOnEndReached2(object sender, EventArgs e)
        {
            NextSegment();
        }

        private void MediaPlayerOnEndReached(object sender, EventArgs e)
        {
            NextSegment();
        }

        private void NextSegment()
        {
            VideoView videoView = _currentPlayer == 1 ? vlcVideoView2 : vlcVideoView1;

            if (_currentSegment+1 < _mediaList.Count)
            {
                _currentSegment++;

                this.BeginInvoke(() =>
                {
                    videoView.BringToFront();
                    videoView.MediaPlayer.SetPause(false);
                    lblSegment.Text = _currentSegment.ToString();
                });

                
                _currentPlayer = _currentPlayer == 1 ? 2 : 1;

                BufferSegment(_currentSegment+1);
            }
        }

        private void PreviousSegment()
        {
            VideoView videoView = _currentPlayer == 1 ? vlcVideoView2 : vlcVideoView1;

            if (_currentSegment - 1 >= 0)
            {
                _currentSegment--;
                this.BeginInvoke(() =>
                {
                    lblSegment.Text = _currentSegment.ToString();
                    videoView.MediaPlayer.Play(_mediaList[_currentSegment]);
                    videoView.BringToFront();
                });
                
                _currentPlayer = _currentPlayer == 1 ? 2 : 1;

                BufferSegment(_currentSegment+1);
            }
        }

        private void BufferSegment(int segment)
        {
            VideoView videoView = _currentPlayer == 1 ? vlcVideoView2 : vlcVideoView1;

            if (segment < _mediaList.Count)
            {
                this.BeginInvoke(() =>
                {
                    videoView.MediaPlayer.Play(_mediaList[segment]);
                });
            }
        }

        private void MediaPlayerOnPlaying2(object sender, EventArgs e)
        {
            vlcVideoView2.MediaPlayer.EnableKeyInput = false;
            vlcVideoView2.MediaPlayer.EnableMouseInput = false;
        }

        private void MediaPlayerOnPlaying(object sender, EventArgs e)
        {
            vlcVideoView1.MediaPlayer.EnableKeyInput = false;
            vlcVideoView1.MediaPlayer.EnableMouseInput = false;
        }

        public void Play(SftpFileStream fs)
        {
            _currentStream = fs;
            using (var media = new LibVLCSharp.Shared.Media(_libVlc, new StreamMediaInput(_currentStream)))
            {
                vlcVideoView1.MediaPlayer.Play(media);
            }
        }

        public void Play(List<SftpFileStream> fs)
        {
            _currentSegment = 0;
            _currentPlayer = 1;


            this.BeginInvoke(() => { lblSegment.Text = _currentSegment.ToString(); });

            _mediaList = new MediaList(_libVlc);
            foreach (var sftpFileStream in fs)
            {
                var media = new LibVLCSharp.Shared.Media(_libVlc, new StreamMediaInput(sftpFileStream));
                _mediaList.AddMedia(media);
            }
            
            this.BeginInvoke(() => { vlcVideoView1.BringToFront(); });
            vlcVideoView1.MediaPlayer.Play(_mediaList[0]);

            BufferSegment(1);
        }

        

        private void MediaPlayerOnPositionChanged2(object sender, MediaPlayerPositionChangedEventArgs e)
        {
            if (_currentPlayer == 1)
            {
                vlcVideoView2.MediaPlayer.SetPause(true);
                vlcVideoView2.MediaPlayer.Position = 0;
            }
            else
            {
                timeScale.Value = (int)(vlcVideoView2.MediaPlayer.Position * timeScale.RangeMax);
            }
        }


        private void MediaPlayerOnPositionChanged(object sender, MediaPlayerPositionChangedEventArgs e)
        {
            if (_currentPlayer == 2)
            {
                
                vlcVideoView1.MediaPlayer.SetPause(true);
                vlcVideoView1.MediaPlayer.Position = 0;
            }
            else
            {
                timeScale.Value = (int)(vlcVideoView1.MediaPlayer.Position * timeScale.RangeMax);
            }
        }

        private void timeScale_onValueChanged(object sender, int newValue)
        {
            if (_currentPlayer == 1)
            {
                if (!vlcVideoView1.MediaPlayer.WillPlay)
                {
                    vlcVideoView1.MediaPlayer.Play(_mediaList[_currentSegment]);
                }

                vlcVideoView1.MediaPlayer.Position = ((float)newValue / timeScale.RangeMax);
            }
            else
            {
                if (!vlcVideoView2.MediaPlayer.WillPlay)
                {
                    vlcVideoView2.MediaPlayer.Play(_mediaList[_currentSegment]);
                }

                vlcVideoView2.MediaPlayer.Position = ((float)newValue / timeScale.RangeMax);
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void vlcVideoView_Click(object sender, EventArgs e)
        {
            if (_currentPlayer == 2)
            {
                vlcVideoView2.MediaPlayer.Pause();
            }
            else
            {
                vlcVideoView1.MediaPlayer.Pause();
            }
            
        }

        private void btnNextSegment_Click(object sender, EventArgs e)
        {
            Task.Run(() => { NextSegment(); });
            
        }

        private void btnPreviousSegment_Click(object sender, EventArgs e)
        {
            Task.Run(() => { PreviousSegment(); });
            
        }
    }
}
