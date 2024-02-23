using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlyleafLib.MediaPlayer;
using OpenpilotSdk.Hardware;
using OpenpilotSdk.OpenPilot;
using OpenpilotToolkit.Stream;

namespace OpenpilotToolkit.Controls.Media
{
    public partial class FlyleafVideoPlayer : UserControl
    {
        private CombinedStream _currentStream;
        private int _currentSegment;

        public FlyleafVideoPlayer()
        {
            InitializeComponent();
        }

        public void Initialize(Player player)
        {
            flyleafHost1.Player = player;
            flyleafHost1.Player.PropertyChanged += Player_PropertyChanged;
        }

        private void Player_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (_currentStream != null)
            {
                if (e.PropertyName == "CurTime")
                {
                    timeScale.Value = (int)(((float)_currentStream.Position / (float)_currentStream.Length) *
                                            (float)timeScale.RangeMax);
                }
            }
        }

        private async void NextSegmentAsync()
        {
            if (await _currentStream.SeekToNextStreamAsync().ConfigureAwait(false))
            {
                flyleafHost1.Player.Flush();
            }
        }

        private async Task<OpenCompletedArgs> PlayStreamAsync(CombinedStream stream)
        {
            var tcs = new TaskCompletionSource<OpenCompletedArgs>();
            EventHandler<OpenCompletedArgs> handler = null;
            handler = (sender, args) =>
            {
                if (!args.Success)
                {
                    if (args.Error == "Cancelled")
                    {
                        _isOpening = false;
                    }

                    return;
                }
                Debug.Print("Stream Opened");
                flyleafHost1.Player.OpenCompleted -= handler;
                _isOpening = false;
                tcs.SetResult(args);
            };
            flyleafHost1.Player.OpenCompleted += handler;

            Debug.Print("Opening New Stream");
            flyleafHost1.Player.OpenAsync(stream);
            var result = await tcs.Task.ConfigureAwait(false);
            return result;
        }

        private async void PreviousSegmentAsync()
        {
            if (flyleafHost1.Player.Status == Status.Ended)
            {
                await PlayStreamAsync(_currentStream).ConfigureAwait(false);
                if (_currentStream.Streams.Count - 2 >= 0)
                {
                    await _currentStream.SeekToStreamAsync(_currentStream.Streams.Count - 2).ConfigureAwait(false);
                }
                flyleafHost1.Player.Flush();
            }
            else
            {
                if (await _currentStream.SeekToPreviousStreamAsync().ConfigureAwait(false))
                {
                    flyleafHost1.Player.Flush();
                }
            }
        }

        private bool _isOpening = false;
        private CombinedStreamCollection _combinedStreamCollection;
        private SemaphoreSlim _streamLock = new SemaphoreSlim(1, 1);

        public async Task ChangeCurrentStreamAsync(OpenpilotDevice openpilotDevice, Drive drive, CancellationToken cancellationToken)
        {
            try
            {
                await _streamLock.WaitAsync(cancellationToken);
            }
            catch (OperationCanceledException)
            {
                return;
            }
            
            try
            {
                await DisposeStreamAsync(_combinedStreamCollection);
                _isOpening = true;

                var combinedStreamCollection = new CombinedStreamCollection(openpilotDevice, drive);
                _combinedStreamCollection = combinedStreamCollection;

                materialComboBox1.Items.Clear();
                foreach (var cameraStreamsKey in combinedStreamCollection.CameraStreams.Keys)
                {
                    materialComboBox1.Items.Add(cameraStreamsKey);
                }
                materialComboBox1.SelectedValueChanged -= materialComboBox1_SelectedValueChanged;
                materialComboBox1.SelectedIndex = 0;
                materialComboBox1.SelectedValueChanged += materialComboBox1_SelectedValueChanged;

                var firstStream = combinedStreamCollection.CameraStreams.First();

                await ChangeCurrentStreamAsync(await firstStream.Value).ConfigureAwait(false);
            }
            finally
            {
                _streamLock.Release();
            }
        }


        private async Task ChangeCurrentStreamAsync(CombinedStream fs)
        {
            _isOpening = true;
            fs.CurrentStreamIndexChanged += CombinedStreamOnCurrentStreamIndexChanged;

            _currentStream = fs;
            _currentSegment = 0;
            timeScale.Value = 0;
            this.BeginInvoke(() => { lblSegment.Text = _currentSegment.ToString(); });

            await PlayStreamAsync(fs).ConfigureAwait(false);
        }

        private void CombinedStreamOnCurrentStreamIndexChanged(int obj)
        {
            _currentSegment = obj;
            this.BeginInvoke(() => { lblSegment.Text = _currentSegment.ToString(); });
        }

        private void btnNextSegment_Click(object sender, EventArgs e)
        {
            NextSegmentAsync();
        }

        private void btnPreviousSegment_Click(object sender, EventArgs e)
        {
            PreviousSegmentAsync();
        }

        private async void timeScale_onValueChanged(object sender, int newValue)
        {
            if (_currentStream != null)
            {
                var originalPosition = _currentStream.Position;

                if (flyleafHost1.Player.Status == Status.Ended)
                {
                    await PlayStreamAsync(_currentStream).ConfigureAwait(false);
                }

                var newPosition = (long)(((float)newValue / (float)timeScale.RangeMax) * (float)_currentStream.Length);
                if (originalPosition != newPosition)
                {
                    _currentStream.Position = newPosition;
                    flyleafHost1.Player.Flush();
                }
            }
        }

        private void flyleafHost1_Click(object sender, EventArgs e)
        {
            flyleafHost1.Player.TogglePlayPause();
        }

        private async Task DisposeStreamAsync(CombinedStreamCollection streamToDispose)
        {
            Debug.Print("Request Stop");
            var tcs = new TaskCompletionSource<PlaybackStoppedArgs>();
            EventHandler<PlaybackStoppedArgs> handler = null;
            handler = (sender, args) =>
            {
                if (!args.Success)
                {
                    return;
                }
                Debug.Print("Playing stopped");
                flyleafHost1.Player.PlaybackStopped -= handler;
                tcs.SetResult(args);
            };
            flyleafHost1.Player.PlaybackStopped += handler;
            
            if (flyleafHost1.Player.IsPlaying || _isOpening)
            {
                flyleafHost1.Player.Stop();
                try
                {
                    await tcs.Task.WaitAsync(TimeSpan.FromSeconds(5)).ConfigureAwait(false);
                }
                catch (TimeoutException)
                {
                    flyleafHost1.Player.PlaybackStopped -= handler;
                    Debug.Print("Timed out waiting for player to stop");
                }
            }
            else
            {
                flyleafHost1.Player.PlaybackStopped -= handler;
            }

            if (streamToDispose != null)
            {
                await streamToDispose.DisposeAsync().ConfigureAwait(false);
            }
            
        }

        private void materialComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void materialComboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            var cameraType = (CameraType)materialComboBox1.SelectedItem;
            if (_combinedStreamCollection.CameraStreams.ContainsKey(cameraType))
            {
                await ChangeCurrentStreamAsync(await _combinedStreamCollection.CameraStreams[cameraType]).ConfigureAwait(false);
            }
        }
    }
}
