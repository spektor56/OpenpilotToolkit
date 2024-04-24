using Renci.SshNet.Sftp;

namespace OpenpilotSdk.OpenPilot.FileTypes
{
    public sealed class VideoSegment
    {
        public ISftpFile File { get; }
        public Hardware.Camera Camera { get; }
        
        public VideoSegment(ISftpFile videoFile, Hardware.Camera camera)
        {
            File = videoFile;
            Camera = camera;
        }

    }
}
