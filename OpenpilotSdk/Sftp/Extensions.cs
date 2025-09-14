using Renci.SshNet.Sftp;
using Renci.SshNet;
using System.Runtime.CompilerServices;

namespace OpenpilotSdk.Sftp
{
    public static class Extensions
    {
        public static async IAsyncEnumerable<ISftpFile> GetFilesAsync(this SftpClient client, string directory, [EnumeratorCancellation] CancellationToken cancellationToken = default(CancellationToken))
        {
            var directoryListing = (await client.ListDirectoryAsync(directory, cancellationToken).ToListAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).OrderBy(dir => dir.FullName);
            foreach (var directoryItem in directoryListing)
            {
                if (directoryItem.Name == ".." || directoryItem.Name == ".")
                {
                    continue;
                }

                if (directoryItem.IsDirectory)
                {
                    await foreach (var routeSegment in client.GetFilesAsync(directoryItem.FullName).ConfigureAwait(false))
                    {
                        yield return routeSegment;
                    }
                }
                else
                {
                    yield return directoryItem;
                }
            }
        }

        public static IEnumerable<ISftpFile> GetFiles(this SftpClient client, string directory)
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
                    foreach (var routeSegment in client.GetFiles(directoryItem.FullName))
                    {
                        yield return routeSegment;
                    }

                }
                else
                {
                    yield return directoryItem;
                }
            }
        }

        public static IEnumerable<ISftpFile> EnumerateFileSystemEntries(this SftpClient client, string directory)
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
                    /* What was i testing here again
                    if(directoryItem.FullName == "/dev/block/loop0")
                    {

                    }
                    */
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
