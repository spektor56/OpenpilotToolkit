namespace OpenpilotSdk.Hardware
{
    public sealed class UnknownDevice : OpenpilotDevice
    {
        public override IReadOnlyDictionary<CameraType, Camera> Cameras => throw new System.NotImplementedException();
    }

}
