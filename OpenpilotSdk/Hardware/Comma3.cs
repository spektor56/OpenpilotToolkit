﻿using System.Net;

namespace OpenpilotSdk.Hardware
{
    public sealed class Comma3 : OpenpilotDevice
    {
        private readonly Lazy<IReadOnlyDictionary<CameraType, Camera>> _cameras = new Lazy<IReadOnlyDictionary<CameraType, Camera>>(() => new Dictionary<CameraType, Camera>
        {
            { CameraType.Front, new Camera(CameraType.Front) },
            { CameraType.Driver, new Camera(CameraType.Driver) },
            { CameraType.Wide, new Camera(CameraType.Wide) },
        });

        public override IReadOnlyDictionary<CameraType, Camera> Cameras => _cameras.Value;

        protected override string NotConnectedMessage => "No connection has been made to the Comma3";

        public override string RebootCommand => "sudo reboot";
        public override string ShutdownCommand => "sudo shutdown";

        public override OpenpilotDeviceType DeviceType => OpenpilotDeviceType.Comma3;

        public Comma3(IPAddress hostAddress, string hostName, bool isAuthenticated = true)
        {
            IsAuthenticated = isAuthenticated;
            IpAddress = hostAddress;
            HostName = hostName;
        }
    }
}
