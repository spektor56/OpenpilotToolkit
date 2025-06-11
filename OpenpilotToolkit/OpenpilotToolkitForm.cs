using CefSharp;
using CefSharp.WinForms;
using FFMpegCore;
using FlyleafLib;
using FlyleafLib.MediaPlayer;
using MaterialSkin;
using MaterialSkin.Controls;
using NetTopologySuite.IO;
using Newtonsoft.Json;
using Octokit;
using OpenpilotSdk.Git;
using OpenpilotSdk.Hardware;
using OpenpilotSdk.OpenPilot;
using OpenpilotSdk.OpenPilot.Fork;
using OpenpilotToolkit.Android;
using OpenpilotToolkit.Controls;
using OpenpilotToolkit.Controls.Media;
using OpenpilotToolkit.Json;
using Renci.SshNet;
using Renci.SshNet.Common;
using SixLabors.ImageSharp;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using Exception = System.Exception;
using FileMode = System.IO.FileMode;
using MethodInvoker = System.Windows.Forms.MethodInvoker;
using OpenpilotDevice = OpenpilotSdk.Hardware.OpenpilotDevice;

namespace OpenpilotToolkit
{
    public partial class OpenpilotToolkitForm : MaterialForm
    {
        private ConcurrentDictionary<string, DateTime?> _watchedFiles = new ConcurrentDictionary<string, DateTime?>();
        private readonly string _tempExplorerFiles;
        private readonly ConcurrentDictionary<string, Task> _activeTaskList = new ConcurrentDictionary<string, Task>();
        private const string AdbConnectedMessage = "Device in fastboot mode connected";
        private const string AdbDisconnectedMessage = "Device in fastboot mode disconnected";
        private int _connectedFastbootDevices = 0;
        readonly BindingList<OpenpilotDevice> _devices = new BindingList<OpenpilotDevice>();
        private Stack<string> _workingDirectory = new Stack<string>();
        private ShellStream _shellStream = null;
        private StreamReader _streamReader = null;
        private readonly SemaphoreSlim _terminalLock = new SemaphoreSlim(1, 1);
        private ChromiumWebBrowser _sshTerminal;
        private Player _flyPlayer;

        public System.Drawing.Color ToColor(int argb)
        {
            return System.Drawing.Color.FromArgb(
                (argb & 0xFF0000) >> 16,
                (argb & 0x00FF00) >> 8,
                argb & 0x0000FF);
        }

        public OpenpilotToolkitForm(string tempFolder = null)
        {
            _tempExplorerFiles = tempFolder;

            InitializeComponent();
            AutoScaleMode = AutoScaleMode.None;

            tcSettings.Controls.Remove(tpFlash);
            tcSettings.Controls.Remove(tabPage1);

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = false;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Grey800, Primary.Grey900, Primary.LightBlue100, Accent.LightBlue400, TextShade.WHITE);

            themePanel.BackColor = materialSkinManager.ColorScheme.PrimaryColor;

            //tlpTasks.BackColor = MaterialSkinManager.Instance.BackgroundColor;
            lbRoutes.BackColor = MaterialSkinManager.Instance.BackgroundColor;
            lbRoutes.ForeColor = MaterialSkinManager.Instance.TextHighEmphasisColor;
        }

        private FileSystemWatcher _explorerFileWatcher = null;

        private async void Form1_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                string githubToken = "";
                try
                {
                    githubToken = Properties.Settings.Default.GithubToken;
                }
                catch (Exception)
                {
                    Debug.Print("Uri Exception");
                }

                if (!string.IsNullOrWhiteSpace(githubToken))
                {
                    _githubClient.Credentials =
                        new Credentials(githubToken, AuthenticationType.Oauth);
                }

