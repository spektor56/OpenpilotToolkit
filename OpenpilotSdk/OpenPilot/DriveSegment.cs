using Renci.SshNet.Sftp;

namespace OpenpilotSdk.OpenPilot
{
    public class DriveSegment
    {
        public ISftpFile DriverCamera { get; }
        public ISftpFile WideCamera { get; }
        public ISftpFile FrontCamera { get; }
        public ISftpFile QuickLog { get; }
        public ISftpFile RawLog { get; }
        public ISftpFile FrontCameraQuick { get; }

        public int Index { get; }

        public DriveSegment(int index, ISftpFile frontCamera, ISftpFile quickLog, ISftpFile rawLog = null, ISftpFile driverCamera = null, ISftpFile frontCameraQuick = null, ISftpFile wideCamera = null)
        {
            Index = index;
            FrontCamera = frontCamera;
            QuickLog = quickLog;
            RawLog = rawLog;
            DriverCamera = driverCamera;
            FrontCameraQuick = frontCameraQuick;
            WideCamera = wideCamera;
        }

        public override string ToString()
        {
            return Index.ToString();
        }
    }
}
