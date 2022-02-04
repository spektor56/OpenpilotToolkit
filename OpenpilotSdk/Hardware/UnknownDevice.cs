using System.Collections.Generic;

namespace OpenpilotSdk.Hardware
{
    public class UnknownDevice : OpenpilotDevice
    {
        public override IReadOnlyDictionary<CameraType, Camera> Cameras => throw new System.NotImplementedException();
    }

}
