using Renci.SshNet.Sftp;

namespace OpenpilotSdk.OpenPilot
{
    public sealed class DriveSegment
    {
        public Video? DriverVideo { get; }
        public Video? WideVideo { get; }
        public Video? FrontVideo { get; }
        public ISftpFile QuickLog { get; }
        public ISftpFile RawLog { get; }
        public Video? FrontVideoQuick { get; }

        public bool RawLogCompressed { get; }
        public bool QuickLogCompressed { get; }

        public string Path { get; }

        public int Index { get; }

        public DriveSegment(int index, string path, Video? frontVideo, ISftpFile quickLog, ISftpFile rawLog = null, Video? driverVideo = null, Video frontVideoQuick = null, Video? wideVideo = null, bool rawLogCompressed = false, bool quickLogCompressed = false)
        {
            Path = path;
            Index = index;
            FrontVideo = frontVideo;
            QuickLog = quickLog;
            RawLog = rawLog;
            DriverVideo = driverVideo;
            FrontVideoQuick = frontVideoQuick;
            WideVideo = wideVideo;
            RawLogCompressed = rawLogCompressed;
            QuickLogCompressed = quickLogCompressed;
        }

        public override string ToString()
        {
            return Index.ToString();
        }
    }
}
