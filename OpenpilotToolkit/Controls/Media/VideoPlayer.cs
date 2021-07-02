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
using Renci.SshNet.Sftp;


namespace OpenpilotToolkit.Controls.Media
{
    public partial class VideoPlayer : UserControl
    {
        private LibVLC _libVlc;
        private SftpFileStream _currentStream;

        public VideoPlayer()
        {
            InitializeComponent();
        }

        public void Initialize(LibVLC libVlc)
        {
            _libVlc = libVlc;
            vlcVideoView.MediaPlayer = new MediaPlayer(libVlc);
            if (vlcVideoView.MediaPlayer != null)
            {
                vlcVideoView.MediaPlayer.TimeChanged += MediaPlayerOnTimeChanged;
                vlcVideoView.MediaPlayer.PositionChanged += MediaPlayerOnPositionChanged;
                vlcVideoView.MediaPlayer.Playing += MediaPlayerOnPlaying;
            }

            vlcVideoView.MediaPlayer.EnableMouseInput = false;
        }

        private void MediaPlayerOnPlaying(object sender, EventArgs e)
        {
            vlcVideoView.MediaPlayer.EnableKeyInput = false;
            vlcVideoView.MediaPlayer.EnableMouseInput = false;

        }

        public void Play(SftpFileStream fs)
        {
            _currentStream = fs;
            using (var media = new LibVLCSharp.Shared.Media(_libVlc, new StreamMediaInput(_currentStream)))
            {
                vlcVideoView.MediaPlayer.Play(media);
            }
        }

        private void MediaPlayerOnPositionChanged(object sender, MediaPlayerPositionChangedEventArgs e)
        {
            timeScale.Value = (int)(vlcVideoView.MediaPlayer.Position * timeScale.RangeMax);
        }


        private void MediaPlayerOnTimeChanged(object sender, MediaPlayerTimeChangedEventArgs e)
        {
            //timeScale.Value = (int)(vlcVideoView.MediaPlayer.Position * timeScale.RangeMax);
        }

        private void timeScale_onValueChanged(object sender, int newValue)
        {
            if (!vlcVideoView.MediaPlayer.WillPlay)
            {
                using (var media = new LibVLCSharp.Shared.Media(_libVlc, new StreamMediaInput(_currentStream)))
                {
                    vlcVideoView.MediaPlayer.Play(media);
                }
            }
            vlcVideoView.MediaPlayer.Position = ((float)newValue / timeScale.RangeMax);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void vlcVideoView_Click(object sender, EventArgs e)
        {
            
            vlcVideoView.MediaPlayer.Pause();
        }



    }
}
