using CefSharp;
using CefSharp.WinForms;
using LibVLCSharp.Shared;
using MaterialSkin;
using MaterialSkin.Controls;
using NetTopologySuite.IO;
using OpenpilotSdk.Git;
using OpenpilotSdk.Hardware;
using OpenpilotSdk.OpenPilot;
using OpenpilotSdk.OpenPilot.Fork;
using OpenpilotToolkit.Android;
using OpenpilotToolkit.Controls;
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
using System.Windows.Forms;
using Octokit;
using Renci.SshNet.Sftp;
using Exception = System.Exception;
using FileMode = System.IO.FileMode;
using OpenpilotDevice = OpenpilotSdk.Hardware.OpenpilotDevice;

namespace OpenpilotToolkit
{
    public partial class OpenpilotToolkitForm : MaterialForm
    {
        private ConcurrentDictionary<string, DateTime?> _watchedFiles = new ConcurrentDictionary<string, DateTime?>();
        private readonly string _tempExplorerFiles = Path.Combine(AppContext.BaseDirectory, "tmp", "explorer");
        private readonly ConcurrentDictionary<string,Task> _activeTaskList = new ConcurrentDictionary<string, Task>();
        private string _adbConnectedMessage = "Device in fastboot mode connected";
        private string _adbDisconnectedMessage = "Device in fastboot mode disconnected";
        private int _connectedFastbootDevices = 0;
        BindingList<OpenpilotDevice> _devices = new BindingList<OpenpilotDevice>();
        BindingList<Renci.SshNet.Sftp.SftpFile> _fileList = new BindingList<Renci.SshNet.Sftp.SftpFile>();
        private Stack<string> _workingDirectory = new Stack<string>();
        private LibVLC _libVlc = null;
        private ShellStream _shellStream = null;
        private StreamReader _streamReader = null;
        private SemaphoreSlim terminalLock = new SemaphoreSlim(1, 1);
        private ChromiumWebBrowser sshTerminal;

        public System.Drawing.Color ToColor(int argb)
        {
            return System.Drawing.Color.FromArgb(
                (argb & 0xFF0000) >> 16,
                (argb & 0x00FF00) >> 8,
                argb & 0x0000FF);
        }
        public OpenpilotToolkitForm()
        {
            InitializeComponent();

            this.tcSettings.Controls.Remove(this.tpFlash);
            this.tcSettings.Controls.Remove(this.tabPage1);

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = false;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Grey800, Primary.Grey900, Primary.LightBlue100, Accent.LightBlue400, TextShade.WHITE);

            themePanel.BackColor = materialSkinManager.ColorScheme.PrimaryColor;

            //tlpTasks.BackColor = MaterialSkinManager.Instance.BackgroundColor;
            lbDrives.BackColor = MaterialSkinManager.Instance.BackgroundColor;
            lbDrives.ForeColor = MaterialSkinManager.Instance.TextHighEmphasisColor;
        }

        private FileSystemWatcher _explorerFileWatcher = null;

