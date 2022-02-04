using Renci.SshNet.Sftp;

namespace OpenpilotSdk.OpenPilot
{
    public class DriveSegment
    {
        public Video DriverVideo { get; }
        public Video WideVideo { get; }
        public Video FrontVideo { get; }
        public ISftpFile QuickLog { get; }
        public ISftpFile RawLog { get; }
        public Video FrontVideoQuick { get; }

        public string Path { get; }

        public int Index { get; }

        public DriveSegment(int index, string path, Video frontVideo, ISftpFile quickLog, ISftpFile rawLog = null, Video driverVideo = null, Video frontVideoQuick = null, Video wideVideo = null)
        {
            Path = path;
            Index = index;
            FrontVideo = frontVideo;
            QuickLog = quickLog;
            RawLog = rawLog;
            DriverVideo = driverVideo;
            FrontVideoQuick = frontVideoQuick;
            WideVideo = wideVideo;
        }

        public override string ToString()
        {
            return Index.ToString();
        }
    }
}
