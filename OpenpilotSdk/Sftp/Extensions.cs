using Renci.SshNet.Sftp;
using System.Collections.Generic;
using System.Linq;
using Renci.SshNet;

namespace OpenpilotSdk.Sftp
{
    public static class Extensions
    {
        
        public static IEnumerable<SftpFile> GetFiles(this SftpClient client, string directory)
        {
            var directoryListing = client.ListDirectory(directory).OrderBy(dir => dir.FullName);
            foreach (var directoryItem in directoryListing)
            {
                if (directoryItem.Name.Length <= 2)
                {
                    continue;
                }

                if (directoryItem.IsDirectory)
                {
                    foreach (var driveSegment in client.GetFiles(directoryItem.FullName))
                    {
                        yield return driveSegment;
                    }

                }
                else
                {
                    yield return directoryItem;
                }
            }
        }
    }
}
