using Renci.SshNet.Sftp;
using System.Collections.Generic;
using System.Linq;
using Renci.SshNet;
using System.IO;

namespace OpenpilotSdk.Sftp
{
    public static class Extensions
    {
        
        public static IEnumerable<SftpFile> GetFiles(this SftpClient client, string directory)
        {
            var directoryListing = client.ListDirectory(directory).OrderBy(dir => dir.FullName);
            foreach (var directoryItem in directoryListing)
            {
                if (directoryItem.Name == ".." || directoryItem.Name == ".")
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

        public static IEnumerable<SftpFile> EnumerateFileSystemEntries(this SftpClient client, string directory)
        {
            var directoryListing = client.ListDirectory(directory).OrderBy(dir => dir.FullName);
            foreach (var directoryItem in directoryListing)
            {
                if (directoryItem.Name == ".." || directoryItem.Name == ".")
                {
                    continue;
                }

                if (directoryItem.IsDirectory && !directoryItem.IsRegularFile)
                {
                    if(directoryItem.FullName == "/dev/block/loop0")
                    {

                    }
                    foreach(var fileItem in client.EnumerateFileSystemEntries(directoryItem.FullName))
                    {
                        yield return fileItem;
                    }
                }
                
                yield return directoryItem;
            }
             
        }
    }
}
