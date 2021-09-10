using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using OpenpilotSdk.Hardware;
using Renci.SshNet;
using Renci.SshNet.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using OpenpilotToolkitAndroid.Git;
using OpenpilotToolkitAndroid.Openpilot.Fork;

namespace OpenpilotToolkitAndroid.Hardware
{
    public abstract class OpenpilotDevice
    {
        private const int SshPort = 8022;

        public bool IsAuthenticated { get; protected set; } = false;
        public int Port { get; set; } = 8022;
        public IPAddress IpAddress { get; set; }
        protected SftpClient SftpClient;
        protected SshClient SshClient;

        public static async IAsyncEnumerable<OpenpilotDevice> DiscoverAsync()
        {
            var pingRequests = new List<Task<OpenpilotDevice>>();
            HashSet<string> addressList = new HashSet<string>();

            foreach (var networkInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                Serilog.Log.Information("Found network interface: {interface}", networkInterface.Name);

                var unicastAddresses = networkInterface.GetIPProperties().UnicastAddresses;
                foreach (var unicastAddress in unicastAddresses)
                {
                    if (unicastAddress.Address.AddressFamily != AddressFamily.InterNetwork)
                    {
                        continue;
                    }

                    var subnetMask = unicastAddress.IPv4Mask.GetAddressBytes();
                    var ipAddress = unicastAddress.Address.GetAddressBytes();

                    if (BitConverter.IsLittleEndian)
                    {
                        Array.Reverse(subnetMask);
                        Array.Reverse(ipAddress);
                    }
                    var endAddress = ~BitConverter.ToUInt32(subnetMask, 0);
                    if (endAddress > 255)
                    {
                        continue;
                    }
                    var localIp = BitConverter.ToUInt32(ipAddress, 0);

                    var startAddress = BitConverter.ToUInt32(ipAddress, 0) & BitConverter.ToUInt32(subnetMask, 0);

                    var startAddressBytes = BitConverter.GetBytes(startAddress + 1);
                    if (BitConverter.IsLittleEndian) Array.Reverse(startAddressBytes);
                    var startIPAddress = Convert.ToString(startAddressBytes[0]) + "." + Convert.ToString(startAddressBytes[1]) + "." +
                        Convert.ToString(startAddressBytes[2]) + "." + Convert.ToString(startAddressBytes[3]);

                    if(startIPAddress == "192.168.43.1")
                    {
                        if (!addressList.Contains(startIPAddress))
                        {
                            addressList.Add(startIPAddress);
                            pingRequests.Add(GetOpenpilotDevice(startIPAddress, SshPort));
                            continue;
                        }
                    }

                    var endAddressBytes = BitConverter.GetBytes(startAddress + endAddress);
                    if (BitConverter.IsLittleEndian) Array.Reverse(endAddressBytes);
                    var endIPAddress = Convert.ToString(endAddressBytes[0]) + "." + Convert.ToString(endAddressBytes[1]) + "." +
                                         Convert.ToString(endAddressBytes[2]) + "." + Convert.ToString(endAddressBytes[3]);

                    Serilog.Log.Information("Scanning IP range: {startAddress} - {endAddress}", startIPAddress, endIPAddress);

                    for (uint i = 1; i <= endAddress; i++)
                    {
                        var host = startAddress + i;
                        if (host == localIp) continue;

                        var hostBytes = BitConverter.GetBytes(host);
                        if (BitConverter.IsLittleEndian) Array.Reverse(hostBytes);

                        var hostAddress = Convert.ToString(hostBytes[0]) + "." + Convert.ToString(hostBytes[1]) + "." +
                                          Convert.ToString(hostBytes[2]) + "." + Convert.ToString(hostBytes[3]);

                        if (!addressList.Contains(hostAddress))
                        {
                            addressList.Add(hostAddress);
                            pingRequests.Add(GetOpenpilotDevice(hostAddress, SshPort));
                        }
                    }
                }
            }


            while (pingRequests.Count > 0)
            {
                var timeout = Task.Delay(10000);
                var result = await Task.WhenAny(Task.WhenAny(pingRequests), timeout).ConfigureAwait(false);
                
                if (result != timeout)
                {
                    var pingResult = await ((Task<Task<OpenpilotDevice>>)result).ConfigureAwait(false);
                    pingRequests.Remove(pingResult);
                    var openpilotDevice = await pingResult.ConfigureAwait(false);
                    if (openpilotDevice != null)
                    {
                        yield return openpilotDevice;
                    }
                }
                else
                {
                    Serilog.Log.Information("Timed Out");
                    break;
                }
            }
        }

     
        public static async Task<OpenpilotDevice> GetOpenpilotDevice(string address, int port, int timeout = 5000)
        {
            try
            {
                //SendPingAsync never completes, maybe skip this and jut try socket instead
                var socketConnected = false;
                using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                {
                 
                    var socketTask = socket.ConnectAsync(address, port);
                    await Task.WhenAny(Task.Delay(timeout), socketTask).ConfigureAwait(false);
                       
                    socketConnected = socket.Connected;

                    if (socketConnected)
                    {
                        socket.Shutdown(SocketShutdown.Both);
                    }

                    socket.Disconnect(false);
                    socket.Close();
                }
                   
                if (socketConnected)
                {
                    Serilog.Log.Information("Connected to {Address} on port {port}", address, port);

                    var privateKeys = new PrivateKeyFile[]
                    {
                        new PrivateKeyFile(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "opensshkey"))
                    };

                    bool foundDevice = false;
                    using (var client = new SshClient(address, port, "comma", privateKeys))
                    {
                        try
                        {
                            client.Connect();
                        }
                        catch (SshAuthenticationException)
                        {
                            var device = new UnknownDevice();
                            return device;
                        }

                        if (client.IsConnected)
                        {
                            foundDevice = true;
                        }
                    }

                    if (foundDevice)
                    {
                        try
                        {
                            using (var client = new SshClient(address, port, "root",
                            privateKeys))
                            {
                                client.Connect();
                                if (client.IsConnected)
                                {
                                    Serilog.Log.Information("Connected to Comma2 device at {Address} on port {port}", address, port);
                                    return new Comma2(IPAddress.Parse(address));
                                }
                                else
                                {
                                    Serilog.Log.Information("Connected to Comma3 device at {Address} on port {port}", address, port);
                                    return new Comma3(IPAddress.Parse(address));
                                }
                            }
                        }
                        catch (Exception)
                        {
                            Serilog.Log.Information("Connected to Comma3 device at {Address} on port {port}", address, port);
                            return (OpenpilotDevice)(new Comma3(IPAddress.Parse(address)));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Serilog.Log.Error("Failed to connect to {Address} with the following exception: {Exception}", address, e.Message);
            }

            return null;
        }

        public virtual async Task<bool> RebootAsync()
        {
            using (var command = SshClient.CreateCommand("reboot"))
            {
                var result = await Task.Factory.FromAsync(command.BeginExecute(), command.EndExecute).ConfigureAwait(false);
                var success = command.ExitStatus == 0;
                return success;
            }
        }

        public virtual async Task<ForkResult> InstallFork(string username, string branch, IProgress<InstallProgress> progress)
        {
            if (progress == null)
            {
                return await InstallFork(username, branch).ConfigureAwait(false);
            }

            var installCommand =
                string.Format(@"cd /data && rm -rf openpilot ; git clone -b {1} --depth 1 --single-branch --progress --recurse-submodules --shallow-submodules https://github.com/{0}/openpilot.git openpilot", username, branch);

            var progressRegex = new Regex(@"\d+(?=%)", RegexOptions.Compiled);
            int previousProgress = 0;
            string lastLineRead = "";

            using (var command = SshClient.CreateCommand(installCommand))
            {
                var asyncResult = command.BeginExecute();
                using (var streamReader = new StreamReader(command.ExtendedOutputStream))
                {
                    while (!asyncResult.IsCompleted)
                    {
                        var output = await streamReader.ReadLineAsync().ConfigureAwait(false);
                        if (!string.IsNullOrWhiteSpace(output))
                        {
                            lastLineRead = output;
                            var match = progressRegex.Match(output);

                            if (!string.IsNullOrWhiteSpace(match.Value))
                            {
                                if (int.TryParse(match.Value, out int currentProgress))
                                {
                                    if (previousProgress != currentProgress)
                                    {
                                        previousProgress = currentProgress;
                                        var progressText = output.Substring(0, match.Index).Trim();
                                        progressText = progressText.Remove(progressText.Length - 1);
                                        progress.Report(new InstallProgress(currentProgress, progressText));
                                    }
                                }
                            }
                        }
                    }

                    var result = command.EndExecute(asyncResult);
                    var success = command.ExitStatus == 0;

                    if (success)
                    {
                        using (var rebootCommand = SshClient.CreateCommand("reboot"))
                        {
                            rebootCommand.BeginExecute();
                        }
                    }

                    return new ForkResult(string.IsNullOrWhiteSpace(result) ? lastLineRead : result,
                        success);
                }
            }
        }

        public virtual async Task<ForkResult> InstallFork(string username, string branch)
        {
            var installCommand =
                string.Format(@"cd /data && rm -rf openpilot; git clone -b {1} --depth 1 --single-branch --recurse-submodules --shallow-submodules https://github.com/{0}/openpilot.git openpilot", username, branch);

            using (var command = SshClient.CreateCommand(installCommand))
            {
                var result = await Task.Factory.FromAsync(command.BeginExecute(), command.EndExecute).ConfigureAwait(false);
                var success = command.ExitStatus == 0 || !(string.IsNullOrWhiteSpace(result) && !string.IsNullOrWhiteSpace(command.Error));

                if (success)
                {
                    using (var rebootCommand = SshClient.CreateCommand("reboot"))
                    {
                        rebootCommand.BeginExecute();
                    }
                }

                return new ForkResult(string.IsNullOrWhiteSpace(result) ? command.Error : result,
                    success);
            }
        }

        public void Connect()
        {
            if (SftpClient == null || !SftpClient.IsConnected)
            {
                var connectionInfo = new ConnectionInfo(IpAddress.ToString(), SshPort,
                    "comma",
                    new PrivateKeyAuthenticationMethod("comma",
                        new PrivateKeyFile(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "opensshkey"))));
                SftpClient = new SftpClient(connectionInfo);
                SshClient = new SshClient(connectionInfo);

                SftpClient.Connect();
                SshClient.Connect();
            }
        }

        public override string ToString()
        {
            return IpAddress.ToString();
        }

        protected bool Equals(OpenpilotDevice other)
        {
            return Equals(IpAddress, other.IpAddress);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((OpenpilotDevice)obj);
        }

        public override int GetHashCode()
        {
            return IpAddress != null ? IpAddress.GetHashCode() : 0;
        }

        public static bool operator ==(OpenpilotDevice left, OpenpilotDevice right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(OpenpilotDevice left, OpenpilotDevice right)
        {
            return !Equals(left, right);
        }
    }
}