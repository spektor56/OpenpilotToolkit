namespace OpenpilotSdk.OpenPilot.Camera
{
    public sealed class Progress
    {
        public Hardware.Camera Camera { get; }
        public int Percent { get; set; }

        public Progress(Hardware.Camera camera)
        {
            Camera = camera;
        }
    }
}
