using Renci.SshNet.Sftp;

namespace OpenpilotSdk.OpenPilot.FileTypes
{
    public sealed class LogFile
    {
        public ISftpFile File { get; }
        public bool IsCompressed { get; }

        public LogFile(ISftpFile logFile, bool isCompressed)
        {
            File = logFile;
            IsCompressed = isCompressed;
        }
    }
}
