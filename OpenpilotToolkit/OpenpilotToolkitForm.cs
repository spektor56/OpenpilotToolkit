using System;
using System.Collections;
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
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
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
using OpenpilotToolkit.Json;
using Renci.SshNet;
using Renci.SshNet.Common;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Metadata.Profiles.Exif;
using Color = System.Drawing.Color;
using Image = SixLabors.ImageSharp.Image;
using OpenpilotDevice = OpenpilotSdk.Hardware.OpenpilotDevice;

namespace OpenpilotToolkit
{
    public partial class OpenpilotToolkitForm : MaterialForm
    {
        private readonly ConcurrentDictionary<string,Task> _activeTaskList = new ConcurrentDictionary<string, Task>();
        private string _adbConnectedMessage = "Device in fastboot mode connected";
        private string _adbDisconnectedMessage = "Device in fastboot mode disconnected";
        private int _connectedFastbootDevices = 0;
        BindingList<OpenpilotDevice> _devices = new BindingList<OpenpilotDevice>();
        BindingList<Renci.SshNet.Sftp.SftpFile> _fileList = new BindingList<Renci.SshNet.Sftp.SftpFile>();
        private Stack<string> _workingDirectory = new Stack<string>();
        private LibVLC _libVlc = null;
        private ShellStream _shellStream = null;

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

        

