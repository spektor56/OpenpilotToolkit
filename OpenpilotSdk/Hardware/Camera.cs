namespace OpenpilotSdk.Hardware
{
    public class Camera
    {
        public CameraType Type { get; }
        public int FrameRate { get; }

        public Camera(CameraType cameraType, int frameRate = 20)
        {
            Type = cameraType;
            FrameRate = frameRate;
        }
    }
}
