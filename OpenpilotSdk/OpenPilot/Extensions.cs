using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using OpenpilotSdk.Hardware;
using Renci.SshNet;
using Renci.SshNet.Common;
using Serilog;

namespace OpenpilotSdk.OpenPilot
{
    public static class Extensions
    {
        public static readonly Regex FolderRegex = new Regex(@"^(\d{4}-\d{2}-\d{2})--(\d{2}-\d{2}-\d{2})--(\d+)$", RegexOptions.Compiled);
        private static Object _lockObject = new Object();
        public static Task<OpenpilotDevice> GetOpenpilotDevice(string address)
        {
            var tcs = new TaskCompletionSource<OpenpilotDevice>();
            var ping = new Ping();

            ping.PingCompleted += async (obj, sender) =>
            {
                if (sender.Reply.Status == IPStatus.Success)
                {
                    /*for debugging
                    var testList = new List<string> {"192.168.0.13", "192.168.0.10","192.168.0.12","192.168.0.38"};

                    if (testList.Contains(sender.Reply.Address.ToString()))
                    {
                        tcs.SetResult(new Comma2(sender.Reply.Address));
                        return;
                    }
                    */

                    Log.Information("Found device at address: {Address}", sender.Reply.Address);

                    try
                    {
                        using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                        {
                            var result = socket.ConnectAsync(sender.Reply.Address, 8022);
                            await Task.WhenAny(result, Task.Delay(2000));

                            if (socket.Connected)
                            {
                                Log.Information("Connected to {Address} on port {port}", sender.Reply.Address, 8022);

                                socket.Shutdown(SocketShutdown.Both);
                                socket.Disconnect(false);
                                
                                var connectionInfo = new ConnectionInfo(sender.Reply.Address.ToString(), 8022,
                                    "comma",
                                    new PrivateKeyAuthenticationMethod("comma",
                                        new PrivateKeyFile(Path.Combine(
                                            AppContext.BaseDirectory,
                                            "opensshkey"))));
                                using (var client = new SftpClient(connectionInfo))
                                {
                                    try
                                    {
                                        client.Connect();
                                    }
                                    catch(SshAuthenticationException)
                                    {
                                        var comma2 = new Comma2(sender.Reply.Address, false);
                                        tcs.SetResult(comma2);
                                        return;
                                    }

                                    if (client.IsConnected)
                                    {
                                        Log.Information("Connected to Comma device at {Address} on port {port}", sender.Reply.Address, 8022);
                                        tcs.SetResult(new Comma2(sender.Reply.Address));
                                        return;
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Log.Error("Failed to connect to {Address} with the following exception: {Exception}", sender.Reply.Address, e.Message);
                    }
                }

                tcs.SetResult(null);
            };

            try
            {
                ping.SendAsync(address, new object());
            }
            catch (Exception e)
            {
                tcs.SetException(e);
            }

            return tcs.Task;
        }

        public static Bitmap GetThumbnail(string video, string thumbnail)
        {
            if (File.Exists(thumbnail))
            {
                return (Bitmap)Image.FromFile(thumbnail);
            }

            lock (_lockObject)
            {
                var cmd = "ffmpeg -i  " + '"' + video + '"' + " -frames:v 1 " + '"' + thumbnail + '"';

                var startInfo = new ProcessStartInfo
                {
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    Arguments = "/C " + cmd
                };

                var process = new Process
                {
                    StartInfo = startInfo
                };

                process.Start();
                process.WaitForExit(5000);
            }

            if (File.Exists(thumbnail))
            {
                return (Bitmap)Image.FromFile(thumbnail);
            }

            return null;
            
        }
    }
}