        private async void Form1_Load(object sender, EventArgs e)
        {
            _libVlc = new LibVLC();
            vlcVideoPlayer.Initialize(_libVlc);
            vlcVideoPlayer.vlcVideoView.MediaPlayer.TimeChanged += MediaPlayerOnTimeChanged; 
  
            cbCombineSegments.Checked = Properties.Settings.Default.CombineSegments;

            cbFrontCamera.Checked = Properties.Settings.Default.FrontCamera;
            cbWideCamera.Checked = Properties.Settings.Default.WideCamera;
            cbDriverCamera.Checked = Properties.Settings.Default.DriverCamera;

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
                Debug.Print("IN HERE");
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
            vlcVideoPlayer.vlcVideoView.MediaPlayer.Stop();
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
                    cameras.Add(Camera.Front);
                }
                if (cbWideCamera.Checked)
                {
                    cameras.Add(Camera.Wide);
                }
                if (cbDriverCamera.Checked)
                {
                    cameras.Add(Camera.Driver);
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

                        var ucDrive = new ucTaskProgress(drive.Date.ToString(), drive.Segments.Count*cameras.Count)
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

                        var task = Task.Run(async () =>
                        {
                            var cameraTask = new List<Task>();
                            foreach (var camera in cameras)
                            {
                                cameraTask.Add(openpilotDevice.ExportDriveAsync(exportFolder, drive, camera, cbCombineSegments.Checked, progress));
                            }

                            await Task.WhenAll(cameraTask);

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

                await Task.Run(() =>
                {
                    var drives = openpilotDevice.GetDrives();
                    BeginInvoke(new MethodInvoker(() => { lbDrives.Items.Clear(); }));
                    foreach (var drive in drives)
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
            try
            {
                if (cmbDevices.SelectedItem is OpenpilotDevice openpilotDevice)
                {
                    if (lbDrives.SelectedItems.Count < 2 && lbDrives.SelectedItem is Drive drive)
                    {
                        vlcVideoPlayer.vlcVideoView.MediaPlayer.Stop();
                        pbPreview.Image = null;
                        pbPreview.BringToFront();
                        try
                        {
                            await Task.Run(async () =>
                            {
                                var thumbnail = await openpilotDevice.GetThumbnailAsync(drive);
                                BeginInvoke(new MethodInvoker(() => { pbPreview.Image = thumbnail; }));
                                var firstSegment = drive.Segments.FirstOrDefault();
                                if (firstSegment != null)
                                {
                                    var videoFile = firstSegment.FrontCameraQuick ?? firstSegment.FrontCamera;
                                    if (videoFile != null)
                                    {
                                        var fs = openpilotDevice.OpenRead(drive.Segments.First().FrontCameraQuick.FullName);
                                        vlcVideoPlayer.Play(fs);
                                    }

                                }
                            });
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

            Properties.Settings.Default.Save();


        }

        private HttpClient _client;
        private async void btnExportGpx_Click(object sender, EventArgs e)
        {
            var httpHandler = new HttpClientHandler { CookieContainer = new CookieContainer() };
            _client = new HttpClient(httpHandler, false)
            {
                BaseAddress = new Uri(@"https://api.openstreetmap.org")
            };
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(
                    Encoding.ASCII.GetBytes(string.Format("{0}:{1}", @"username", @"password"))));
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            

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

                    var ucDrive = new ucTaskProgress(drive.Date.ToString(), drive.Segments.Count)
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
                        var fileName = Path.Combine(exportFolder, drive.Date.ToShortDateString() + ".gpx");
                        var gpxFile = await openpilotDevice.GenerateGpxFileAsync(drive, progress);
                        var gpxString = gpxFile.BuildString(new GpxWriterSettings());
                        var binaryFile = Encoding.ASCII.GetBytes(gpxString);

                        using (var content = new MultipartFormDataContent())
                        {
                            content.Add(new ByteArrayContent(binaryFile), "file", drive.Date.ToString());
                            content.Add(new StringContent(drive.Date.ToString() + " openpilot drive"), @"description");
                            content.Add(new StringContent("openpilot,commai,comma2"), @"tags");
                            content.Add(new StringContent("1"), @"public");
                            content.Add(new StringContent("identifiable"), @"visibility");

                            using (var response = await _client.PostAsync("api/0.6/gpx/create", content))
                            {
                                
                            }
                        }

                        File.WriteAllText(fileName, gpxString);
                    });
                    _activeTaskList.TryAdd(drive.Date.ToString(), task);
                    await task;
                    _activeTaskList.TryRemove(drive.Date.ToString(), out _);


                    
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

                    var ucDrive = new ucTaskProgress(drive.Date.ToString(), drive.Segments.Count)
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
                    */
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

                }
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (fbdExportFolder.ShowDialog() == DialogResult.OK)
                txtExportFolder.Text = fbdExportFolder.SelectedPath;
        }

        public async void SetTheme(bool darkMode)
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
        }

        private void themeButton_Click(object sender, EventArgs e)
        {
            SetTheme(MaterialSkinManager.Instance.Theme == MaterialSkinManager.Themes.LIGHT);
        }

        private async void tcSettings_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage != null && e.TabPage == tpLogFile)
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
            else if (e.TabPage != null && e.TabPage == tpExplore)
            {
                _workingDirectory.Clear();
                if (cmbDevices.SelectedItem is OpenpilotDevice openpilotDevice)
                {
                    //TODO: _fileList = comma2.EnumerateFileSystemEntries

                    txtWorkingDirectory.Text = openpilotDevice.WorkingDirectory;
                    IEnumerable<Renci.SshNet.Sftp.SftpFile> files = null;

                    var directories = openpilotDevice.WorkingDirectory.Split("/");
                    foreach (var directory in directories)
                    {
                        _workingDirectory.Push(directory);
                    }

                    await Task.Run(() =>
                    {
                        var currentWorkingDirectory = string.Join("/", _workingDirectory.Reverse());
                        files = openpilotDevice.EnumerateFiles(currentWorkingDirectory);
                    });
                    dgvExplorer.DataSource = files.OrderBy(file => file.Name).ToArray();
                }
                
            }
            else if (e.TabPage != null && e.TabPage == tpFingerprint)
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
            else if (e.TabPage != null && e.TabPage == tpShell)
            {

                if (cmbDevices.SelectedItem is OpenpilotDevice openpilotDevice)
                {
                    txtTerminalText.Clear();
                    try
                    {
                        await Task.Run(() =>
                        {
                            _shellStream = openpilotDevice.GetShellStream();
                            _streamReader = new StreamReader(_shellStream);
                        });

                        _shellStream.DataReceived += ShellStreamOnDataReceived;
                    }
                    catch (Exception ex)
                    {
                        Serilog.Log.Error(ex, "Failed to create shell stream.");
                    }
                    
                }
            }
        }

        private Regex _ansiColor = new Regex(@"\[[^m]+m", RegexOptions.Compiled);
        private StreamReader _streamReader = null;
        private SemaphoreSlim terminalLock = new SemaphoreSlim(1, 1);

        private async void ShellStreamOnDataReceived(object? sender, ShellDataEventArgs e)
        {
            await terminalLock.WaitAsync();
            try
            {
                if (_shellStream.DataAvailable)
                {


                    var terminalText = await _streamReader.ReadToEndAsync();
                    terminalText = _ansiColor.Replace(terminalText, "");
                    Invoke(new MethodInvoker(() =>
                    {
                        txtTerminalText.AppendText(terminalText);
                        
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

        private void materialButton2_Click(object sender, EventArgs e)
        {

        }

        private void themePanel_Paint(object sender, PaintEventArgs e)
        {

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
            if (dgvExplorer.SelectedRows.Count < 1)
            {
                return;
            }

            if (cmbDevices.SelectedItem is OpenpilotDevice openpilotDevice)
            {
                var selectedRow = dgvExplorer.SelectedRows[0];
                var selectedItem = ((Renci.SshNet.Sftp.SftpFile)selectedRow.DataBoundItem);
                if(!(selectedItem.IsDirectory && !selectedItem.IsRegularFile))
                {
                    return;
                }
                var path = selectedItem.Name;
                if (path == "..")
                {
                    if (_workingDirectory.Count > 1)
                    {
                        _workingDirectory.Pop();
                    }
                    else
                    {
                        return;
                    }
                }
                else if (path != ".")
                {
                    _workingDirectory.Push(path);
                }
                var newPath = string.Join("/", _workingDirectory.Reverse());
                newPath = newPath.Length < 1 ? "/" : newPath;

                IEnumerable<Renci.SshNet.Sftp.SftpFile> files = null;
                await Task.Run(() =>
                {
                    var currentWorkingDirectory = string.Join("/", newPath);
                    files = openpilotDevice.EnumerateFiles(currentWorkingDirectory);
                });
                dgvExplorer.DataSource = files.OrderBy(file => file.Name).ToArray();

                txtWorkingDirectory.Text = newPath;

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
            
            //_libVlc.Dispose();
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
                                openpilotDevice.InstallFork(forkUser, forkBranch, progress).ConfigureAwait(false);
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
                Task.Run(async () =>
                {
                    var result = await openpilotDevice.RebootAsync();
                });
                
            }
        }

        private async void btnShutdown_Click(object sender, EventArgs e)
        {
            if (cmbDevices.SelectedItem is OpenpilotDevice openpilotDevice)
            {
                Task.Run(async () =>
                {
                    var result = await openpilotDevice.ShutdownAsync();
                });
            }
        }

        private void btnOpenSettings_Click(object sender, EventArgs e)
        {
            if (cmbDevices.SelectedItem is Comma2 openpilotDevice)
            {
                Task.Run(async () =>
                {
                    var result = await openpilotDevice.OpenSettingsAsync();
                });
            }
        }

        private void btnCloseSettings_Click(object sender, EventArgs e)
        {
            if (cmbDevices.SelectedItem is Comma2 openpilotDevice)
            {
                Task.Run(async () =>
                {
                    var result = await openpilotDevice.CloseSettingsAsync();
                });
            }
        }

        private void btnFlashPanda_Click(object sender, EventArgs e)
        {
            if (cmbDevices.SelectedItem is OpenpilotDevice openpilotDevice)
            {
                Task.Run(async () =>
                {
                    var result = await openpilotDevice.FlashPandaAsync();
                });
            }
        }

        private List<string> _commandHistory = new List<string>();
        private int _historyIndex = 0;
        private async void txtSshCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (_shellStream != null)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    _historyIndex = 0;
                    var command = txtSshCommand.Text;
                    _commandHistory.Add(command);
                    txtSshCommand.Text = "";

                    
                    await _shellStream.WriteAsync(new ReadOnlyMemory<byte>(Encoding.UTF8.GetBytes(command + "\r")));
                    await _shellStream.FlushAsync();

                }
                else if (e.KeyCode == Keys.Up)
                {
                    _historyIndex++;
                    if (_historyIndex <= _commandHistory.Count)
                    {
                        txtSshCommand.Text = _commandHistory[_commandHistory.Count - _historyIndex];
                    }
                    else
                    {
                        _historyIndex = _commandHistory.Count;
                    }
                }
                else if (e.KeyCode == Keys.Down)
                {
                    _historyIndex--;
                    if (_historyIndex > 0)
                    {
                        txtSshCommand.Text = _commandHistory[_commandHistory.Count - _historyIndex];
                    }
                    else
                    {
                        _historyIndex = 0;
                    }
                }
            }
        }

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
            ScrollToBottom(txtTerminalText);
        }

        private void tpRemote_Click(object sender, EventArgs e)
        {

        }

        private async void cmbDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = cmbDevices.SelectedItem;
            if (item is OpenpilotDevice openpilotDevice)
            {

                try
                {


                    await Task.Run(() =>
                    {
                        openpilotDevice.Connect();

                        BeginInvoke(new MethodInvoker(() =>
                        {
                            lbDrives.Items.Clear();
                            lbDrives.Items.Add("Loading...");
                        }));

                        var drives = openpilotDevice.GetDrives();
                        BeginInvoke(new MethodInvoker(() => { lbDrives.Items.Clear(); }));


                        foreach (var drive in drives)
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
    }

}