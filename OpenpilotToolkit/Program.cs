using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp.WinForms;
using FFMpegCore;
using LibVLCSharp.Shared;
using OpenpilotToolkit.Controls;
using OpenpilotToolkit.Properties;
using Serilog;

namespace OpenpilotToolkit
{
    static class Program
    {
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

            var settings = new CefSettings()
            {
                CefCommandLineArgs = { ["disable-gpu-shader-disk-cache"] = "1" }
                //By default CefSharp will use an in-memory cache, you need to specify a Cache Folder to persist data
                //CachePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CefSharp\\Cache"),
                //BrowserSubprocessPath = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName
            };

            CefSharp.Cef.Initialize(settings);

            GlobalFFOptions.Configure(options => options.BinaryFolder = "./");

            var logPath = Path.Combine(AppContext.BaseDirectory, @"logs\log.txt");

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File(logPath, rollingInterval: RollingInterval.Day, shared: true)
                .CreateLogger();

            Application.ApplicationExit += (_, _) =>
            {
                Settings.Default.Save();
                Log.Information("Application Exiting.");
            };

            Log.Information("Application Starting.");

            var openpilotToolkitForm = new OpenpilotToolkitForm();
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
                ToolkitMessageDialog.ShowDialog(((Exception)args.ExceptionObject).Message, openpilotToolkitForm);
            };

            Core.Initialize();

            var tempPath = Path.Combine(AppContext.BaseDirectory, "tmp");

            try
            {
                if (Directory.Exists(tempPath))
                {
                    Directory.Delete(tempPath, true);
                }

                Directory.CreateDirectory(tempPath);
            }
            catch (Exception e)
            {
                Log.Error(e, "Failed to delete temp folder");
            }
            
            Application.Run(openpilotToolkitForm);
            return 0;
        }
    }
}