                UpdateForkBranches("commaai", "openpilot").ConfigureAwait(false);
            }

            _osmClientId = Encoding.UTF8.GetString(Convert.FromBase64String(_osmClientId));
            _osmClientSecret = Encoding.UTF8.GetString(Convert.FromBase64String(_osmClientSecret));

            Directory.CreateDirectory(Path.Combine(AppContext.BaseDirectory, "tmp", "explorer"));

            _explorerFileWatcher = new FileSystemWatcher(_tempExplorerFiles)
            {
                NotifyFilter = NotifyFilters.LastWrite,
                IncludeSubdirectories = true,
                EnableRaisingEvents = true
            };

            /*RXTest
            IObservable<EventPattern<FileSystemEventArgs>> fswChanged = Observable.FromEventPattern<FileSystemEventArgs>(_explorerFileWatcher, "Changed");
            var subscription = fswChanged.Select(pattern => Observable.FromAsync(async () => await FileWatcherOnChanged(pattern.Sender,pattern.EventArgs))).Concat().Subscribe();
            */

            _explorerFileWatcher.Changed += FileWatcherOnChanged;

            tlpTasks.Padding = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth - 1, 0);
            tlpExplorerTasks.Padding = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth - 1, 0);

            var terminalPath = Path.Combine(AppContext.BaseDirectory, @"Controls\Terminal\index.html");
            _sshTerminal = new ChromiumWebBrowser(terminalPath)
            {
                BrowserSettings = new BrowserSettings
                {
                    Javascript = CefState.Enabled,
                    WebGl = CefState.Enabled,
                    ImageLoading = CefState.Disabled,
                    LocalStorage = CefState.Disabled,
                },
                RequestContext = new RequestContext(new RequestContextSettings
                {
                    CachePath = null,
                    PersistSessionCookies = false
                })
            };

            //Terminal messages from C# instead of webbrowser
            //sshTerminal.KeyboardHandler = new TerminalKeyboardHandler();
            //sshTerminal.PreviewKeyDown += txtSshCommand_PreviewKeyDown;
            //sshTerminal.KeyPress += txtSshCommand_KeyPress;
            //sshTerminal.KeyDown += txtSshCommand_KeyDown;

            _sshTerminal.JavascriptObjectRepository.Register("sshHost", this, BindingOptions.DefaultBinder);
            _sshTerminal.Dock = DockStyle.Fill;
            _sshTerminal.CreateControl();
            _sshTerminal.JavascriptMessageReceived += SshTerminal_JavascriptMessageReceived;

            tableLayoutPanel1.Controls.Add(_sshTerminal, 0, 0);

            // Initializes Engine (Specifies FFmpeg libraries path which is required)
            Engine.Start(new EngineConfig()
            {
#if DEBUG
                LogOutput = ":debug",
                LogLevel = LogLevel.Debug,
                FFmpegLogLevel = FFmpegLogLevel.Warning,
#endif

                UIRefresh = true, // For Activity Mode usage
                PluginsPath = ":Plugins",
                FFmpegPath = ":FFmpeg",
            });

            var config = new Config
            {
                Player =
                {
                    //MaxLatency = TimeSpan.FromMilliseconds(1).Ticks,
                    MinBufferDuration = 0,
                    AutoPlay = false

                },
                Audio =
                {
                    Enabled = false
                },
                Subtitles =
                {
                    Enabled = false
                },
                Demuxer =
                {
                    BufferDuration = TimeSpan.FromSeconds(1).Ticks,
                    AllowFindStreamInfo = false,
                    ForceFPS = 20,
                },
                Decoder =
                {
                    MaxVideoFrames = 2,
                    ShowCorrupted = true,
                    LowDelay = true
                }
            };
            _flyPlayer = new Player(config);
            _flyPlayer.PropertyChanged += (o, args) =>
            {
                if (args.PropertyName == "Status")
                {
                    if (tcSettings.SelectedTab != tpExport && flyleafVideoPlayer.flyleafHost1.Player.IsPlaying)
                    {
                        _videoPauseFromTabSwitch = true;
                        flyleafVideoPlayer.Pause();
                    }
                }
            };
            flyleafVideoPlayer.Initialize(_flyPlayer);

            var source = new AutoCompleteStringCollection
            {
                "spektor56",
                "sunnypilot",
                "commaai",
                "FrogAi"
            };
            txtForkUsername.AutoCompleteCustomSource = source;

            cbCombineSegments.Checked = Properties.Settings.Default.CombineSegments;
            cbSeekToKeyframes.Checked = Properties.Settings.Default.SeekToKeyframes;

            cbFrontCamera.Checked = Properties.Settings.Default.FrontCamera;
            cbWideCamera.Checked = Properties.Settings.Default.WideCamera;
            cbDriverCamera.Checked = Properties.Settings.Default.DriverCamera;

            _osmToken = Properties.Settings.Default.OsmToken;
            //txtOsmUsername.Text = Properties.Settings.Default.OsmUsername;
            //txtOsmPassword.Text = Properties.Settings.Default.OsmPassword;

            foreach (PropertyInfo property in MaterialSkinManager.Instance.GetType().GetProperties())
            {
                if (property.Name.EndsWith("Color"))
                {
                    var button = new Button();
                    button.Text = property.Name;
                    button.AutoSize = true;
                    button.UseVisualStyleBackColor = false;
                    var colour = (System.Drawing.Color)property.GetValue(MaterialSkinManager.Instance);
                    button.BackColor = colour;
                    flpColours.Controls.Add(button);
                }

                Console.WriteLine();
            }

            //flowLayoutPanel1.Parent = txtWorkingDirectory;
            //themePanel.Parent = this.UserArea;
            //actionbar bounds on paint events

            cmbDevices.DataSource = _devices;

            themePanel.Height = DrawerTabControl.Height;

            SetTheme(Properties.Settings.Default.DarkMode);
            txtExportFolder.Text = Properties.Settings.Default.ExportFolder;

            var devices = Fastboot.GetDevices();
            _connectedFastbootDevices = devices.Length;
            if (devices.Any())
            {
                var message = new MaterialSnackBar(AdbConnectedMessage, "OK", false);
                message.Show(this);
                adbConnected.SetEnabled(true);
            }
            else
            {
                adbConnected.SetEnabled(false);
            }

            var watcher = new ManagementEventWatcher();
            var query = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 2 OR EventType = 3 GROUP WITHIN 1");
            watcher.EventArrived += (o, args) =>
            {
                var devices = Fastboot.GetDevices();

                if (devices.Length > _connectedFastbootDevices)
                {
                    BeginInvoke(new MethodInvoker(() =>
                    {
                        adbConnected.SetEnabled(true);
                        var message = new MaterialSnackBar(AdbConnectedMessage, "OK", false);
                        message.Show(this);
                    }));

                }
                else if (devices.Length < _connectedFastbootDevices)
                {
                    BeginInvoke(new MethodInvoker(() =>
                    {
                        adbConnected.SetEnabled(false);
                        var message = new MaterialSnackBar(AdbDisconnectedMessage, "OK", false);
                        message.Show(this);
                    }));
                }

                _connectedFastbootDevices = devices.Length;
            };
            watcher.Query = query;
            watcher.Start();

            //flowLayoutPanel1.HorizontalScroll.Visible = false;

            await ScanDevices().ConfigureAwait(false);

            //Look for updates

            //TODO: implement self-updater
            //var test = await _githubClient.Repository.Release.GetLatest("spektor56", "openpilotToolkit");
        }

        private async void FileWatcherOnChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Changed && _watchedFiles.Count > 0)
            {
                object tmpOpenpilotDevice = null;
                cmbDevices.Invoke(() => tmpOpenpilotDevice = cmbDevices.SelectedItem);

                if (tmpOpenpilotDevice is OpenpilotDevice openpilotDevice)
                {

                    DateTime? modifiedDate = null;
                    if (_watchedFiles.TryGetValue(e.FullPath, out modifiedDate))
                    {
                        if (modifiedDate != null)
                        {
                            var lastWriteTimeUtc = File.GetLastWriteTimeUtc(e.FullPath);
                            if (!modifiedDate.Equals(lastWriteTimeUtc))
                            {
                                _watchedFiles[e.FullPath] = lastWriteTimeUtc;

                                await Task.Delay(200);

                                var currentWriteTimeUtc = File.GetLastWriteTimeUtc(e.FullPath);
                                if (lastWriteTimeUtc.Equals(currentWriteTimeUtc))
                                {

                                    var ucUploadProgress = new ucProgress("↑ " + Path.GetFileName(e.FullPath))
                                    {
                                        Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top)
                                    };

                                    BeginInvoke(new MethodInvoker(() =>
                                    {
                                        tlpExplorerTasks.Controls.Add(ucUploadProgress);
                                    }));


                                    Task.Run(async () =>
                                    {
                                        var destination = e.FullPath.Replace(Path.DirectorySeparatorChar, '/').Substring(_tempExplorerFiles.Length,
                                    e.FullPath.Length - _tempExplorerFiles.Length);

                                        await using (var sourceFile = File.OpenRead(e.FullPath))
                                        {
                                            await using (var destinationFile = await openpilotDevice.OpenWriteAsync(destination).ConfigureAwait(false))
                                            {
                                                var buffer = new byte[81920];
                                                int bytesRead = 0;
                                                var sourceLength = sourceFile.Length;
                                                int totalBytesRead = 0;
                                                int previousProgress = 0;
                                                while ((bytesRead = await sourceFile.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(false)) > 0)
                                                {
                                                    await destinationFile.WriteAsync(buffer, 0, bytesRead).ConfigureAwait(false);
                                                    totalBytesRead += bytesRead;
                                                    var progress = (int)(((double)totalBytesRead / (double)sourceLength) * 100);
                                                    if (progress != previousProgress)
                                                    {
                                                        BeginInvoke(new MethodInvoker(() => { ucUploadProgress.Progress = (int)(((double)totalBytesRead / (double)sourceLength) * 100); }));
                                                    }
                                                    previousProgress = progress;
                                                }
                                            }
                                        }
                                    });
                                }
                            }
                        }
                    }
                }
            }
        }

        public async void TerminalData(string data)
        {
            if (_shellStream != null && data != null)
            {
                await _shellStream.WriteAsync(new ReadOnlyMemory<byte>(Encoding.UTF8.GetBytes(data)));
                await _shellStream.FlushAsync();
                /*
                var param = e.Message.ToString().Split(',');
                _shellStream.SendWindowSizeChange(Convert.ToUInt32(param[1]), Convert.ToUInt32(param[0]), 0, 0);
                */
            }
        }
        /*
        public async void ResizeTerminal(UInt32 rows, UInt32 columns)
        {
            if (_shellStream != null)
            {
                Task.Run(() => { _shellStream.SendWindowSizeChange(columns, rows, 0, 0); });
                
            }
        }
        */
        private async void SshTerminal_JavascriptMessageReceived(object sender, JavascriptMessageReceivedEventArgs e)
        {
            if (_shellStream != null)
            {
                var param = e.Message.ToString().Split(',');
                _shellStream.SendWindowSizeChange(Convert.ToUInt32(param[1]), Convert.ToUInt32(param[0]), 0, 0);
            }
        }

        private async Task ScanDevices()
        {
            _devices.Clear();
            lbRoutes.Items.Clear();
            Task.Run(() =>
            {
                flyleafVideoPlayer.Stop();
            });
            dgvRouteInfo.DataSource = null;
            wifiConnected.SetEnabled(false);
            btnScan.Enabled = false;

            try
            {
                int foundDevices = 0;
                await Task.Run(async () =>
                {
                    try
                    {
                        await foreach (var device in OpenpilotDevice.DiscoverAsync().ConfigureAwait(false))
                        {
                            foundDevices++;

                            if (!_devices.Contains(device))
                            {
                                if (device is not UnknownDevice)
                                {
                                    if (!device.IsAuthenticated)
                                    {
                                        try
                                        {
                                            await device.ConnectSftpAsync().ConfigureAwait(false);
                                        }
                                        catch (SshAuthenticationException ex)
                                        {
                                            Serilog.Log.Information(ex, "Authentication failed for {Device}", device);
                                        }
                                    }
                                }

                                if (device.IsAuthenticated)
                                {
                                    Invoke(new MethodInvoker(async () =>
                                    {
                                        _devices.Add(device);
                                        if (_devices.Count == 1)
                                        {
                                            wifiConnected.SetEnabled(true);
                                            cmbDevices.SelectedIndex = -1;
                                            cmbDevices.SelectedIndex = 0;
                                        }
                                    }));
                                }
                            }
                        }
                    }
                    catch (TaskCanceledException)
                    {
                        Serilog.Log.Error("Discovery Timed Out.");
                    }

                });

                if (foundDevices < 1)
                {
                    ToolkitMessageDialog.ShowDialog(
                        "No devices were found, please check that SSH is enabled on your device and the device is connected to the network.", parent: this);
                }
                else if (_devices.Count < 1 && foundDevices > 0)
                {
                    if (ToolkitMessageDialog.ShowDialog(
                        $"{foundDevices} device(s) found but authentication failed, do you want to start the SSH wizard?", this, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        ucSshWizard.Reset();
                        tcSettings.SelectedTab = tpSSH;
                    }
                }
            }
            finally
            {
                btnScan.Enabled = true;
            }
        }

        private async void btnScan_Click(object sender, EventArgs e)
        {
            await ScanDevices().ConfigureAwait(false);
        }

        private async void btnExport_Click(object sender, EventArgs e)
        {
            if (cmbDevices.SelectedItem is OpenpilotDevice openpilotDevice)
            {
                var exportFolder = txtExportFolder.Text;
                var exportTasks = new List<Tuple<string, Task>>();
                var cameras = new List<Camera>(3);
                if (cbFrontCamera.Checked)
                {
                    if (openpilotDevice.Cameras.TryGetValue(CameraType.Front, out var camera))
                    {
                        cameras.Add(camera);
                    }
                }
                if (cbWideCamera.Checked)
                {
                    if (openpilotDevice.Cameras.TryGetValue(CameraType.Wide, out var camera))
                    {
                        cameras.Add(camera);
                    }
                }
                if (cbDriverCamera.Checked)
                {
                    if (openpilotDevice.Cameras.TryGetValue(CameraType.Driver, out var camera))
                    {
                        cameras.Add(camera);
                    }
                }

                if (cameras.Count < 1)
                {
                    ToolkitMessageDialog.ShowDialog("You must select at least 1 camera to export.");
                    return;
                }

                foreach (var selectedItem in lbRoutes.SelectedItems)
                {
                    if (selectedItem is Route route)
                    {
                        if (_activeTaskList.ContainsKey(route.Date.ToString()))
                        {
                            continue;
                        }

                        var ucRoute = new ucTaskProgress(route.ToString(), cameras.Count * 100)
                        {
                            Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top)
                        };

                        tlpTasks.Controls.Add(ucRoute);

                        var progressDictionary = cameras.ToDictionary(cam => cam, cam => 0);
                        var progressLock = new SemaphoreSlim(1, 1);
                        var progress = new Progress<OpenpilotSdk.OpenPilot.Camera.Progress>(async (cameraProgress) =>
                        {
                            if (!IsDisposed)
                            {
                                progressDictionary[cameraProgress.Camera] = cameraProgress.Percent;
                                try
                                {
                                    await progressLock.WaitAsync();

                                    var currentProgress = progressDictionary.Sum(progress => progress.Value);
                                    if (currentProgress > ucRoute.Progress)
                                    {
                                        ucRoute.Progress = currentProgress;
                                    }
                                }
                                finally
                                {
                                    progressLock.Release();
                                }
                            }
                        });

                        var task = Task.Run(async () =>
                        {
                            await Parallel.ForEachAsync(cameras, async (camera, token) =>
                            {
                                await openpilotDevice.ExportRouteAsync(exportFolder, route, camera, cbCombineSegments.Checked,
                                    progress);
                            });

                        });
                        exportTasks.Add(new Tuple<string, Task>(route.Date.ToString(), task));
                        _activeTaskList.TryAdd(route.Date.ToString(), task);
                    }
                }

                if (exportTasks.Count > 0)
                {
                    try
                    {
                        await Task.WhenAll(exportTasks.Select(item => item.Item2));
                    }
                    catch (Exception exception)
                    {
                        Serilog.Log.Error(exception, "Error exporting route.");
                        ToolkitMessageDialog.ShowDialog(exception.Message);
                    }

                    foreach (var exportTask in exportTasks)
                    {
                        _activeTaskList.TryRemove(exportTask.Item1, out _);
                    }
                }
            }
        }

        private async void btnRefreshVideos_Click(object sender, EventArgs e)
        {
            try
            {
                btnRefreshVideos.Enabled = false;
                await LoadRoutesAsync();
            }
            finally
            {
                btnRefreshVideos.Enabled = true;
            }
        }

        private readonly SemaphoreSlim _routeSemaphoreSlim = new SemaphoreSlim(1, 1);
        private CancellationTokenSource _routeVideo;
        private async void LbRoutesSelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDevices.Enabled = false;
            dgvRouteInfo.DataSource = null;

            try
            {
                if (cmbDevices.SelectedItem is OpenpilotDevice openpilotDevice)
                {
                    if (lbRoutes.SelectedItems.Count < 2 && lbRoutes.SelectedItem is Route route)
                    {
                        var routeInfo = new Dictionary<string, string>
                        {
                            { "Segments", route.Segments.Count.ToString() },
                            { "Start Date", route.Date.ToShortDateString() },
                            { "Start Time", route.Date.ToLongTimeString() }
                        };

                        dgvRouteInfo.DataSource = routeInfo.ToArray();
                        try
                        {
                            if (route.Segments.Any())
                            {
                                await Task.Run(async () =>
                                {
                                    var cts = new CancellationTokenSource();

                                    await _routeSemaphoreSlim.WaitAsync().ConfigureAwait(false);
                                    try
                                    {
                                        if (_routeVideo != null)
                                        {
                                            await _routeVideo.CancelAsync().ConfigureAwait(false);
                                        }

                                        _routeVideo = cts;
                                    }
                                    finally
                                    {
                                        _routeSemaphoreSlim.Release();
                                    }
                                    await flyleafVideoPlayer.PlayRouteAsync(openpilotDevice, route, cts.Token).ConfigureAwait(false);
                                });
                            }
                        }
                        catch (Exception exception)
                        {
                            Serilog.Log.Error(exception, "Error playing video");
                            ToolkitMessageDialog.ShowDialog(exception.Message);
                            cmbDevices.Enabled = true;
                            return;
                        }
                    }
                }
            }
            finally
            {
                cmbDevices.Enabled = true;
            }
        }

        private void ExportDrivesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_activeTaskList.Any())
            {
                MessageBox.Show("Files are exporting");
                e.Cancel = true;
                return;
            }

            Properties.Settings.Default.DarkMode = MaterialSkinManager.Instance.Theme == MaterialSkinManager.Themes.DARK;
            Properties.Settings.Default.ExportFolder = txtExportFolder.Text;

            Properties.Settings.Default.CombineSegments = cbCombineSegments.Checked;
            Properties.Settings.Default.SeekToKeyframes = cbSeekToKeyframes.Checked;

            Properties.Settings.Default.FrontCamera = cbFrontCamera.Checked;
            Properties.Settings.Default.WideCamera = cbWideCamera.Checked;
            Properties.Settings.Default.DriverCamera = cbDriverCamera.Checked;

            //Properties.Settings.Default.OsmUsername = txtOsmUsername.Text;
            //Properties.Settings.Default.OsmPassword = txtOsmPassword.Text;
            if (!string.IsNullOrWhiteSpace(_osmToken))
            {
                Properties.Settings.Default.OsmToken = _osmToken;
            }

            Properties.Settings.Default.Save();

            flyleafVideoPlayer.Stop();

            _sshTerminal.Dispose();
            Cef.PreShutdown();
        }

        private HttpClient _osmHttpClient;
        private async void btnExportGpx_Click(object sender, EventArgs e)
        {
            if (cmbDevices.SelectedItem is OpenpilotDevice openpilotDevice)
            {
                var exportTasks = new List<Task>();
                foreach (var selectedItem in lbRoutes.SelectedItems)
                {
                    if (selectedItem is Route route)
                    {
                        var exportFolder = txtExportFolder.Text;

                        var ucRoute = new ucTaskProgress(route.ToString(), route.Segments.Count)
                        {
                            Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top)
                        };

                        tlpTasks.Controls.Add(ucRoute);

                        var segmentsProcessed = 0;

                        var progress = new Progress<int>((segmentIndex) =>
                        {
                            if (!IsDisposed)
                            {
                                Interlocked.Increment(ref segmentsProcessed);
                                ucRoute.Progress = segmentsProcessed;
                            }
                        });

                        exportTasks.Add(Task.Run(async () =>
                        {
                            var fileName = Path.Combine(exportFolder, route + ".gpx");
                            var gpxFile = await openpilotDevice.GenerateGpxFileAsync(route, progress);
                            var gpxString = gpxFile.BuildString(new GpxWriterSettings());
                            await File.WriteAllTextAsync(fileName, gpxString);
                        }));
                    }
                }

                if (exportTasks.Count > 0)
                {
                    await Task.WhenAll(exportTasks);
                }
            }
        }

        private Rational[] GetRational(double coordinate)
        {
            double decimal_degrees = Math.Floor(coordinate);
            double minutes = (coordinate - Math.Floor(coordinate)) * 60.0;
            double seconds = Math.Round((minutes - Math.Floor(minutes)) * 60.0, 4, MidpointRounding.AwayFromZero);

            minutes = Math.Floor(minutes);

            return new[] { new Rational(decimal_degrees), new Rational(minutes), new Rational(seconds) };
        }

        private void ExportFrames(string exportFolder, Route route, string selectStatement, int startNumber)
        {
            var cmd = @" -framerate 20 -i " + '"' +
                      Path.Combine(exportFolder, route.Date.ToShortDateString() + ".hevc") + '"' +
                      " -vf select='" + selectStatement + @"' -vsync 0 -q:v 2 -start_number " + startNumber + " " + '"' + @"D:\openpilot\testf\mapillary-%03d.jpg" +
                      '"';




            using (var process = new Process())
            {
                var startInfo = new ProcessStartInfo
                {
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = Path.Combine(AppContext.BaseDirectory, "ffmpeg.exe"),
                    Arguments = cmd,
                };
                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();
            }

            // hookup the eventhandlers to capture the data that is received
            //process.OutputDataReceived += (sender, args) => sb.AppendLine(args.Data);
            //process.ErrorDataReceived += (sender, args) => sb.AppendLine(args.Data);


        }

        private async void btnExportMapillary_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();

            if (cmbDevices.SelectedItem is OpenpilotDevice openpilotDevice)
            {
                if (lbRoutes.SelectedItem is Route route)
                {
                    if (_activeTaskList.ContainsKey(route.Date.ToString()))
                    {
                        return;
                    }
                    //MessageBox.Show("Exporting Route: " + drive.Id);
                    var exportFolder = txtExportFolder.Text;

                    var ucRoute = new ucTaskProgress(route.ToString(), route.Segments.Count)
                    {
                        Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top)
                    };

                    tlpTasks.Controls.Add(ucRoute);

                    var segmentsProcessed = 0;

                    var progress = new Progress<int>((segmentIndex) =>
                    {
                        if (!IsDisposed)
                        {
                            Interlocked.Increment(ref segmentsProcessed);
                            ucRoute.Progress = segmentsProcessed; ;
                        }
                    });

                    var task = Task.Run(async () =>
                    {
                        //TODO:
                        //await openpilotDevice.ExportRouteAsync(exportFolder, drive, cbCombineSegments.Checked, progress);
                    });

                    _activeTaskList.TryAdd(route.Date.ToString(), task);
                    await task;
                    _activeTaskList.TryRemove(route.Date.ToString(), out _);

                    var waypoints = await openpilotDevice.MapillaryExportAsync(route);

                    var firstTime = waypoints.First().TimestampUtc.Value;


                    int count = 0;
                    int startNumber = 1;
                    var frames = string.Join("+",
                        waypoints.Select(wp =>
                            @"eq(n\," + (int)(((wp.TimestampUtc.Value - firstTime).TotalMilliseconds) / 50) + ")"));
                    ExportFrames(exportFolder, route, frames, 0);

                    /*
                    foreach (var gpxWaypoint in waypoints)
                    {
                        count++;
                        frames.Add(@"eq(n\," + (int)(((gpxWaypoint.TimestampUtc.Value - firstTime).TotalMilliseconds) / 50) + ")");
                        if (frames.Count > 49)
                        {

                            ExportFrames(exportFolder, drive, string.Join("+", frames), startNumber);
                            startNumber = count + 1;
                            frames.Clear();
                        }
                    }

                    if (frames.Count > 0)
                    {
                        ExportFrames(exportFolder, drive, string.Join("+", frames), startNumber);
                    }
                    
                    var imageFiles = Directory.GetFiles(@"D:\OpenPilot\testf", "*.jpg");
                    var sequenceuuid = Guid.NewGuid();
                    for (int i = 0; i < imageFiles.Length; i++)
                    {
                        using (Image image = Image.Load(imageFiles[i]))
                        {
                            // Create a new profile, since we crated the image.
                            image.Metadata.ExifProfile = new ExifProfile();

                            image.Metadata.ExifProfile.SetValue(ExifTag.GPSLatitude, GetRational(waypoints[i].Latitude.Value));
                            image.Metadata.ExifProfile.SetValue(ExifTag.GPSLongitude, GetRational(waypoints[i].Longitude.Value));
                            image.Metadata.ExifProfile.SetValue(ExifTag.GPSLatitudeRef, waypoints[i].Latitude.Value > 0 ? "N" : "S");
                            image.Metadata.ExifProfile.SetValue(ExifTag.GPSLongitudeRef, waypoints[i].Longitude.Value > 0 ? "E" : "W");
                            image.Metadata.ExifProfile.SetValue(ExifTag.Make, "sony");
                            image.Metadata.ExifProfile.SetValue(ExifTag.Model, "IMX298 Exmor RS");
                            //image.Metadata.ExifProfile.SetValue(ExifTag.OffsetTime, "-04:00");
                            //image.Metadata.ExifProfile.SetValue(ExifTag.OffsetTimeOriginal, "-04:00");
                            //image.Metadata.ExifProfile.SetValue(ExifTag.DateTimeOriginal, waypoints[i].TimestampUtc.Value.ToString("yyyy:MM:dd HH:mm:ss.fffffffzzz"));
                            //image.Metadata.ExifProfile.SetValue(ExifTag.DateTime, waypoints[i].TimestampUtc.Value.ToString("yyyy:MM:dd HH:mm:ss.fffffffzzz"));
                            //image.Metadata.ExifProfile.SetValue(ExifTag.DateTimeDigitized, waypoints[i].TimestampUtc.Value.ToString("yyyy:MM:dd HH:mm:ss"));

                            var mapillaryData = new MapillaryData
                            {
                                MapLatitude = waypoints[i].Latitude.Value,
                                MapLongitude = waypoints[i].Longitude.Value,
                                MapCaptureTime = waypoints[i].TimestampUtc.Value.ToString(),
                                MapAltitude = waypoints[i].ElevationInMeters,
                                MapSettingsUsername = "username",
                                MapSettingsUserKey = "userKey",
                                MapSequenceUuid = sequenceuuid,
                                MapOrientation = 1,
                                MapDeviceMake = "none",
                                MapDeviceModel = "none",
                                MapMetaTags = new MapMetaTags() {Strings = new string[] {"key", "value"}},
                                MapPhotoUuid = Guid.NewGuid()
                            };
                            //image.Metadata.ExifProfile.SetValue(ExifTag.ImageDescription, mapillaryData.ToJson());
                            image.SaveAsync(imageFiles[i]);
                        }
                    }
                    
                    */
                }
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (fbdExportFolder.ShowDialog() == DialogResult.OK)
                txtExportFolder.Text = fbdExportFolder.SelectedPath;
        }

        public void SetTheme(bool darkMode)
        {
            if (darkMode)
            {
                themeButton.Icon = Properties.Resources.light_mode_white;
                MaterialSkinManager.Instance.Theme = MaterialSkinManager.Themes.DARK;
            }
            else
            {
                themeButton.Icon = Properties.Resources.dark_mode_white;
                MaterialSkinManager.Instance.Theme = MaterialSkinManager.Themes.LIGHT;
            }

            lbRoutes.BackColor = MaterialSkinManager.Instance.BackgroundColor;
            lbRoutes.ForeColor = MaterialSkinManager.Instance.TextHighEmphasisColor;
            groupBox1.ForeColor = MaterialSkinManager.Instance.TextHighEmphasisColor;
            groupBox2.ForeColor = MaterialSkinManager.Instance.TextHighEmphasisColor;
            groupBox3.ForeColor = MaterialSkinManager.Instance.TextHighEmphasisColor;
            groupBox4.ForeColor = MaterialSkinManager.Instance.TextHighEmphasisColor;
        }

        private void themeButton_Click(object sender, EventArgs e)
        {
            SetTheme(MaterialSkinManager.Instance.Theme == MaterialSkinManager.Themes.LIGHT);
        }

        private bool _videoPauseFromTabSwitch = false;

        private OpenpilotDevice _lastExplorerDevice = null;
        private async void tcSettings_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage != null)
            {
                if (e.TabPage != tpExport)
                {
                    if (flyleafVideoPlayer.flyleafHost1.Player.IsPlaying)
                    {
                        _videoPauseFromTabSwitch = true;
                        flyleafVideoPlayer.Pause();
                    }
                }
                else
                {
                    if (cmbDevices.SelectedItem is OpenpilotDevice openpilotDevice)
                    {
                        if (openpilotDevice.IsAuthenticated)
                        {
                            if (_videoPauseFromTabSwitch)
                            {
                                _videoPauseFromTabSwitch = false;
                                flyleafVideoPlayer.Play();
                            }
                        }
                    }
                }

                if (e.TabPage == tpLogFile)
                {
                    var directoryInfo = new DirectoryInfo(Path.Combine(AppContext.BaseDirectory, "logs"));
                    var logFile = directoryInfo.GetFiles("*.txt", SearchOption.TopDirectoryOnly)
                        .OrderByDescending(file => file.LastWriteTime).FirstOrDefault();
                    if (logFile != null)
                    {
                        using (var fileStream = new FileStream(logFile.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        using (var streamReader = new StreamReader(fileStream))
                        {
                            txtLog.Text = streamReader.ReadToEnd();
                        }

                    }
                }
                else if (e.TabPage == tpExplore)
                {

                    if (cmbDevices.SelectedItem is OpenpilotDevice openpilotDevice)
                    {
                        if (_lastExplorerDevice == null || openpilotDevice != _lastExplorerDevice)
                        {
                            _workingDirectory.Clear();
                            //TODO: _fileList = comma2.EnumerateFileSystemEntries
                            txtWorkingDirectory.Text = openpilotDevice.WorkingDirectory;
                            IEnumerable<Renci.SshNet.Sftp.ISftpFile> files = null;

                            var directories = openpilotDevice.WorkingDirectory.Split("/");
                            foreach (var directory in directories)
                            {
                                _workingDirectory.Push(directory);
                            }

                            await Task.Run(async () =>
                            {
                                var currentWorkingDirectory = string.Join("/", _workingDirectory.Reverse());
                                files = await openpilotDevice.EnumerateFilesAsync(currentWorkingDirectory);
                            });
                            dgvExplorer.DataSource = files.OrderBy(file => file.Name).ToArray();
                        }

                        _lastExplorerDevice = openpilotDevice;
                    }
                    else
                    {
                        _workingDirectory.Clear();
                    }

                }
                else if (e.TabPage == tpFingerprint)
                {
                    txtFingerprint.Clear();
                    if (cmbDevices.SelectedItem is OpenpilotDevice openpilotDevice)
                    {
                        if (openpilotDevice.IsAuthenticated)
                        {
                            IEnumerable<Firmware> firmwares = null;
                            txtFingerprint.Text = "Loading...";
                            await Task.Run(async () =>
                            {
                                firmwares = await openpilotDevice.GetFirmwareVersions();
                            });
                            var sb = new StringBuilder();
                            foreach (var firmware in firmwares)
                            {
                                sb.AppendLine(string.Format("ecu = {0}", firmware.Ecu));
                                sb.AppendLine(string.Format("fwVersion = b'{0}'", firmware.Version));
                                sb.AppendLine(string.Format("address = {0}", firmware.Address));
                                sb.AppendLine(string.Format("subAddress = {0}", firmware.SubAddress));
                                sb.AppendLine("");
                            }

                            txtFingerprint.Text = sb.ToString();
                        }
                    }

                }
                else if (e.TabPage == tpShell)
                {
                    if (cmbDevices.SelectedItem is OpenpilotDevice openpilotDevice)
                    {
                        try
                        {
                            if (_shellStream != null)
                            {
                                _shellStream.DataReceived -= ShellStreamOnDataReceived;
                                await _shellStream.DisposeAsync();
                            }

                            await _sshTerminal.EvaluateScriptAsync("ClearTerminal()");

                            await Task.Run(async () =>
                            {
                                _shellStream = await openpilotDevice.GetShellStreamAsync();
                                _streamReader = new StreamReader(_shellStream);
                            });
                            await _sshTerminal.EvaluateScriptAsync("resizeTerminal()");
                            _shellStream.DataReceived += ShellStreamOnDataReceived;
                        }
                        catch (Exception ex)
                        {
                            Serilog.Log.Error(ex, "Failed to create shell stream.");
                        }
                    }
                }
            }
        }

        private async void ShellStreamOnDataReceived(object sender, ShellDataEventArgs e)
        {
            await _terminalLock.WaitAsync();
            try
            {
                if (_shellStream.DataAvailable)
                {
                    var terminalText = await _streamReader.ReadToEndAsync();
                    Invoke(new MethodInvoker(async () =>
                    {
                        await _sshTerminal.EvaluateScriptAsync("WriteText", new object[] { terminalText });
                    }));
                }
            }
            finally
            {
                _terminalLock.Release();
            }
        }

        private void materialButton8_Click(object sender, EventArgs e)
        {
            adbConnected.Enabled = !adbConnected.Enabled;
            adbConnected.Icon = Properties.Resources.outline_description_black_24dp;
        }

        private void ucSshWizard_WizardCompleted(object sender, EventArgs e)
        {
            tcSettings.SelectedTab = tpExport;
            ucSshWizard.Reset();
            btnScan.PerformClick();
        }

        private void dgvExplorer_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewColumn column = dgvExplorer.Columns[e.ColumnIndex];
            if (column.DataPropertyName.Contains("."))
            {
                string cellValue = "";
                object data = dgvExplorer.Rows[e.RowIndex].DataBoundItem;
                var fileName = ((Renci.SshNet.Sftp.SftpFile)data).Name;

                string[] properties = column.DataPropertyName.Split('.');
                for (int i = 0; i < properties.Length && data != null; i++)
                {
                    data = data.GetType().GetProperty(properties[i]).GetValue(data);
                }

                if (data is bool)
                {
                    if (fileName == "..")
                    {
                        cellValue = "Parent Directory";
                    }
                    else if (fileName == ".")
                    {
                        cellValue = "Refresh";
                    }
                    else
                    {
                        cellValue = (bool)data ? "File Folder" : "File";
                    }
                }
                else
                {
                    cellValue = data.ToString();
                }
                dgvExplorer.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = cellValue;
            }
        }

        private async void dgvExplorer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            await ExplorerCellAction();
        }

        private async Task ExplorerCellAction()
        {
            if (dgvExplorer.SelectedRows.Count < 1)
            {
                return;
            }

            if (cmbDevices.SelectedItem is OpenpilotDevice openpilotDevice)
            {
                var selectedRow = dgvExplorer.SelectedRows[0];
                var selectedItem = ((Renci.SshNet.Sftp.SftpFile)selectedRow.DataBoundItem);
                if (!((selectedItem.IsDirectory && !selectedItem.IsRegularFile) || selectedItem.IsSymbolicLink))
                {
                    var normalizedPath = selectedItem.FullName.Replace('/', Path.DirectorySeparatorChar);
                    normalizedPath = normalizedPath.StartsWith(Path.DirectorySeparatorChar)
                        ? normalizedPath.Substring(1, normalizedPath.Length - 1) : normalizedPath;

                    var outputFilePath = Path.Combine(_tempExplorerFiles, normalizedPath);

                    if (!_watchedFiles.TryAdd(outputFilePath, null))
                    {
                        DateTime? modifiedDate = null;
                        _watchedFiles.TryGetValue(outputFilePath, out modifiedDate);
                        if (modifiedDate == null)
                        {
                            return;
                        }

                        _watchedFiles[outputFilePath] = null;
                    }

                    Directory.CreateDirectory(Path.GetDirectoryName(outputFilePath));

                    await using (var outputFile = File.Create(outputFilePath))
                    {
                        await using (var stream = await openpilotDevice.OpenReadAsync(selectedItem.FullName))
                        {
                            var ucDownloadProgress = new ucProgress("↓ " + selectedItem.Name)
                            {
                                Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top)
                            };

                            tlpExplorerTasks.Controls.Add(ucDownloadProgress);

                            var buffer = new byte[81920];
                            int bytesRead = 0;
                            var sourceLength = stream.Length;
                            int totalBytesRead = 0;
                            int previousProgress = 0;

                            while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(false)) > 0)
                            {

                                await outputFile.WriteAsync(buffer, 0, bytesRead).ConfigureAwait(false);
                                totalBytesRead += bytesRead;

                                var progress = (int)(((double)totalBytesRead / (double)sourceLength) * 100);
                                if (progress != previousProgress)
                                {
                                    BeginInvoke(new MethodInvoker(() => { ucDownloadProgress.Progress = (int)(((double)totalBytesRead / (double)sourceLength) * 100); }));
                                }
                                previousProgress = progress;
                            }
                        }
                    }

                    _watchedFiles[outputFilePath] = File.GetLastWriteTimeUtc(outputFilePath);

                    using (var process = new Process())
                    {
                        process.StartInfo = new ProcessStartInfo(outputFilePath)
                        {
                            UseShellExecute = true,

                        };
                        process.Start();
                    }

                    return;
                }
                else
                {
                    _explorerSearchString.Clear();

                    var path = selectedItem.Name;
                    var workingDirectory = new Stack<string>(_workingDirectory.Reverse());
                    if (path == "..")
                    {
                        if (workingDirectory.Count > 1)
                        {
                            workingDirectory.Pop();
                        }
                        else
                        {
                            return;
                        }
                    }
                    else if (path != ".")
                    {
                        workingDirectory.Push(path);
                    }
                    var newPath = string.Join("/", workingDirectory.Reverse());
                    newPath = newPath.Length < 1 ? "/" : newPath;

                    IEnumerable<Renci.SshNet.Sftp.ISftpFile> files = null;

                    var currentWorkingDirectory = string.Join("/", newPath);
                    files = (await openpilotDevice.EnumerateFilesAsync(currentWorkingDirectory)).OrderBy(file => file.Name).ToArray();
                    _workingDirectory = workingDirectory;


                    dgvExplorer.DataSource = files;

                    txtWorkingDirectory.Text = newPath;
                }
            }
        }

        private void cbCombineSegments_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.CombineSegments = cbCombineSegments.Checked;
        }

        private void btnKofi_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "https://ko-fi.com/spektor56");
        }

        private void btnPaypal_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "https://paypal.me/spektor56");
        }

        private void btnBuyMeCoffee_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "https://www.buymeacoffee.com/spektor56");
        }

        private async void btnInstallFork_Click(object sender, EventArgs e)
        {
            btnInstallFork.Enabled = false;
            try
            {
                var forkUser = txtForkUsername.Text;
                var forkRepository = txtRepositoryName.Text;
                var forkBranch = txtForkBranch.Text;

                if (string.IsNullOrWhiteSpace(forkUser))
                {
                    forkUser = "commaai";
                }

                if (string.IsNullOrWhiteSpace(forkBranch))
                {
                    ToolkitMessageDialog.ShowDialog("Fork Branch is Required", this);
                    return;
                }

                if (string.IsNullOrWhiteSpace(forkRepository))
                {
                    forkRepository = "openpilot";
                }

                if (cmbDevices.SelectedItem is OpenpilotDevice openpilotDevice)
                {
                    ForkResult result = null;
                    var progress = new Progress<InstallProgress>();

                    using (new ToolkitProgressDialog("Installing fork, please wait", this, progress))
                    {
                        await Task.Run(async () =>
                        {
                            result = await
                                openpilotDevice.InstallForkAsync(forkUser, forkBranch, progress, forkRepository).ConfigureAwait(false);
                        });
                    }

                    ToolkitMessageDialog.ShowDialog(
                        result.Success
                            ? "Install Successful"
                            : $"There was an error during installation: {result.Message}", this);
                }
                else
                {
                    ToolkitMessageDialog.ShowDialog("No comma device selected", this);
                    return;
                }
            }
            catch (Exception exception)
            {
                Serilog.Log.Error(exception, "error in fork installer");
                ToolkitMessageDialog.ShowDialog(exception.Message);
                return;
            }
            finally
            {
                btnInstallFork.Enabled = true;
            }
        }

        private async void materialButton1_Click(object sender, EventArgs e)
        {
            if (cmbDevices.SelectedItem is OpenpilotDevice openpilotDevice)
            {
                EnableRemoteControls(false);

                try
                {
                    bool result = false;
                    using (new ToolkitProgressDialog("Rebooting Device...", this))
                    {
                        await Task.Run(async () =>
                        {
                            result = await openpilotDevice.RebootAsync();
                        });
                    }

                    if (result)
                    {
                        ToolkitMessageDialog.ShowDialog("Rebooted Device.");
                    }
                    else
                    {
                        ToolkitMessageDialog.ShowDialog("Failed to Reboot Device.");
                    }
                }
                finally
                {
                    EnableRemoteControls(true);
                }
            }
        }

        private async void btnShutdown_Click(object sender, EventArgs e)
        {
            if (cmbDevices.SelectedItem is OpenpilotDevice openpilotDevice)
            {
                EnableRemoteControls(false);

                try
                {
                    bool result = false;
                    using (new ToolkitProgressDialog("Shutting Down Device...", this))
                    {
                        await Task.Run(async () =>
                        {
                            result = await openpilotDevice.ShutdownAsync();
                        });
                    }

                    if (result)
                    {
                        ToolkitMessageDialog.ShowDialog("Shutdown the Device.");
                    }
                    else
                    {
                        ToolkitMessageDialog.ShowDialog("Failed to Shutdown Device.");
                    }
                }
                finally
                {
                    EnableRemoteControls(true);
                }
            }
        }

        private async void btnOpenSettings_Click(object sender, EventArgs e)
        {
            if (cmbDevices.SelectedItem is Comma2 openpilotDevice)
            {
                EnableRemoteControls(false);

                try
                {
                    await Task.Run(async () =>
                    {
                        var result = await openpilotDevice.OpenSettingsAsync();
                    });


                }
                finally
                {
                    EnableRemoteControls(true);
                }
            }
        }

        private async void btnCloseSettings_Click(object sender, EventArgs e)
        {
            if (cmbDevices.SelectedItem is Comma2 openpilotDevice)
            {
                EnableRemoteControls(false);

                try
                {
                    await Task.Run(async () =>
                    {
                        var result = await openpilotDevice.CloseSettingsAsync();
                    });
                }
                finally
                {
                    EnableRemoteControls(true);
                }
            }
        }

        private async void btnFlashPanda_Click(object sender, EventArgs e)
        {
            if (cmbDevices.SelectedItem is OpenpilotDevice openpilotDevice)
            {
                EnableRemoteControls(false);

                try
                {
                    bool result = false;
                    using (new ToolkitProgressDialog("Flashing Panda", this))
                    {
                        await Task.Run(async () =>
                        {
                            result = await openpilotDevice.FlashPandaAsync();
                        });
                    }


                    if (result)
                    {
                        ToolkitMessageDialog.ShowDialog("Flashed Panda.");
                    }
                    else
                    {
                        ToolkitMessageDialog.ShowDialog("Failed to flash Panda");
                    }
                }
                finally
                {
                    EnableRemoteControls(true);
                }
            }
        }

        /*
        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        private static extern int SendMessage(System.IntPtr hWnd, int wMsg, System.IntPtr wParam, System.IntPtr lParam);

        private const int WM_VSCROLL = 0x115;
        private const int SB_BOTTOM = 7;

        /// <summary>
        /// Scrolls the vertical scroll bar of a text box to the bottom.
        /// </summary>
        /// <param name="tb">The text box base to scroll</param>
        public static void ScrollToBottom(System.Windows.Forms.TextBoxBase tb)
        {
            if (System.Environment.OSVersion.Platform != System.PlatformID.Unix)
                SendMessage(tb.Handle, WM_VSCROLL, new System.IntPtr(SB_BOTTOM), System.IntPtr.Zero);
        }
        

        private void txtTerminalText_TextChanged(object sender, EventArgs e)
        {
            //ScrollToBottom(txtTerminalText);
        }
        */
        private async Task LoadRoutesAsync()
        {
            var item = cmbDevices.SelectedItem;
            if (item is OpenpilotDevice openpilotDevice)
            {
                try
                {
                    lbRoutes.Items.Clear();

                    await Task.Run(async () =>
                    {
                        await foreach (var route in openpilotDevice.GetRoutesAsync().ConfigureAwait(false))
                        {
                            BeginInvoke(new MethodInvoker(() =>
                            {
                                lbRoutes.Items.Add(route);
                                if (lbRoutes.Items.Count == 1)
                                {
                                    lbRoutes.SelectedIndex = 0;
                                }
                            }));
                        }
                    });
                }
                catch (Exception exception)
                {
                    Serilog.Log.Error(exception, "Error retrieving routes");
                    ToolkitMessageDialog.ShowDialog(exception.Message);
                    return;
                }
            }
        }

        private async void cmbDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadRoutesAsync().ConfigureAwait(false);
        }

        private async void materialButton1_Click_1(object sender, EventArgs e)
        {
            if (cmbDevices.SelectedItem is OpenpilotDevice openpilotDevice)
            {
                EnableRemoteControls(false);

                try
                {
                    bool result = false;
                    using (new ToolkitProgressDialog("Installing Emu...", this))
                    {
                        await Task.Run(async () =>
                        {
                            result = await openpilotDevice.InstallEmuAsync();
                        });
                    }

                    if (result)
                    {
                        ToolkitMessageDialog.ShowDialog("Emu Installed.");
                    }
                    else
                    {
                        ToolkitMessageDialog.ShowDialog("Emu Installation Failed.");
                    }
                }
                finally
                {
                    EnableRemoteControls(true);
                }
            }
        }
        private void EnableRemoteControls(bool enable)
        {
            foreach (var control in tpRemote.Controls)
            {
                if (control is MaterialButton)
                {
                    ((MaterialButton)control).Enabled = enable;
                }
            }
        }
        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cmbDevices.SelectedItem is OpenpilotDevice openpilotDevice)
            {
                EnableRemoteControls(false);

                try
                {
                    ForkResult result = null;
                    var progress = new Progress<InstallProgress>();

                    using (new ToolkitProgressDialog("Reinstalling fork, please wait", this, progress))
                    {
                        await Task.Run(async () =>
                        {
                            result = await openpilotDevice.ReinstallOpenpilotAsync(progress);
                        });
                    }

                    ToolkitMessageDialog.ShowDialog(
                        result.Success
                            ? "Reinstall Successful"
                            : $"There was an error during installation: {result.Message}", this);
                }
                catch (Exception exception)
                {
                    Serilog.Log.Error(exception, "error in fork installer");
                    ToolkitMessageDialog.ShowDialog(exception.Message);
                    return;
                }
                finally
                {
                    EnableRemoteControls(true);
                }
            }
        }

        private void dgvExplorer_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data != null)
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    e.Effect = DragDropEffects.Copy;
                }
            }
        }

        private string GetCurrentPath()
        {
            var path = string.Join("/", _workingDirectory.Reverse());
            path = path.Length < 1 ? "/" : path;
            return path;
        }

        private async Task UploadFile(OpenpilotDevice openpilotDevice, string file, string destinationPath)
        {
            var ucUploadProgress = new ucProgress("↑ " + Path.GetFileName(file))
            {
                Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top)
            };

            tlpExplorerTasks.Controls.Add(ucUploadProgress);

            var destination = destinationPath + "/" + Path.GetFileName(file);

            await using (var sourceFile = File.OpenRead(file))
            {
                await using (var destinationFile = await openpilotDevice.OpenWriteAsync(destination))
                {
                    var buffer = new byte[81920];
                    int bytesRead = 0;
                    var sourceLength = sourceFile.Length;
                    int totalBytesRead = 0;
                    int previousProgress = 0;

                    while ((bytesRead = await sourceFile.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        await destinationFile.WriteAsync(buffer, 0, bytesRead);
                        totalBytesRead += bytesRead;
                        var progress = (int)(((double)totalBytesRead / (double)sourceLength) * 100);
                        if (progress != previousProgress)
                        {
                            ucUploadProgress.Progress = (int)(((double)totalBytesRead / (double)sourceLength) * 100);
                        }
                        previousProgress = progress;
                    }
                }
            }
        }

        private async void dgvExplorer_DragDrop(object sender, DragEventArgs e)
        {
            var destinationPath = GetCurrentPath();


            if (cmbDevices.SelectedItem is OpenpilotDevice openpilotDevice)
            {
                if (e.Data != null)
                {
                    var data = e.Data.GetData(DataFormats.FileDrop);
                    if (data is String[] files)
                    {
                        var uploadTasks = files.Select(file => UploadFile(openpilotDevice, file, destinationPath)).ToArray();
                        await Task.WhenAll(uploadTasks);

                        if (GetCurrentPath() == destinationPath)
                        {
                            IEnumerable<Renci.SshNet.Sftp.ISftpFile> directoryContents = null;

                            await Task.Run(async () =>
                            {
                                directoryContents = await openpilotDevice.EnumerateFilesAsync(destinationPath);
                            });
                            dgvExplorer.DataSource = directoryContents.OrderBy(file => file.Name).ToArray();
                        }
                    }
                }
            }
        }

        private async void dgvExplorer_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                var destinationPath = GetCurrentPath();
                var selectedRows = dgvExplorer.SelectedRows.Cast<DataGridViewRow>().Where(row => ((Renci.SshNet.Sftp.SftpFile)row.DataBoundItem).Name != ".." && ((Renci.SshNet.Sftp.SftpFile)row.DataBoundItem).Name != ".").ToArray();
                if (selectedRows.Length < 1)
                {
                    return;
                }

                if (cmbDevices.SelectedItem is OpenpilotDevice openpilotDevice)
                {
                    if (ToolkitMessageDialog.ShowDialog(
                            $"Are you sure you want to delete {selectedRows.Length} item(s): {Environment.NewLine + string.Join(Environment.NewLine, selectedRows.Select(row => ((Renci.SshNet.Sftp.SftpFile)row.DataBoundItem).Name))}", this, MessageBoxButtons.YesNo) != DialogResult.Yes)
                    {
                        return;
                    }

                    var deleteTasks = selectedRows.Where(row => !(((Renci.SshNet.Sftp.SftpFile)row.DataBoundItem).Name == ".." || ((Renci.SshNet.Sftp.SftpFile)row.DataBoundItem).Name == ".")).Select(row => openpilotDevice.DeleteFile((Renci.SshNet.Sftp.SftpFile)row.DataBoundItem)).ToArray();
                    await Task.WhenAll(deleteTasks);

                    if (GetCurrentPath() == destinationPath)
                    {
                        IEnumerable<Renci.SshNet.Sftp.ISftpFile> directoryContents = null;

                        await Task.Run(async () =>
                        {
                            directoryContents = await openpilotDevice.EnumerateFilesAsync(destinationPath);
                        });
                        dgvExplorer.DataSource = directoryContents.OrderBy(file => file.Name).ToArray();
                    }
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                await ExplorerCellAction();
            }
        }

        private async void BtnDeleteRoutesClick(object sender, EventArgs e)
        {
            if (cmbDevices.SelectedItem is OpenpilotDevice openpilotDevice)
            {
                var selectedItems = lbRoutes.SelectedItems;
                if (selectedItems.Count > 0)
                {
                    if (ToolkitMessageDialog.ShowDialog($"Are you sure you want to delete {selectedItems.Count} routes(s): {Environment.NewLine + string.Join(Environment.NewLine, selectedItems.Cast<object>().Where(item => item is Route).Select(row => row.ToString()))}", this, MessageBoxButtons.YesNo) != DialogResult.Yes)
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }

                await Task.Run(async () =>
                {
                    var deleteTasks = new Dictionary<Route, Task>();
                    foreach (var selectedItem in selectedItems)
                    {
                        if (selectedItem is Route route)
                        {
                            if (_activeTaskList.ContainsKey(route.Date.ToString()))
                            {
                                continue;
                            }

                            deleteTasks.Add(route, openpilotDevice.DeleteRouteAsync(route));
                        }
                    }

                    foreach (var deleteTask in deleteTasks)
                    {
                        await deleteTask.Value;
                        BeginInvoke(new MethodInvoker(() =>
                        {
                            lbRoutes.Items.Remove(deleteTask.Key);
                        }));
                    }
                });
            }
        }

        private async void LbRoutesPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (cmbDevices.SelectedItem is OpenpilotDevice openpilotDevice)
                {
                    var selectedItems = lbRoutes.SelectedItems;
                    if (selectedItems.Count > 0)
                    {
                        if (ToolkitMessageDialog.ShowDialog($"Are you sure you want to delete {selectedItems.Count} routes(s): {Environment.NewLine + string.Join(Environment.NewLine, selectedItems.Cast<object>().Where(item => item is Route).Select(row => row.ToString()))}", this, MessageBoxButtons.YesNo) != DialogResult.Yes)
                        {
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }

                    await Task.Run(async () =>
                    {
                        var deleteTasks = new Dictionary<Route, Task>();
                        foreach (var selectedItem in selectedItems)
                        {
                            if (selectedItem is Route route)
                            {
                                if (_activeTaskList.ContainsKey(route.Date.ToString()))
                                {
                                    continue;
                                }

                                deleteTasks.Add(route, openpilotDevice.DeleteRouteAsync(route));
                            }
                        }

                        foreach (var deleteTask in deleteTasks)
                        {
                            await deleteTask.Value;
                            BeginInvoke(new MethodInvoker(() =>
                            {
                                lbRoutes.Items.Remove(deleteTask.Key);
                            }));
                        }
                    });
                }
            }
        }
        /* Old terminal logic
        private void txtSshCommand_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.IsInputKey = true;
            }
        }

        private async void txtSshCommand_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_shellStream != null)
            {
                var character = e.KeyChar.ToString();
                await _shellStream.WriteAsync(new ReadOnlyMemory<byte>(Encoding.UTF8.GetBytes(character)));
                await _shellStream.FlushAsync();
            }
        }
        
        private async void txtSshCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (_shellStream != null)
            {
                
                switch (e.KeyCode)
                {
                    case Keys.Delete:
                        await _shellStream.WriteAsync(new ReadOnlyMemory<byte>(new[] { (byte)27, (byte)91, (byte)51, (byte)126 }));
                        await _shellStream.FlushAsync();
                        break;
                    case Keys.Up:
                        await _shellStream.WriteAsync(new ReadOnlyMemory<byte>(new[] { (byte)27, (byte)91, (byte)65 }));
                        await _shellStream.FlushAsync();
                        break;
                    case Keys.Down:
                        await _shellStream.WriteAsync(new ReadOnlyMemory<byte>(new[] { (byte)27, (byte)91, (byte)66 }));
                        await _shellStream.FlushAsync();
                        break;
                    case Keys.Right:
                        await _shellStream.WriteAsync(new ReadOnlyMemory<byte>(new[] { (byte)27, (byte)91, (byte)67 }));
                        await _shellStream.FlushAsync();
                        break;
                    case Keys.Left:
                        await _shellStream.WriteAsync(new ReadOnlyMemory<byte>(new[] { (byte)27, (byte)91, (byte)68 }));
                        await _shellStream.FlushAsync();
                        break;
                    case Keys.Home:
                        await _shellStream.WriteAsync(new ReadOnlyMemory<byte>(new[] { (byte)27, (byte)91, (byte)72 }));
                        await _shellStream.FlushAsync();
                        break;
                    case Keys.End:
                        await _shellStream.WriteAsync(new ReadOnlyMemory<byte>(new[] { (byte)27, (byte)91, (byte)70 }));
                        await _shellStream.FlushAsync();
                        break;
                    case Keys.PageDown:
                        await _shellStream.WriteAsync(new ReadOnlyMemory<byte>(new[] { (byte)27, (byte)91, (byte)54, (byte)126 }));
                        await _shellStream.FlushAsync();
                        break;
                    case Keys.PageUp:
                        await _shellStream.WriteAsync(new ReadOnlyMemory<byte>(new[] { (byte)27, (byte)91, (byte)53, (byte)126 }));
                        await _shellStream.FlushAsync();
                        break;
                    case Keys.F1:
                        await _shellStream.WriteAsync(new ReadOnlyMemory<byte>(new[] { (byte)27, (byte)79, (byte)80 }));
                        await _shellStream.FlushAsync();
                        break;
                    case Keys.F2:
                        await _shellStream.WriteAsync(new ReadOnlyMemory<byte>(new[] { (byte)27, (byte)79, (byte)81 }));
                        await _shellStream.FlushAsync();
                        break;
                    case Keys.F3:
                        await _shellStream.WriteAsync(new ReadOnlyMemory<byte>(new[] { (byte)27, (byte)79, (byte)82 }));
                        await _shellStream.FlushAsync();
                        break;
                    case Keys.F4:
                        await _shellStream.WriteAsync(new ReadOnlyMemory<byte>(new[] { (byte)27, (byte)79, (byte)83 }));
                        await _shellStream.FlushAsync();
                        break;
                    case Keys.F5:
                        await _shellStream.WriteAsync(new ReadOnlyMemory<byte>(new[] { (byte)27, (byte)91, (byte)49, (byte)53, (byte)126 }));
                        await _shellStream.FlushAsync();
                        break;
                    case Keys.F6:
                        await _shellStream.WriteAsync(new ReadOnlyMemory<byte>(new[] { (byte)27, (byte)91, (byte)49, (byte)55, (byte)126 }));
                        await _shellStream.FlushAsync();
                        break;
                    case Keys.F7:
                        await _shellStream.WriteAsync(new ReadOnlyMemory<byte>(new[] { (byte)27, (byte)91, (byte)49, (byte)56, (byte)126 }));
                        await _shellStream.FlushAsync();
                        break;
                    case Keys.F8:
                        await _shellStream.WriteAsync(new ReadOnlyMemory<byte>(new[] { (byte)27, (byte)91, (byte)50, (byte)57, (byte)126 }));
                        await _shellStream.FlushAsync();
                        break;
                    case Keys.F9:
                        await _shellStream.WriteAsync(new ReadOnlyMemory<byte>(new[] { (byte)27, (byte)91, (byte)50, (byte)48, (byte)126 }));
                        await _shellStream.FlushAsync();
                        break;
                    case Keys.F10:
                        await _shellStream.WriteAsync(new ReadOnlyMemory<byte>(new[] { (byte)27, (byte)91, (byte)50, (byte)49, (byte)126 }));
                        await _shellStream.FlushAsync();
                        break;
                    case Keys.F11:
                        await _shellStream.WriteAsync(new ReadOnlyMemory<byte>(new[] { (byte)27, (byte)91, (byte)50, (byte)51, (byte)126 }));
                        await _shellStream.FlushAsync();
                        break;
                    case Keys.F12:
                        await _shellStream.WriteAsync(new ReadOnlyMemory<byte>(new[] { (byte)27, (byte)91, (byte)50, (byte)52, (byte)126 }));
                        await _shellStream.FlushAsync();
                        break;
                }
                
            }
        }
        */

        private async void btnOsmUpload_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_osmToken) || !await OsmAuthenticated())
            {
                if (ToolkitMessageDialog.ShowDialog(
                        "OSM authentication is required, do you want to log in now?", this,
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    tcSettings.SelectedTab = tpSettings;
                    btnOsmTest.PerformClick();
                }

                return;
            }

            if (cmbDevices.SelectedItem is OpenpilotDevice openpilotDevice)
            {
                var uploadTasks = new List<Task>();
                foreach (var selectedItem in lbRoutes.SelectedItems)
                {
                    if (selectedItem is Route route)
                    {
                        var ucRoute = new ucTaskProgress(route.ToString(), route.Segments.Count)
                        {
                            Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top)
                        };

                        tlpTasks.Controls.Add(ucRoute);

                        var segmentsProcessed = 0;

                        var progress = new Progress<int>((segmentIndex) =>
                        {
                            if (!IsDisposed)
                            {
                                Interlocked.Increment(ref segmentsProcessed);
                                ucRoute.Progress = segmentsProcessed;
                            }
                        });

                        uploadTasks.Add(Task.Run(async () =>
                        {
                            var gpxFile = await openpilotDevice.GenerateGpxFileAsync(route, progress);
                            var gpxString = gpxFile.BuildString(new GpxWriterSettings());
                            var binaryFile = Encoding.ASCII.GetBytes(gpxString);

                            using (var content = new MultipartFormDataContent())
                            {
                                content.Add(new ByteArrayContent(binaryFile), "file", route.ToString());
                                content.Add(new StringContent(route.ToString() + " openpilot route"), @"description");
                                content.Add(new StringContent("openpilottoolkit,optk,openpilot,commai,comma2,comma3,comma3x"), @"tags");
                                content.Add(new StringContent("1"), @"public");
                                content.Add(new StringContent("identifiable"), @"visibility");

                                using (var response = await _osmHttpClient.PostAsync("api/0.6/gpx/create", content))
                                {

                                }
                            }
                        }));
                    }
                }

                if (uploadTasks.Count > 0)
                {
                    await Task.WhenAll(uploadTasks);
                }
            }
        }

        private readonly string _osmAuthUrl = @"https://www.openstreetmap.org/oauth2/authorize";
        private readonly string _osmAccessTokenUrl = @"https://www.openstreetmap.org/oauth2/token";
        private string _osmClientId = "YzFSUlFXdVZnb1VpSXBON3ltZlZWVmswTk1pSEZ2S0Voa19VazlaYTdvbw==";
        private string _osmClientSecret = "ZnBQVXhseHRUb2dEdUJyeXNwazNnTWJiQ1FIODM5SDdpRFcyWkI2SkI4bw==";
        private string _oauthCode = "";
        private string _osmToken = "";
        private ToolkitForm _loginDialog;

        private void BrowserOnLoadError(object sender, LoadErrorEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(e.FailedUrl))
            {
                var uri = new Uri(e.FailedUrl);
                if (uri.Authority.Equals("localhost:8008"))
                {
                    var oauthCode = HttpUtility.ParseQueryString(uri.Query).Get("code");
                    _oauthCode = oauthCode;

                    _loginDialog.Invoke(new MethodInvoker(() => { _loginDialog.Close(); }));
                }
            }
        }

        private void BrowserOnFrameLoadStart(object sender, FrameLoadStartEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(e.Url))
            {
                var uri = new Uri(e.Url);
                if (uri.Authority.Equals("localhost:8008"))
                {
                    var oauthCode = HttpUtility.ParseQueryString(uri.Query).Get("code");
                    _oauthCode = oauthCode;

                    _loginDialog.Invoke(new MethodInvoker(() => { _loginDialog.Close(); }));
                }
            }
        }

        private async Task<bool> OsmAuthenticated()
        {
            if (string.IsNullOrWhiteSpace(_osmToken))
            {
                return false;
            }

            if (_osmHttpClient == null)
            {
                var httpHandler = new HttpClientHandler { CookieContainer = new CookieContainer() };
                _osmHttpClient = new HttpClient(httpHandler, false)
                {
                    BaseAddress = new Uri(@"https://api.openstreetmap.org")
                };
                _osmHttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _osmToken);
            }

            using (var response = await _osmHttpClient.GetAsync("/api/0.6/user/details"))
            {
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        return false;
                    }
                    else
                    {
                        throw new Exception(response.ReasonPhrase);
                    }
                }
            }
        }

        private async void btnOsmTest_Click(object sender, EventArgs e)
        {
            btnOsmTest.Enabled = false;
            try
            {
                bool authenticated = false;
                try
                {
                    authenticated = await OsmAuthenticated();
                }
                catch (Exception exception)
                {
                    ToolkitMessageDialog.ShowDialog("Connection Failed: " + exception.Message);
                    return;
                }

                if (authenticated)
                {
                    ToolkitMessageDialog.ShowDialog("Connection Successful.");
                    return;
                }

                string redirectUrl = @"https://localhost:8008/";

                var loginUrl = string.Format(
                    "{0}?response_type=code&client_id={1}&redirect_uri={2}&scope={3}",
                    _osmAuthUrl, _osmClientId, redirectUrl, "write_gpx%20read_prefs");

                using (var browser = new ChromiumWebBrowser(loginUrl.ToString()))
                {
                    browser.FrameLoadStart += BrowserOnFrameLoadStart;
                    browser.LoadError += BrowserOnLoadError;

                    using (_loginDialog = new ToolkitForm())
                    {
                        _loginDialog.StartPosition = FormStartPosition.CenterParent;
                        _loginDialog.Text = "Openstreetmap Login";
                        _loginDialog.Size = new System.Drawing.Size(454, 798);
                        _loginDialog.MinimumSize = new System.Drawing.Size(454, 100);
                        _loginDialog.StartPosition = FormStartPosition.CenterScreen;
                        _loginDialog.Controls.Add(browser);
                        browser.Dock = DockStyle.Fill;
                        _loginDialog.ShowDialog(this);
                    }
                }

                if (!string.IsNullOrWhiteSpace(_oauthCode))
                {
                    var tokenPostData = new Dictionary<string, string>
                    {
                        { "grant_type", "authorization_code" },
                        { "code", _oauthCode },
                        { "redirect_uri", redirectUrl },
                        { "client_id",_osmClientId },
                        { "client_secret", _osmClientSecret }
                    };

                    try
                    {
                        if (_osmHttpClient == null)
                        {
                            var httpHandler = new HttpClientHandler { CookieContainer = new CookieContainer() };
                            _osmHttpClient = new HttpClient(httpHandler, false)
                            {
                                BaseAddress = new Uri(@"https://api.openstreetmap.org")
                            };
                        }

                        using (var content = new FormUrlEncodedContent(tokenPostData))
                        {
                            var response = await _osmHttpClient.PostAsync(_osmAccessTokenUrl, content);
                            if (response.IsSuccessStatusCode)
                            {
                                var jsonResponse = await response.Content.ReadAsStringAsync();
                                var osmResponse = JsonConvert.DeserializeObject<OsmTokenResponse>(jsonResponse);
                                _osmToken = osmResponse.AccessToken;
                                _osmHttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _osmToken);
                            }
                            else
                            {
                                ToolkitMessageDialog.ShowDialog("Failed to acquire access token: " + response.ReasonPhrase);
                                return;
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        ToolkitMessageDialog.ShowDialog("Connection Failed: " + exception.Message);
                        return;
                    }

                    try
                    {
                        using (var response = await _osmHttpClient.GetAsync("/api/0.6/user/details"))
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                ToolkitMessageDialog.ShowDialog("Connection Successful.");
                            }
                            else
                            {
                                if (response.StatusCode == HttpStatusCode.Unauthorized)
                                {
                                    ToolkitMessageDialog.ShowDialog("Invalid Username/Password.");
                                }
                                else
                                {
                                    ToolkitMessageDialog.ShowDialog("Connection Failed: " + response.ReasonPhrase);
                                }
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        ToolkitMessageDialog.ShowDialog("Connection Failed: " + exception.Message);
                    }
                }
            }
            finally
            {
                btnOsmTest.Enabled = true;
            }
        }

        private async void btnTmux_Click(object sender, EventArgs e)
        {
            _sshTerminal.Focus();
            if (_shellStream != null)
            {
                await _shellStream.WriteAsync(new ReadOnlyMemory<byte>(Encoding.UTF8.GetBytes("tmux a\n")));
                await _shellStream.FlushAsync();

            }
        }

        private async void btnExitTmux_Click(object sender, EventArgs e)
        {
            _sshTerminal.Focus();
            if (_shellStream != null)
            {
                await _shellStream.WriteAsync(new ReadOnlyMemory<byte>(Encoding.UTF8.GetBytes("`d")));
                await _shellStream.FlushAsync();
            }
        }

        private void txtExportFolder_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var path = txtExportFolder.Text.EndsWith(Path.DirectorySeparatorChar)
                    ? txtExportFolder.Text
                    : txtExportFolder.Text + Path.DirectorySeparatorChar;

                Process.Start(new ProcessStartInfo()
                {
                    FileName = path,
                    UseShellExecute = true,
                    Verb = "open"
                });
            }
            catch (Exception ex)
            {
                ToolkitMessageDialog.ShowDialog(ex.Message);
            }
        }

        private async void btnTmuxScroll_Click(object sender, EventArgs e)
        {
            _sshTerminal.Focus();
            if (_shellStream != null)
            {
                await _shellStream.WriteAsync(new ReadOnlyMemory<byte>(Encoding.UTF8.GetBytes("`[")));
                await _shellStream.FlushAsync();
            }
        }

        private async void btnTmuxEndScroll_Click(object sender, EventArgs e)
        {
            _sshTerminal.Focus();
            if (_shellStream != null)
            {
                await _shellStream.WriteAsync(new ReadOnlyMemory<byte>(Encoding.UTF8.GetBytes("q")));
                await _shellStream.FlushAsync();
            }
        }

        private void dgvExplorer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
            }
        }

        private DateTime _explorerLastKeyPressed;
        private readonly StringBuilder _explorerSearchString = new StringBuilder();

        private void dgvExplorer_KeyPress(object sender, KeyPressEventArgs e)
        {
            DateTime keyPressedTime = DateTime.UtcNow;
            if ((keyPressedTime - _explorerLastKeyPressed).TotalSeconds > 0.75)
            {
                _explorerSearchString.Clear();
            }

            _explorerLastKeyPressed = keyPressedTime;

            _explorerSearchString.Append(e.KeyChar);
            int i = 0;
            if (dgvExplorer.SelectedRows.Count > 0)
            {
                if (_explorerSearchString.Length < 2)
                {
                    if (dgvExplorer.SelectedRows[0].Index + 1 < dgvExplorer.Rows.Count)
                    {
                        i = dgvExplorer.SelectedRows[0].Index + 1;
                    }
                }
                else
                {
                    i = dgvExplorer.SelectedRows[0].Index;
                }
            }

            foreach (DataGridViewRow _ in dgvExplorer.Rows)
            {
                if (dgvExplorer.Rows[i].Cells["colName"].Value.ToString()
                    .StartsWith(_explorerSearchString.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    dgvExplorer.CurrentCell = dgvExplorer.Rows[i].Cells[0];
                    dgvExplorer.FirstDisplayedScrollingRowIndex = dgvExplorer.Rows[i].Index;
                    break;
                }

                i++;
                if (i >= dgvExplorer.Rows.Count)
                {
                    i = 0;
                }
            }
        }
        GitHubClient _githubClient = new GitHubClient(new Octokit.ProductHeaderValue("OpenpilotToolkit", "2.1.0"));
        private async void txtForkUsername_Leave(object sender, EventArgs e)
        {
            var repository = txtRepositoryName.Text;
            var githubUser = txtForkUsername.Text;
            if (string.IsNullOrWhiteSpace(repository))
            {
                repository = "openpilot";
            }

            if (string.IsNullOrWhiteSpace(githubUser))
            {
                githubUser = "commaai";
            }

            await UpdateForkBranches(githubUser, repository).ConfigureAwait(false);
        }
        
        private string _previousGithubUser = "";
        private string _previousGithubRepository = "";
        private async Task UpdateForkBranches(string githubUser, string repository)
        {
            if (_previousGithubRepository.Equals(repository, StringComparison.OrdinalIgnoreCase) &&  _previousGithubUser.Equals(githubUser, StringComparison.OrdinalIgnoreCase))
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(githubUser) || string.IsNullOrWhiteSpace(repository))
            {
                txtForkBranch.AutoCompleteCustomSource = null;
                return;
            }

            try
            {
                var branches = await _githubClient.Repository.Branch.GetAll(githubUser, repository);
                _previousGithubRepository = repository;
                _previousGithubUser = githubUser;
                var source = new AutoCompleteStringCollection();
                source.AddRange(branches.Select(branch => branch.Name).OrderByDescending(branch => branch).ToArray());
                txtForkBranch.AutoCompleteCustomSource = source;
            }
            catch (AuthorizationException exception)
            {
                _githubClient = new GitHubClient(new Octokit.ProductHeaderValue("OpenpilotToolkit", "2.1.0"));

                try
                {
                    var branches = await _githubClient.Repository.Branch.GetAll(githubUser, repository);
                    _previousGithubRepository = repository;
                    _previousGithubUser = githubUser;
                    var source = new AutoCompleteStringCollection();
                    source.AddRange(branches.Select(branch => branch.Name).OrderByDescending(branch => branch).ToArray());
                    txtForkBranch.AutoCompleteCustomSource = source;
                }
                catch (Exception e)
                {
                    txtForkBranch.AutoCompleteCustomSource = null;
                    Console.WriteLine(e);
                }
            }
            catch (Exception exception)
            {
                txtForkBranch.AutoCompleteCustomSource = null;
                Console.WriteLine(exception);
            }

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private bool autoScan = false;
        private void btnScan_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (!autoScan)
                {
                    btnScan.Text = "Scanning";
                    btnScan.EnableAnimation();
                    autoScan = true;
                }
                else
                {
                    btnScan.Text = "Scan For OP Devices";
                    btnScan.DisableAnimation();
                    autoScan = false;
                }
            }
        }

        private void cbSeekToKeyframes_CheckedChanged(object sender, EventArgs e)
        {
            flyleafVideoPlayer.SetSeekToKeyframesAsync(cbSeekToKeyframes.Checked).ConfigureAwait(false);
            Properties.Settings.Default.SeekToKeyframes = cbSeekToKeyframes.Checked;
        }
    }
}