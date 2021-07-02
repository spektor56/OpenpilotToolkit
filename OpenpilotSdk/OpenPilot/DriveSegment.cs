using Renci.SshNet.Sftp;

namespace OpenpilotSdk.OpenPilot
{
    public class DriveSegment
    {
        public SftpFile DriverCamera { get; }
        public SftpFile FrontCamera { get; }
        public SftpFile QuickLog { get; }
        public SftpFile RawLog { get; }
        public SftpFile FrontCameraQuick { get; }

        public int Index { get; }

        public DriveSegment(int index, SftpFile frontCamera, SftpFile quickLog, SftpFile rawLog = null, SftpFile driverCamera = null, SftpFile frontCameraQuick = null )
        {
            Index = index;
            FrontCamera = frontCamera;
            QuickLog = quickLog;
            RawLog = rawLog;
            DriverCamera = driverCamera;
            FrontCameraQuick = frontCameraQuick;
        }

        public override string ToString()
        {
            return Index.ToString();
        }
    }
}