        private async void Form1_Load(object sender, EventArgs e)
        {
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

            tlpTasks.Padding = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth-1, 0);
            tlpExplorerTasks.Padding = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth - 1, 0);

            var terminalPath = Path.Combine(AppContext.BaseDirectory, @"Controls\Terminal\index.html");
            sshTerminal =
                new ChromiumWebBrowser(terminalPath);
            
            //Terminal messages from C# instead of webbrowser
            //sshTerminal.KeyboardHandler = new TerminalKeyboardHandler();
            //sshTerminal.PreviewKeyDown += txtSshCommand_PreviewKeyDown;
            //sshTerminal.KeyPress += txtSshCommand_KeyPress;
            //sshTerminal.KeyDown += txtSshCommand_KeyDown;

            sshTerminal.JavascriptObjectRepository.Register("sshHost", this, BindingOptions.DefaultBinder);
            sshTerminal.Dock = DockStyle.Fill;
            sshTerminal.CreateControl();
            sshTerminal.JavascriptMessageReceived += SshTerminal_JavascriptMessageReceived;

            this.tableLayoutPanel1.Controls.Add(sshTerminal, 0, 0);

            _libVlc = new LibVLC();
            vlcVideoPlayer.Initialize(_libVlc);
            vlcVideoPlayer.vlcVideoView1.MediaPlayer.TimeChanged += MediaPlayerOnTimeChanged; 
  
            cbCombineSegments.Checked = Properties.Settings.Default.CombineSegments;

            cbFrontCamera.Checked = Properties.Settings.Default.FrontCamera;
            cbWideCamera.Checked = Properties.Settings.Default.WideCamera;
            cbDriverCamera.Checked = Properties.Settings.Default.DriverCamera;

            txtOsmUsername.Text = Properties.Settings.Default.OsmUsername;
            txtOsmPassword.Text = Properties.Settings.Default.OsmPassword;

            foreach (PropertyInfo property in MaterialSkinManager.Instance.GetType().GetProperties())
            {
                if(property.Name.EndsWith("Color"))
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
            
            themePanel.Height = this.DrawerTabControl.Height;

            SetTheme(Properties.Settings.Default.DarkMode);
            txtExportFolder.Text = Properties.Settings.Default.ExportFolder;

            var devices = Fastboot.GetDevices();
            _connectedFastbootDevices = devices.Length;
            if (devices.Any())
            {
                var message = new MaterialSnackBar(_adbConnectedMessage, "OK", false);
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

                if(devices.Length > _connectedFastbootDevices)
                {
                    BeginInvoke(new MethodInvoker(() =>
                    {
                        adbConnected.SetEnabled(true);
                        var message = new MaterialSnackBar(_adbConnectedMessage, "OK", false);
                        message.Show(this);
                    }));
                    
                }
                else if (devices.Length < _connectedFastbootDevices)
                {
                    BeginInvoke(new MethodInvoker(() =>
                    {
                        adbConnected.SetEnabled(false);
                        var message = new MaterialSnackBar(_adbDisconnectedMessage, "OK", false);
                        message.Show(this);
                    }));
                }

                _connectedFastbootDevices = devices.Length;
            };
            watcher.Query = query;
            watcher.Start();
            
            //flowLayoutPanel1.HorizontalScroll.Visible = false;

            await ScanDevices();
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
                                                    if(progress != previousProgress)
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

        private void MediaPlayerOnTimeChanged(object sender, MediaPlayerTimeChangedEventArgs e)
        {
            if (vlcVideoPlayer.Parent.Controls.GetChildIndex(vlcVideoPlayer) != 0 && e.Time > 100)
            {
                BeginInvoke(new MethodInvoker(() => { vlcVideoPlayer.BringToFront(); }));
            }
        }

        private async Task ScanDevices()
        {
            _devices.Clear();
            lbDrives.Items.Clear();
            Task.Run(() =>
            {
                vlcVideoPlayer.vlcVideoView1.MediaPlayer.Stop();
                vlcVideoPlayer.vlcVideoView2.MediaPlayer.Stop();
            });
            dgvDriveInfo.DataSource = null;
            pbPreview.Image = null;
            pbPreview.BringToFront();
            wifiConnected.SetEnabled(false);
            btnScan.Enabled = false;

            try
            {
                int foundDevices = 0;
                await Task.Run(async () =>
                {
                    await foreach (var device in OpenpilotDevice.DiscoverAsync())
                    {
                        foundDevices++;
                        Invoke(new MethodInvoker(() =>
                        {
                            if (device.IsAuthenticated && !_devices.Contains(device))
                            {
                                _devices.Add(device);
                                if (_devices.Count == 1)
                                {
                                    wifiConnected.SetEnabled(true);
                                    cmbDevices.SelectedIndex = -1;
                                    cmbDevices.SelectedIndex = 0;
                                }
                            }
                        }));
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
            await ScanDevices();
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
                    if(openpilotDevice.Cameras.ContainsKey(CameraType.Front))
                    {
                        cameras.Add(openpilotDevice.Cameras[CameraType.Front]);
                    }
                }
                if (cbWideCamera.Checked)
                {
                    if (openpilotDevice.Cameras.ContainsKey(CameraType.Wide))
                    {
                        cameras.Add(openpilotDevice.Cameras[CameraType.Wide]);
                    }
                }
                if (cbDriverCamera.Checked)
                {
                    if (openpilotDevice.Cameras.ContainsKey(CameraType.Driver))
                    {
                        cameras.Add(openpilotDevice.Cameras[CameraType.Driver]);
                    }
                }

                if (cameras.Count < 1)
                {
                    ToolkitMessageDialog.ShowDialog("You must select at least 1 camera to export.");
                    return;
                }

                foreach (var selectedItem in lbDrives.SelectedItems)
                {
                    if (selectedItem is Drive drive)
                    {
                        if (_activeTaskList.ContainsKey(drive.Date.ToString()))
                        {
                            continue;
                        }

                        var ucDrive = new ucTaskProgress(drive.ToString(), cameras.Count * 100)
                        {
                            Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top)
                        };
                        
                        tlpTasks.Controls.Add(ucDrive);

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
                                    if (currentProgress > ucDrive.Progress)
                                    {
                                        ucDrive.Progress = currentProgress;
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
                                await openpilotDevice.ExportDriveAsync(exportFolder, drive, camera, cbCombineSegments.Checked,
                                    progress);
                            });

                        });
                        exportTasks.Add(new Tuple<string, Task>(drive.Date.ToString(), task));
                        _activeTaskList.TryAdd(drive.Date.ToString(), task);
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
                        Serilog.Log.Error(exception, "Error exporting drive.");
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
            var item = cmbDevices.SelectedItem;
            if (item is OpenpilotDevice openpilotDevice)
            {
                lbDrives.Items.Clear();
                lbDrives.Items.Add("Loading...");

                await Task.Run(async () =>
                {
                    BeginInvoke(new MethodInvoker(() => { lbDrives.Items.Clear(); }));
                    
                    await foreach (var drive in openpilotDevice.GetDrivesAsync())
                    {
                        BeginInvoke(new MethodInvoker(() =>
                        {
                            lbDrives.Items.Add(drive);
                            if (lbDrives.Items.Count == 1)
                            {
                                lbDrives.SelectedIndex = 0;
                            }
                        }));
                    }
                });
            }
        }

        private async void lbDrives_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDevices.Enabled = false;
            
            dgvDriveInfo.DataSource = null;
            Task.Run(() =>
            {
                vlcVideoPlayer.vlcVideoView1.MediaPlayer.Stop();
                vlcVideoPlayer.vlcVideoView2.MediaPlayer.Stop();
            });
            pbPreview.Image = null;
            pbPreview.BringToFront();

            try
            {
                if (cmbDevices.SelectedItem is OpenpilotDevice openpilotDevice)
                {
                    if (lbDrives.SelectedItems.Count < 2 && lbDrives.SelectedItem is Drive drive)
                    {
                        var driveInfo = new Dictionary<string, string>();
                        driveInfo.Add("Segments", drive.Segments.Count.ToString());
                        driveInfo.Add("Start Date", drive.Date.ToLocalTime().ToShortDateString());
                        driveInfo.Add("Start Time", drive.Date.ToLocalTime().ToLongTimeString());

                        dgvDriveInfo.DataSource = driveInfo.ToArray();
                        try
                        {
                            var firstSegment = drive.Segments.FirstOrDefault();

                            if (firstSegment != null)
                            {
                                var videoFile = firstSegment.FrontVideoQuick ?? firstSegment.FrontVideo;

                                if (videoFile != null)
                                {
                                    await Task.Run(async () =>
                                    {
                                        var thumbnailTask = openpilotDevice.GetThumbnailAsync(drive);

                                        Task<Renci.SshNet.Sftp.SftpFileStream> videoStreamTask = null;
                                        List<SftpFileStream> videoStreams;
                                        if (firstSegment.FrontVideoQuick != null)
                                        {
                                            videoStreams = drive.Segments.Select(async (segment) =>
                                                await openpilotDevice.OpenReadAsync(segment.FrontVideoQuick.File
                                                    .FullName)).Select(t => t.Result).ToList();
                                        }
                                        else
                                        {
                                            videoStreams = drive.Segments.Select(async (segment) =>
                                                await openpilotDevice.OpenReadAsync(segment.FrontVideo.File
                                                    .FullName)).Select(t => t.Result).ToList();
                                        }
                                        vlcVideoPlayer.Play(videoStreams);
                                        System.Drawing.Bitmap thumbnail = await thumbnailTask;
                                        BeginInvoke(new MethodInvoker(() => { pbPreview.Image = thumbnail; }));
                                    });
                                }
                            }
                        }
                        catch (Exception exception)
                        {
                            Serilog.Log.Error(exception, "Error getting drive preview");
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

            Properties.Settings.Default.FrontCamera = cbFrontCamera.Checked;
            Properties.Settings.Default.WideCamera = cbWideCamera.Checked;
            Properties.Settings.Default.DriverCamera = cbDriverCamera.Checked;

            Properties.Settings.Default.OsmUsername = txtOsmUsername.Text;
            Properties.Settings.Default.OsmPassword = txtOsmPassword.Text;

            Properties.Settings.Default.Save();
        }

        private HttpClient _osmHttpClient;
        private async void btnExportGpx_Click(object sender, EventArgs e)
        {
            if (cmbDevices.SelectedItem is OpenpilotDevice openpilotDevice)
            {
                var exportTasks = new List<Task>();
                foreach (var selectedItem in lbDrives.SelectedItems)
                {
                    if (selectedItem is Drive drive)
                    {
                        var exportFolder = txtExportFolder.Text;

                        var ucDrive = new ucTaskProgress(drive.ToString(),drive.Segments.Count)
                        {
                            Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top)
                        };

                        tlpTasks.Controls.Add(ucDrive);

                        var segmentsProcessed = 0;

                        var progress = new Progress<int>((segmentIndex) =>
                        {
                            if (!IsDisposed)
                            {
                                Interlocked.Increment(ref segmentsProcessed);
                                ucDrive.Progress = segmentsProcessed;
                            }
                        });

                        exportTasks.Add(Task.Run(async () =>
                        {
                            var fileName = Path.Combine(exportFolder, drive + ".gpx");
                            var gpxFile = await openpilotDevice.GenerateGpxFileAsync(drive, progress);
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

        private void ExportFrames(string exportFolder, Drive drive, string selectStatement, int startNumber)
        {
            var cmd = @" -framerate 20 -i " + '"' +
                      Path.Combine(exportFolder, drive.Date.ToShortDateString() + ".hevc") + '"' +
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
                if (lbDrives.SelectedItem is Drive drive)
                {
                    if (_activeTaskList.ContainsKey(drive.Date.ToString()))
                    {
                        return;
                    }
                    //MessageBox.Show("Exporting Drive: " + drive.Id);
                    var exportFolder = txtExportFolder.Text;

                    var ucDrive = new ucTaskProgress(drive.ToString(), drive.Segments.Count)
                    {
                        Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top)
                    };

                    tlpTasks.Controls.Add(ucDrive);

                    var segmentsProcessed = 0;

                    var progress = new Progress<int>((segmentIndex) =>
                    {
                        if (!IsDisposed)
                        {
                            Interlocked.Increment(ref segmentsProcessed);
                            ucDrive.Progress = segmentsProcessed; ;
                        }
                    });
                    
                    var task = Task.Run(async () =>
                    {
                        //TODO:
                        //await openpilotDevice.ExportDriveAsync(exportFolder, drive, cbCombineSegments.Checked, progress);
                    });
                    
                    _activeTaskList.TryAdd(drive.Date.ToString(), task);
                    await task;
                    _activeTaskList.TryRemove(drive.Date.ToString(), out _);

                    var waypoints = await openpilotDevice.MapillaryExportAsync(drive);

                    var firstTime = waypoints.First().TimestampUtc.Value;
                    

                    int count = 0;
                    int startNumber = 1;
                    var frames = string.Join("+",
                        waypoints.Select(wp =>
                            @"eq(n\," + (int) (((wp.TimestampUtc.Value - firstTime).TotalMilliseconds) / 50) + ")"));
                    ExportFrames(exportFolder, drive, frames, 0);
                    
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

            lbDrives.BackColor = MaterialSkinManager.Instance.BackgroundColor;
            lbDrives.ForeColor = MaterialSkinManager.Instance.TextHighEmphasisColor;
            groupBox1.ForeColor = MaterialSkinManager.Instance.TextHighEmphasisColor;
            groupBox2.ForeColor = MaterialSkinManager.Instance.TextHighEmphasisColor;
            groupBox3.ForeColor = MaterialSkinManager.Instance.TextHighEmphasisColor;
            groupBox4.ForeColor = MaterialSkinManager.Instance.TextHighEmphasisColor;
        }

        private void themeButton_Click(object sender, EventArgs e)
        {
            SetTheme(MaterialSkinManager.Instance.Theme == MaterialSkinManager.Themes.LIGHT);
        }

        private OpenpilotDevice _lastExplorerDevice = null;
        private async void tcSettings_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage != null)
            {
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
                                sb.AppendLine(string.Format("fwVersion = {0}", firmware.Version));
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

                            await sshTerminal.EvaluateScriptAsync("ClearTerminal()");

                            await Task.Run(async () =>
                            {
                                _shellStream = await openpilotDevice.GetShellStreamAsync();
                                _streamReader = new StreamReader(_shellStream);
                            });
                            await sshTerminal.EvaluateScriptAsync("resizeTerminal()");
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
            await terminalLock.WaitAsync();
            try
            {
                if (_shellStream.DataAvailable)
                {
                    var terminalText = await _streamReader.ReadToEndAsync();
                    Invoke(new MethodInvoker(async () =>
                    {
                        await sshTerminal.EvaluateScriptAsync("WriteText", new object[] { terminalText });
                    }));
                }
            }
            finally
            {
                terminalLock.Release();
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
                    if(fileName == "..")
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
                if (!(selectedItem.IsDirectory && !selectedItem.IsRegularFile))
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
            Process.Start("explorer.exe","https://ko-fi.com/spektor56");
        }

        private void btnPaypal_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "https://paypal.me/spektor56");
        }

        private void btnBuyMeCoffee_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "https://www.buymeacoffee.com/spektor56");
        }

        private void OpenpilotToolkitForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cef.Shutdown();
        }

        private async void btnInstallFork_Click(object sender, EventArgs e)
        {
            btnInstallFork.Enabled = false;
            try
            {
                var forkUser = txtForkUsername.Text;
                var forkBranch = txtForkBranch.Text;

                if (string.IsNullOrWhiteSpace(forkUser))
                {
                    ToolkitMessageDialog.ShowDialog("Fork Username is Required", this);
                    return;
                }

                if (string.IsNullOrWhiteSpace(forkBranch))
                {
                    ToolkitMessageDialog.ShowDialog("Fork Branch is Required", this);
                    return;
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
                                openpilotDevice.InstallForkAsync(forkUser, forkBranch, progress).ConfigureAwait(false);
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
        private async void cmbDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = cmbDevices.SelectedItem;
            if (item is OpenpilotDevice openpilotDevice)
            {

                try
                {


                    await Task.Run(async () =>
                    {
                        await openpilotDevice.ConnectAsync();

                        BeginInvoke(new MethodInvoker(() =>
                        {
                            lbDrives.Items.Clear();
                            lbDrives.Items.Add("Loading...");
                        }));

                        
                        BeginInvoke(new MethodInvoker(() => { lbDrives.Items.Clear(); }));
                        
                        await foreach (var drive in openpilotDevice.GetDrivesAsync())
                        {
                      
                            BeginInvoke(new MethodInvoker(() =>
                            {
                                lbDrives.Items.Add(drive);
                                if (lbDrives.Items.Count == 1)
                                {
                                    lbDrives.SelectedIndex = 0;
                                }
                            }));
                           
                        }
                    });
                }
                catch (Exception exception)
                {
                    Serilog.Log.Error(exception, "Error retrieving drive");
                    ToolkitMessageDialog.ShowDialog(exception.Message);
                    return;
                }

            }
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
                    if(data is String[] files)
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

        private async void btnDeleteDrives_Click(object sender, EventArgs e)
        {
            if (cmbDevices.SelectedItem is OpenpilotDevice openpilotDevice)
            {
                var selectedItems = lbDrives.SelectedItems;
                if (selectedItems.Count > 0)
                {
                    if (ToolkitMessageDialog.ShowDialog($"Are you sure you want to delete {selectedItems.Count} drives(s): {Environment.NewLine + string.Join(Environment.NewLine, selectedItems.Cast<object>().Where(item => item is Drive).Select(row => row.ToString()))}", this, MessageBoxButtons.YesNo) != DialogResult.Yes)
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }

                await Task.Run(async () => {
                    var deleteTasks = new Dictionary<Drive, Task>();
                    foreach (var selectedItem in selectedItems)
                    {
                        if (selectedItem is Drive drive)
                        {
                            if (_activeTaskList.ContainsKey(drive.Date.ToString()))
                            {
                                continue;
                            }

                            deleteTasks.Add(drive, openpilotDevice.DeleteDriveAsync(drive));
                        }
                    }

                    foreach (var deleteTask in deleteTasks)
                    {
                        await deleteTask.Value;
                        BeginInvoke(new MethodInvoker(() =>
                        {
                            lbDrives.Items.Remove(deleteTask.Key);
                        }));
                    }
                });
            }
        }

        private async void lbDrives_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (cmbDevices.SelectedItem is OpenpilotDevice openpilotDevice)
                {
                    var selectedItems = lbDrives.SelectedItems;
                    if (selectedItems.Count > 0)
                    {
                        if (ToolkitMessageDialog.ShowDialog($"Are you sure you want to delete {selectedItems.Count} drives(s): {Environment.NewLine + string.Join(Environment.NewLine, selectedItems.Cast<object>().Where(item => item is Drive).Select(row => row.ToString()))}", this, MessageBoxButtons.YesNo) != DialogResult.Yes)
                        {
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }

                    await Task.Run(async () => {
                        var deleteTasks = new Dictionary<Drive, Task>();
                        foreach (var selectedItem in selectedItems)
                        {
                            if (selectedItem is Drive drive)
                            {
                                if (_activeTaskList.ContainsKey(drive.Date.ToString()))
                                {
                                    continue;
                                }

                                deleteTasks.Add(drive, openpilotDevice.DeleteDriveAsync(drive));
                            }
                        }

                        foreach (var deleteTask in deleteTasks)
                        {
                            await deleteTask.Value;
                            BeginInvoke(new MethodInvoker(() =>
                            {
                                lbDrives.Items.Remove(deleteTask.Key);
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
            var osmUsername = txtOsmUsername.Text;
            var osmPassword = txtOsmPassword.Text;
            if (string.IsNullOrWhiteSpace(osmUsername) || string.IsNullOrWhiteSpace(osmPassword))
            {
                if (ToolkitMessageDialog.ShowDialog(
                        "OSM username and password is required, do you want to enter them now?", this,
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    tcSettings.SelectedTab = tpSettings;
                }

                return;
            }


            if (cmbDevices.SelectedItem is OpenpilotDevice openpilotDevice)
            {
                if (_osmHttpClient == null)
                {
                    var httpHandler = new HttpClientHandler { CookieContainer = new CookieContainer() };
                    _osmHttpClient = new HttpClient(httpHandler, false)
                    {
                        BaseAddress = new Uri(@"https://api.openstreetmap.org")
                    };
                }

                _osmHttpClient.DefaultRequestHeaders.Clear();
                _osmHttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(
                        Encoding.ASCII.GetBytes(string.Format("{0}:{1}", osmUsername, osmPassword))));
                _osmHttpClient.DefaultRequestHeaders.Accept.Clear();
                _osmHttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    using (var response = await _osmHttpClient.GetAsync("/api/0.6/user/details"))
                    {
                        if (!response.IsSuccessStatusCode)
                        {
                            if (response.StatusCode == HttpStatusCode.Unauthorized)
                            {
                                ToolkitMessageDialog.ShowDialog("Invalid Username/Password.");
                                return;
                            }

                            ToolkitMessageDialog.ShowDialog("Connection Failed: " + response.ReasonPhrase);
                            return;
                        }
                    }
                }
                catch (Exception exception)
                {
                    ToolkitMessageDialog.ShowDialog("Connection Failed: " + exception.Message);
                    return;
                }

                var uploadTasks = new List<Task>();
                foreach (var selectedItem in lbDrives.SelectedItems)
                {
                    if (selectedItem is Drive drive)
                    {
                        var ucDrive = new ucTaskProgress(drive.ToString(), drive.Segments.Count)
                        {
                            Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top)
                        };

                        tlpTasks.Controls.Add(ucDrive);

                        var segmentsProcessed = 0;

                        var progress = new Progress<int>((segmentIndex) =>
                        {
                            if (!IsDisposed)
                            {
                                Interlocked.Increment(ref segmentsProcessed);
                                ucDrive.Progress = segmentsProcessed;
                            }
                        });

                        uploadTasks.Add(Task.Run(async () =>
                        {
                            var gpxFile = await openpilotDevice.GenerateGpxFileAsync(drive, progress);
                            var gpxString = gpxFile.BuildString(new GpxWriterSettings());
                            var binaryFile = Encoding.ASCII.GetBytes(gpxString);

                            using (var content = new MultipartFormDataContent())
                            {
                                content.Add(new ByteArrayContent(binaryFile), "file", drive.ToString());
                                content.Add(new StringContent(drive.ToString() + " openpilot drive"), @"description");
                                content.Add(new StringContent("openpilottoolkit,optk,openpilot,commai,comma2,comma3"), @"tags");
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

        private async void btnOsmTest_Click(object sender, EventArgs e)
        {
            btnOsmTest.Enabled = false;
            try
            {
                var osmUsername = txtOsmUsername.Text;
                var osmPassword = txtOsmPassword.Text;

                if (_osmHttpClient == null)
                {
                    var httpHandler = new HttpClientHandler { CookieContainer = new CookieContainer() };
                    _osmHttpClient = new HttpClient(httpHandler, false)
                    {
                        BaseAddress = new Uri(@"https://api.openstreetmap.org")
                    };
                }

                _osmHttpClient.DefaultRequestHeaders.Clear();
                _osmHttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(
                        Encoding.ASCII.GetBytes(string.Format("{0}:{1}", osmUsername, osmPassword))));
                _osmHttpClient.DefaultRequestHeaders.Accept.Clear();
                _osmHttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
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
            finally
            {
                btnOsmTest.Enabled = true;
            }
        }

        private async void btnTmux_Click(object sender, EventArgs e)
        {
            sshTerminal.Focus();
            if (_shellStream != null)
            {
                await _shellStream.WriteAsync(new ReadOnlyMemory<byte>(Encoding.UTF8.GetBytes("tmux a\n")));
                await _shellStream.FlushAsync();
                
            }
        }

        private async void btnExitTmux_Click(object sender, EventArgs e)
        {
            sshTerminal.Focus();
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
            catch(Exception ex)
            {
                ToolkitMessageDialog.ShowDialog(ex.Message);
            }
        }

        private async void btnTmuxScroll_Click(object sender, EventArgs e)
        {
            sshTerminal.Focus();
            if (_shellStream != null)
            {
                await _shellStream.WriteAsync(new ReadOnlyMemory<byte>(Encoding.UTF8.GetBytes("`[")));
                await _shellStream.FlushAsync();
            }
        }

        private async void btnTmuxEndScroll_Click(object sender, EventArgs e)
        {
            sshTerminal.Focus();
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
        readonly GitHubClient _githubClient = new GitHubClient(new Octokit.ProductHeaderValue("OpenpilotToolkit", "2.1.0"));
        private async void txtForkUsername_Leave(object sender, EventArgs e)
        {
            try
            {
                var branches = await _githubClient.Repository.Branch.GetAll(txtForkUsername.Text, "openpilot");
                var source = new AutoCompleteStringCollection();
                source.AddRange(branches.Select(branch => branch.Name).OrderByDescending(branch => branch).ToArray());
                txtForkBranch.AutoCompleteCustomSource = source;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
}