using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading.Tasks;
using Renci.SshNet;
using Renci.SshNet.Sftp;
using OpenpilotSdk.Sftp;
using Serilog;

namespace OpenpilotSdk.Hardware
{
    public abstract class OpenpilotDevice
    {
        public bool IsAuthenticated { get; protected set; }
        protected readonly string TempDirectory = Path.Combine(AppContext.BaseDirectory, "tmp");
        public int Port { get; set; } = 8022;
        public IPAddress IpAddress { get; set; }
        protected SftpClient SftpClient;
        protected SshClient SshClient;

        public string WorkingDirectory
        {
            get
            {
                return SftpClient.WorkingDirectory;
            }
        }

        public void ChangeDirectory(string path)
        {
            SftpClient.ChangeDirectory(path);
        }

        public IEnumerable<SftpFile> EnumerateFileSystemEntries(string path = "/")
        {
            var fileSystemEntries = SftpClient.EnumerateFileSystemEntries(path);
            return fileSystemEntries;
        }

        public IEnumerable<SftpFile> EnumerateFiles(string path = ".")
        {
            var directoryListing = SftpClient.ListDirectory(path);
            return directoryListing;
        }

        public static async IAsyncEnumerable<OpenpilotDevice> DiscoverAsync()
        {
            Log.Information("Scanning network for devices.");
            var pingRequests = new List<Task<OpenpilotDevice>>();
            HashSet<string> addressList = new HashSet<string>();
            foreach (var networkInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                var gatewayAddresses = networkInterface.GetIPProperties().GatewayAddresses;
                if (!(gatewayAddresses.Count > 0))
                {
                    continue;
                }
                
                Log.Information("Found network interface: {interface}", networkInterface.Name);
                
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

                    var localIp = BitConverter.ToUInt32(ipAddress, 0);
                    var endAddress = ~BitConverter.ToUInt32(subnetMask, 0);
                    var startAddress = BitConverter.ToUInt32(ipAddress, 0) & BitConverter.ToUInt32(subnetMask, 0);

                    var startAddressBytes = BitConverter.GetBytes(startAddress+1);
                    if (BitConverter.IsLittleEndian) Array.Reverse(startAddressBytes);
                    var startIPAddress = Convert.ToString(startAddressBytes[0]) + "." + Convert.ToString(startAddressBytes[1]) + "." +
                        Convert.ToString(startAddressBytes[2]) + "." + Convert.ToString(startAddressBytes[3]);

                    var endAddressBytes = BitConverter.GetBytes(startAddress + endAddress);
                    if (BitConverter.IsLittleEndian) Array.Reverse(endAddressBytes);
                    var endIPAddress = Convert.ToString(endAddressBytes[0]) + "." + Convert.ToString(endAddressBytes[1]) + "." +
                                         Convert.ToString(endAddressBytes[2]) + "." + Convert.ToString(endAddressBytes[3]);

                    Log.Information("Scanning IP range: {startAddress} - {endAddress}", startIPAddress, endIPAddress);

                    for (uint i = 1; i <= endAddress; i++)
                    {
                        var host = startAddress + i;
                        if (host == localIp) continue;

                        var hostBytes = BitConverter.GetBytes(host);
                        if (BitConverter.IsLittleEndian) Array.Reverse(hostBytes);

                        var hostAddress = Convert.ToString(hostBytes[0]) + "." + Convert.ToString(hostBytes[1]) + "." +
                                          Convert.ToString(hostBytes[2]) + "." + Convert.ToString(hostBytes[3]);

                        if(!addressList.Contains(hostAddress))
                        {
                            addressList.Add(hostAddress);
                            pingRequests.Add(OpenPilot.Extensions.GetOpenpilotDevice(hostAddress));
                        }                  
                    }
                }
            }
            
            while (pingRequests.Count > 0)
            {
                var pingResult = await Task.WhenAny(pingRequests);
                pingRequests.Remove(pingResult);
                var openpilotDevice = await pingResult;
                if (openpilotDevice != null)
                {
                    yield return openpilotDevice;
                }
            }
        }

        public void Connect()
        {
            if (SftpClient == null || !SftpClient.IsConnected)
            {
                var connectionInfo = new ConnectionInfo(IpAddress.ToString(), Port,
                    "comma",
                    new PrivateKeyAuthenticationMethod("comma",
                        new PrivateKeyFile(Path.Combine(AppContext.BaseDirectory,
                            "opensshkey"))));
                SftpClient = new SftpClient(connectionInfo);
                SshClient = new SshClient(connectionInfo);
                
                SftpClient.Connect();
                SshClient.Connect();
            }
        }
    }
}
