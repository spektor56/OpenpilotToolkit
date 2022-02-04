using OpenpilotSdk.OpenPilot.FileTypes;
using Renci.SshNet.Sftp;

namespace OpenpilotSdk.OpenPilot
{
    public class Video
    {
        public ISftpFile File { get; }
        public VideoProperties Properties { get; }
        
        public Video(ISftpFile videoFile, int frameRate)
        {
            File = videoFile;
            Properties = new VideoProperties(frameRate);
        }

    }
}
