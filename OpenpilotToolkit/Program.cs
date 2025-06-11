using CefSharp.WinForms;
using FFMpegCore;
using FlyleafLib;
using OpenpilotToolkit.Controls;
using OpenpilotToolkit.Properties;
using Serilog;
using Serilog.Events;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;

namespace OpenpilotToolkit
{
    static class Program
    {
        private static string _cefCachePath = "";
        private static string _toolkitTempFolder;
        private static bool _disposed = false;
        
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        public static int Main(string[] args)
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.SetHighDpiMode(HighDpiMode.DpiUnaware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            var splashForm = new SplashScreen();
            Task.Run(() =>
            {
                splashForm.ShowDialog();
            });
            
            var exitCode = CefSharp.BrowserSubprocess.SelfHost.Main(args);

            if (exitCode >= 0)
            {
                return exitCode;
            }

            _cefCachePath = Directory.CreateTempSubdirectory("OPTK_CEF_").FullName;
            
            try
            {
                _toolkitTempFolder = Directory.CreateTempSubdirectory("OPTK_").FullName;
            }
            catch (Exception e)
            {
                _toolkitTempFolder = Path.Combine(AppContext.BaseDirectory, "tmp", "explorer");
                Log.Error(e, "Failed to create toolkit temp folder");
            }

            var settings = new CefSettings()
            {
                CachePath = _cefCachePath,
                RootCachePath = _cefCachePath,
                LogSeverity = LogSeverity.Disable,
            };

            settings.CefCommandLineArgs.Add("disable-background-timer-throttling", "1");
            settings.CefCommandLineArgs.Add("disable-renderer-backgrounding", "1");
            settings.CefCommandLineArgs.Add("disable-new-content-rendering-timeout", "1");
            settings.CefCommandLineArgs.Add("disable-features", "CrossSiteDocumentBlockingAlways,IsolateOrigins,site-per-process");
            settings.CefCommandLineArgs.Add("disable-ntp-remote-suggestions", "1");
            settings.CefCommandLineArgs.Add("disable-background-networking", "1");
            settings.CefCommandLineArgs.Add("disable-databases", "1");
            settings.CefCommandLineArgs.Add("disable-cache", "1");
            settings.CefCommandLineArgs.Add("disable-extensions", "1");
            settings.CefCommandLineArgs.Add("disable-pdf-extension", "1");
            settings.CefCommandLineArgs.Add("disable-plugins", "1");
            settings.CefCommandLineArgs.Add("disable-spell-checking", "1");
            settings.CefCommandLineArgs.Add("disable-site-isolation-trials", "1");
            settings.CefCommandLineArgs.Add("disable-gpu-process-crash-limit", "1");
            settings.CefCommandLineArgs.Add("disable-web-security", "1");
            settings.CefCommandLineArgs.Add("disable-application-cache", "1");
            settings.CefCommandLineArgs.Add("disable-local-storage", "1");
            settings.CefCommandLineArgs.Add("disable-service-worker-cache", "1");
            settings.CefCommandLineArgs.Add("disable-http-cache", "1");
            settings.CefCommandLineArgs.Add("disable-media-cache", "1");
            settings.CefCommandLineArgs.Add("disable-gpu-shader-disk-cache", "1");
            settings.CefCommandLineArgs.Add("disable-session-storage", "1");
            settings.CefCommandLineArgs.Add("disable-websql", "1");
            settings.CefCommandLineArgs.Add("disable-gpu-program-cache", "1");
            settings.CefCommandLineArgs.Add("disable-client-side-phishing-detection", "1");
            settings.CefCommandLineArgs.Add("disable-component-update", "1");
            settings.CefCommandLineArgs.Add("disable-default-apps", "1");
            settings.CefCommandLineArgs.Add("disable-hang-monitor", "1");
            settings.CefCommandLineArgs.Add("disable-infobars", "1");
            settings.CefCommandLineArgs.Add("disable-blink-features", "StorageAPI");

            settings.CefCommandLineArgs.Add("disk-cache-size", "0");
            settings.CefCommandLineArgs.Add("media-cache-size", "0");
            
            settings.CefCommandLineArgs.Add("no-proxy-server", "1");
            settings.CefCommandLineArgs.Add("no-sandbox", "1");
            settings.CefCommandLineArgs.Add("no-zygote", "1");

            settings.CefCommandLineArgs.Add("enable-oop-rasterization", "1");
            settings.CefCommandLineArgs.Add("enable-zero-copy", "1");
            settings.CefCommandLineArgs.Add("enable-gpu-rasterization", "1");
            settings.CefCommandLineArgs.Add("enable-gpu", "1");
            settings.CefCommandLineArgs.Add("enable-webgl", "1");

            settings.CefCommandLineArgs.Add("allow-file-access-from-files", "1");

            Cef.Initialize(settings);

            GlobalFFOptions.Configure(options => options.BinaryFolder = "./");

            var logPath = Path.Combine(AppContext.BaseDirectory, @"logs\log.txt");

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Logger(lc => lc
                .Filter.ByExcluding(le => le.Level == LogEventLevel.Information)
                .WriteTo.Debug(outputTemplate: "{Timestamp:HH:mm:ss.fff} [{Level}] ({ThreadId}) {Message}{NewLine}{Exception}"))
                .WriteTo.Async(a => a.File(logPath, rollingInterval: RollingInterval.Day, shared: true, restrictedToMinimumLevel: LogEventLevel.Information))
                .CreateLogger();

            AppDomain.CurrentDomain.ProcessExit += (_, _) =>
            {
                Dispose();
            };

            Application.ApplicationExit += (_, _) =>
            {
                Dispose();
            };

            Log.Information("Application Starting.");
            
            

            var openpilotToolkitForm = new OpenpilotToolkitForm(_toolkitTempFolder);
            openpilotToolkitForm.Shown += (s, e) =>
            {
                openpilotToolkitForm.Activate();
                splashForm.BeginInvoke(() =>
                {
                    splashForm.Close();
                    splashForm.Dispose();
                });
            };
            Application.ThreadException += (sender, args) =>
            {
                Log.Error(args.Exception, "Unhandled Exception");
                ToolkitMessageDialog.ShowDialog(args.Exception.Message, openpilotToolkitForm);
            };
            
            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
            {
                Log.Error((Exception)args.ExceptionObject, "Unhandled Exception");

                if (!openpilotToolkitForm.IsDisposed)
                {
                    if (openpilotToolkitForm.InvokeRequired)
                    {
                        openpilotToolkitForm.Invoke(() =>
                        {
                            ToolkitMessageDialog.ShowDialog(((Exception)args.ExceptionObject).Message, openpilotToolkitForm);
                        });
                    }
                    else
                    {
                        ToolkitMessageDialog.ShowDialog(((Exception)args.ExceptionObject).Message, openpilotToolkitForm);
                    }
                }
            };
            
            Application.Run(openpilotToolkitForm);
            return 0;
        }
        
