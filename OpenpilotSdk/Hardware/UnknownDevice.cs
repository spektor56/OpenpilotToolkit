namespace OpenpilotSdk.Hardware
{
    public sealed class UnknownDevice : OpenpilotDevice
    {
        private readonly Lazy<IReadOnlyDictionary<CameraType, Camera>> _cameras = new(() => new Dictionary<CameraType, Camera>());

        public override IReadOnlyDictionary<CameraType, Camera> Cameras => _cameras.Value;
    }

}
