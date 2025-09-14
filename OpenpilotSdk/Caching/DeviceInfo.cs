using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace OpenpilotSdk.Caching
{
    public record DeviceInfo
    {
        public string IpAddress { get; init; } = string.Empty;
        public string Hostname { get; init; } = string.Empty;
        public DateTime LastSeen { get; init; } = DateTime.UtcNow;
    }
}
