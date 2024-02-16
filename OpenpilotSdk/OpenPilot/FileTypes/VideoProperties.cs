namespace OpenpilotSdk.OpenPilot.FileTypes
{
    public sealed class VideoProperties
    {
        public int FrameRate { get; }
        public VideoProperties(int frameRate = 20)
        {
            FrameRate = frameRate;
        }
    }
}
