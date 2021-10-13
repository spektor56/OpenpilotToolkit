using OpenpilotToolkitAndroid.Hardware;
using System.Net;

namespace OpenpilotSdk.Hardware
{
    public class Comma2 : OpenpilotDevice
    {
        public Comma2(IPAddress hostAddress, bool isAuthenticated = true)
        {
            IsAuthenticated = isAuthenticated;
            IpAddress = hostAddress;
        }

    }
}