        public static void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
                Settings.Default.Save();

                Cef.Shutdown();

                while (Engine.Players.Count != 0)
                {
                    Engine.Players[0].Dispose();
                }

                Process currentProcess = Process.GetCurrentProcess();
                Process[] processes = Process.GetProcessesByName(currentProcess.ProcessName);

                if (processes.Length < 2)
                {
                    var tempDirectories = Directory.GetDirectories(Path.GetTempPath(), @"OPTK_*", new EnumerationOptions() {RecurseSubdirectories = false, MatchCasing = MatchCasing.CaseSensitive, ReturnSpecialDirectories = false, IgnoreInaccessible = true});
                    foreach (var tempDirectory in tempDirectories)
                    {
                        try
                        {
                            Directory.Delete(tempDirectory, recursive: true);
                        }
                        catch (Exception ex)
                        {
                            Log.Error(ex, "Failed to delete temp folder");
                        }
                    }
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(_toolkitTempFolder))
                    {
                        try
                        {
                            Directory.Delete(_toolkitTempFolder, recursive: true);
                        }
                        catch (Exception ex)
                        {
                            Log.Error(ex, "Failed to clean-up toolkit temp folder");
                        }
                    }

                    if (!string.IsNullOrWhiteSpace(_cefCachePath))
                    {
                        try
                        {
                            Directory.Delete(_cefCachePath, recursive: true);
                        }
                        catch (Exception ex)
                        {
                            Log.Error(ex, "Failed to clean-up CefSharp cache");
                        }
                    }
                }

                Log.Information("Application Exiting.");
                Log.CloseAndFlush();
            }
        }
    }
}
