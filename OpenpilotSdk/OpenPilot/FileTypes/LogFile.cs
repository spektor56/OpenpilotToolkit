using Renci.SshNet.Sftp;
using OpenpilotSdk.OpenPilot.Logging;

namespace OpenpilotSdk.OpenPilot.FileTypes
{
    public sealed class LogFile
    {
        public ISftpFile File { get; }
        public CompressionAlgorithm CompressionAlgorithm { get; }

        public LogFile(ISftpFile logFile, CompressionAlgorithm compressionAlgorithm)
        {
            File = logFile;
            CompressionAlgorithm = compressionAlgorithm;
        }
    }
}
