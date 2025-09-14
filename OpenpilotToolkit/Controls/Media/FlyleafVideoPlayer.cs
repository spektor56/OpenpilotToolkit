using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlyleafLib.MediaPlayer;
using OpenpilotSdk.Hardware;
using OpenpilotSdk.OpenPilot;
using OpenpilotSdk.OpenPilot.Media;

namespace OpenpilotToolkit.Controls.Media;

public partial class FlyleafVideoPlayer : UserControl
{
    private CombinedStreamCollection _combinedStreamCollection;
    private int _currentSegment;
    private CombinedStream _currentStream;

    private bool _isOpening;
    private readonly SemaphoreSlim _streamLock = new(1, 1);

    public FlyleafVideoPlayer()
    {
        InitializeComponent();
    }

    public void Initialize(Player player)
    {
        flyleafHost1.Player = player;
        flyleafHost1.Player.PropertyChanged += Player_PropertyChanged;
    }

    public void Stop()
    {
        flyleafHost1.Player.Stop();
    }

    public void Pause()
    {
        flyleafHost1.Player.Pause();
    }

    public void Play()
    {
        flyleafHost1.Player.Play();
    }

    private void Player_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (_currentStream != null)
        {
            if (e.PropertyName == "CurTime")
            {
                timeScale.Value = (int)(_currentStream.Position / (float)_currentStream.Length *
                                        timeScale.RangeMax);
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

    private async Task<OpenCompletedArgs> OpenStreamAsync(CombinedStream stream)
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
            
            Serilog.Log.Debug("Stream Opened");
            _currentStream = stream;
            flyleafHost1.Player.OpenCompleted -= handler;
            _isOpening = false;

            tcs.SetResult(args);
        };
        
        flyleafHost1.Player.OpenCompleted += handler;

        Serilog.Log.Debug("Opening New Stream");
        flyleafHost1.Player.OpenAsync(stream, true, true, false, false);

        var result = await tcs.Task.ConfigureAwait(false);


        return result;
    }

    private bool _seekToKeyframes = true;

    public async Task SetSeekToKeyframesAsync(bool seekToKeyframes)
    {
        _seekToKeyframes = seekToKeyframes;
        if (_combinedStreamCollection != null)
        {
            await _combinedStreamCollection.SetSeekToKeyframesAsync(seekToKeyframes).ConfigureAwait(false);
        }
    }

    private async void PreviousSegmentAsync()
    {
        if (flyleafHost1.Player.Status == Status.Ended)
        {
            await OpenStreamAsync(_currentStream).ConfigureAwait(false);
            if (_currentStream.Streams.Length - 2 >= 0)
            {
                await _currentStream.SeekToStreamAsync(_currentStream.Streams.Length - 2).ConfigureAwait(false);
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

    public async Task PlayRouteAsync(OpenpilotDevice openpilotDevice, Route route,
        CancellationToken cancellationToken)
    {
        try
        {
            await _streamLock.WaitAsync(cancellationToken).ConfigureAwait(false);
        }
        catch (OperationCanceledException)
        {
            return;
        }

        try
        {
            timeScale.Value = 0;
            _currentSegment = 0;
            BeginInvoke(() => { lblSegment.Text = _currentSegment.ToString(); });

            await DisposeStreamAsync(_combinedStreamCollection).ConfigureAwait(false);
            _isOpening = true;

            var combinedStreamCollection = await openpilotDevice.GetVideoStreams(route);
            _combinedStreamCollection = combinedStreamCollection;

            cmbStreamType.Invoke((MethodInvoker)(() =>
            {
                cmbStreamType.Items.Clear();
                foreach (var cameraStreamsKey in combinedStreamCollection.CameraStreams.Keys)
                {
                    cmbStreamType.Items.Add(cameraStreamsKey);
                }

                cmbStreamType.SelectedValueChanged -= cmbStreamType_SelectedValueChanged;
                cmbStreamType.SelectedIndex = 0;
                cmbStreamType.SelectedValueChanged += cmbStreamType_SelectedValueChanged;
            }));

            var firstStream = await combinedStreamCollection.CameraStreams.First().Value;
            firstStream.CurrentStreamIndexChanged += CombinedStreamOnCurrentStreamIndexChanged;
            //var duration = await firstStream.GetDurationAsync();
            await OpenStreamAsync(firstStream).ConfigureAwait(false);
            
            

            Serilog.Log.Debug("Calling Play");
            flyleafHost1.Player.Play();
        }
        finally
        {
            _streamLock.Release();
        }
    }


    private async Task ChangeCurrentStreamAsync(CombinedStream stream)
    {
        _isOpening = true;
        decimal originalPosition = 0;
        if (_currentStream != null)
        {
            originalPosition = (decimal)_currentStream.Position / _currentStream.Length;
        }

        var newPosition = (long)(stream.Length * originalPosition);

        await OpenStreamAsync(stream).ConfigureAwait(false);

        flyleafHost1.Player.Play();
        stream.Position = newPosition;
        flyleafHost1.Player.Pause();
        flyleafHost1.Player.Flush();
        flyleafHost1.Player.Play();
    }

    private void CombinedStreamOnCurrentStreamIndexChanged(int obj)
    {
        _currentSegment = obj;
        BeginInvoke(() => { lblSegment.Text = _currentSegment.ToString(); });
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
                await OpenStreamAsync(_currentStream).ConfigureAwait(false);
            }

            var newPosition = (long)(newValue / (float)timeScale.RangeMax * _currentStream.Length);
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
        Serilog.Log.Debug("Request Stop");
        var tcs = new TaskCompletionSource<PlaybackStoppedArgs>();
        EventHandler<PlaybackStoppedArgs> handler = null;
        handler = (sender, args) =>
        {
            if (!args.Success)
            {
                return;
            }
            Serilog.Log.Debug("Playing stopped");
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
                Serilog.Log.Debug("Timed out waiting for player to stop");
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

    private async void cmbStreamType_SelectedValueChanged(object sender, EventArgs e)
    {
        var cameraType = (CameraType)cmbStreamType.SelectedItem;
        if (_combinedStreamCollection.CameraStreams.ContainsKey(cameraType))
        {
            var streamInitialized = _combinedStreamCollection.CameraStreams[cameraType].IsStarted;
            var stream = await _combinedStreamCollection.CameraStreams[cameraType];

            if (stream == _currentStream)
            {
                return;
            }

            if (!streamInitialized)
            {
                stream.CurrentStreamIndexChanged += CombinedStreamOnCurrentStreamIndexChanged;
            }
            await ChangeCurrentStreamAsync(await _combinedStreamCollection.CameraStreams[cameraType])
                .ConfigureAwait(false);
        }
    }
}