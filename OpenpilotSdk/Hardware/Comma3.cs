using System.Collections.Generic;
using System.Net;

namespace OpenpilotSdk.Hardware
{
    public class Comma3 : OpenpilotDevice
    {
        public override IReadOnlyDictionary<CameraType, Camera> Cameras => new Dictionary<CameraType, Camera>()
        {
            { CameraType.Front, new Camera(CameraType.Front) },
            { CameraType.Driver, new Camera(CameraType.Driver) },
            { CameraType.Wide, new Camera(CameraType.Wide) },
        };
        protected override string NotConnectedMessage { get; set; } = "No connection has been made to the Comma3";

        public override string StorageDirectory { get; protected set; } = @"/data/media/0/realdata/";
        public override string RebootCommand { get; protected set; } = @"sudo reboot";
        public override string ShutdownCommand { get; protected set; } = @"sudo shutdown";

        public override string DeviceName { get; protected set; } = @"Comma3";

        public Comma3(IPAddress hostAddress, bool isAuthenticated = true)
        {
            IsAuthenticated = isAuthenticated;
            IpAddress = hostAddress;
        }
    }
}
