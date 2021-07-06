using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.IO;
using OpenpilotSdk.Hardware;
using OpenpilotSdk.OpenPilot;
using OpenpilotToolkit.Android;
using OpenpilotToolkit.Controls;
using OpenpilotToolkit.Json;
using OpenpilotToolkit.Models;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Metadata.Profiles.Exif;
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
            themePanel23.BackColor = materialSkinManager.ColorScheme.PrimaryColor; ;

            //tlpTasks.BackColor = MaterialSkinManager.Instance.BackgroundColor;
            lbDrives.BackColor = MaterialSkinManager.Instance.BackgroundColor;
            lbCommaList.BackColor = MaterialSkinManager.Instance.BackgroundColor;
            lbDrives.ForeColor = MaterialSkinManager.Instance.TextHighEmphasisColor;
            lbCommaList.ForeColor = MaterialSkinManager.Instance.TextHighEmphasisColor;
        }



        private async void Form1_Load(object sender, EventArgs e)
        {
            var settings = new CefSettings
            {
                //BrowserSubprocessPath = Path.Combine(AppContext.BaseDirectory, "CefSharp.BrowserSubprocess.exe")
            };
            Cef.Initialize(settings);

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
            btnScan.Enabled = false;
            try
            {
                await Task.Run(async () =>
                {
                    await foreach (var device in OpenpilotDevice.DiscoverAsync())
                    {
                        Invoke(new MethodInvoker(() =>
                        {
                            if (!lbCommaList.Items.Contains(device))
                            {
                                lbCommaList.Items.Add(device);
                                if (lbCommaList.Items.Count == 1)
                                {
                                    wifiConnected.SetEnabled(true);
                                    lbCommaList.SelectedIndex = 0;
                                }
                            }
                        }));
                    }
                });
                
            }
            finally
            {
                btnScan.Enabled = true;
            }
            
        }


        private async void lbCommaList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = lbCommaList.SelectedItem;
            if (item is Comma2 comma2)
            {
                await Task.Run(() =>
                {
                    comma2.Connect();

                    BeginInvoke(new MethodInvoker(() =>
                    {
                        lbDrives.Items.Clear();
                        lbDrives.Items.Add("Loading...");
                    }));
                    
                    var drives = comma2.GetDrives();
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

        private async void btnScan_Click(object sender, EventArgs e)
        {
            
            lbCommaList.Items.Clear();
            wifiConnected.SetEnabled(false);
            btnScan.Enabled = false;
            try
            {
                await Task.Run(async () =>
                {
                    await foreach (var device in OpenpilotDevice.DiscoverAsync())
                    {
                        Invoke(new MethodInvoker(() =>
                        {
                            if (!lbCommaList.Items.Contains(device))
                            {
                                lbCommaList.Items.Add(device);
                                if (lbCommaList.Items.Count == 1)
                                {
                                    wifiConnected.SetEnabled(true);
                                    lbCommaList.SelectedIndex = 0;
                                }
                            }
                        }));
                    }
                });

                if (lbCommaList.Items.Count > 0)
                {
                    wifiConnected.SetEnabled(true);
                }

            }
            finally
            {
                btnScan.Enabled = true;
            }
        }

        

        private async void btnExport_Click(object sender, EventArgs e)
        {
            if (lbCommaList.SelectedItem is Comma2 comma2)
            {
                if (lbDrives.SelectedItem is Drive drive)
                {
                    if(_activeTaskList.ContainsKey(drive.Date.ToString()))
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
                        await comma2.ExportDriveAsync(exportFolder, drive, progress);
                    });
                    _activeTaskList.TryAdd(drive.Date.ToString(), task );
                    await task;
                    _activeTaskList.TryRemove(drive.Date.ToString(), out _);
                }
            }
        }

        private async void btnRefreshVideos_Click(object sender, EventArgs e)
        {
            var item = lbCommaList.SelectedItem;
            if (item is Comma2 comma2)
            {
                lbDrives.Items.Clear();
                lbDrives.Items.Add("Loading...");

                await Task.Run(() =>
                {
                    var drives = comma2.GetDrives();
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
            //lbDrives.Enabled = false;
            lbCommaList.Enabled = false;
            if (lbCommaList.SelectedItem is Comma2 comma2)
            {
                if (lbDrives.SelectedItem is Drive drive)
                {

                    pbPreview.Image = null;
                    await Task.Run(() =>
                    {
                        var thumbnail = comma2.GetThumbnail(drive);
                        BeginInvoke(new MethodInvoker(() => { pbPreview.Image = thumbnail; }));
                    });
                }
                
            }
            //lbDrives.Enabled = true;
            lbCommaList.Enabled = true;

        }

        private async void ExportDrivesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_activeTaskList.Any())
            {
                MessageBox.Show("Files are exporting");
                e.Cancel = true;
                return;
            }

            Properties.Settings.Default.DarkMode = MaterialSkinManager.Instance.Theme == MaterialSkinManager.Themes.DARK;
            Properties.Settings.Default.ExportFolder = txtExportFolder.Text;
            Properties.Settings.Default.Save();
            Cef.Shutdown();
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

            

            if (lbCommaList.SelectedItem is Comma2 comma2)
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
                        var gpxFile = await comma2.GenerateGpxFileAsync(drive, progress);
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

            if (lbCommaList.SelectedItem is Comma2 comma2)
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
                        await comma2.ExportDriveAsync(exportFolder, drive, progress);
                    });
                    _activeTaskList.TryAdd(drive.Date.ToString(), task);
                    await task;
                    _activeTaskList.TryRemove(drive.Date.ToString(), out _);

                    var waypoints = await comma2.MapillaryExportAsync(drive);

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
            lbCommaList.BackColor = MaterialSkinManager.Instance.BackgroundColor;
            lbDrives.ForeColor = MaterialSkinManager.Instance.TextHighEmphasisColor;
            lbCommaList.ForeColor = MaterialSkinManager.Instance.TextHighEmphasisColor;
        }

        private void themeButton_Click(object sender, EventArgs e)
        {
            SetTheme(MaterialSkinManager.Instance.Theme == MaterialSkinManager.Themes.LIGHT);
        }

        private void themePanel_LocationChanged(object sender, EventArgs e)
        {
            themePanel23.Location = new System.Drawing.Point(this.Width - themePanel23.Width - this.Margin.Right, 26);
            themePanel23.LocationChanged -= themePanel_LocationChanged;
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
                if (lbCommaList.SelectedItem is Comma2 comma2)
                {
                    await Task.Run(() =>
                    {
                        var files = comma2.GetFiles().OrderBy(file => file.Name);
                        Invoke(new MethodInvoker(() => { materialListBox2.Clear(); }));
                        foreach (var file in files)
                        {
                            //var button = new MaterialButton();
                            //button.Icon = global::DriveExporter.Properties.Resources.outline_description_black_24dp;
                            //button.Text = file.Name;
                            Invoke(new MethodInvoker(() => { materialListBox2.AddItem(new MaterialListBoxItem(file.Name)); }));
                            
                        }
                    });
                    
                }
                
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
        }
    }

}