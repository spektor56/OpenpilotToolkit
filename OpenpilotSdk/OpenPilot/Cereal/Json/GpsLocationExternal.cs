using System;
using Newtonsoft.Json;

namespace OpenpilotSdk.OpenPilot.Cereal.Json
{
    public partial class GpsLocationExternal
    {
        [JsonProperty("Flags", NullValueHandling = NullValueHandling.Ignore)]
        public UInt16? Flags { get; set; }

        [JsonProperty("Latitude", NullValueHandling = NullValueHandling.Ignore)]
        public double? Latitude { get; set; }

        [JsonProperty("Longitude", NullValueHandling = NullValueHandling.Ignore)]
        public double? Longitude { get; set; }

        [JsonProperty("Altitude", NullValueHandling = NullValueHandling.Ignore)]
        public double? Altitude { get; set; }

        [JsonProperty("Speed", NullValueHandling = NullValueHandling.Ignore)]
        public double? Speed { get; set; }

        [JsonProperty("Bearing", NullValueHandling = NullValueHandling.Ignore)]
        public double? Bearing { get; set; }

        [JsonProperty("Accuracy", NullValueHandling = NullValueHandling.Ignore)]
        public double? Accuracy { get; set; }

        [JsonProperty("Timestamp", NullValueHandling = NullValueHandling.Ignore)]
        public long Timestamp { get; set; }

        [JsonProperty("Source", NullValueHandling = NullValueHandling.Ignore)]
        public SensorSource? Source { get; set; }

        [JsonProperty("VNED", NullValueHandling = NullValueHandling.Ignore)]
        public double[] Vned { get; set; }

        [JsonProperty("VerticalAccuracy", NullValueHandling = NullValueHandling.Ignore)]
        public double? VerticalAccuracy { get; set; }

        [JsonProperty("BearingAccuracy", NullValueHandling = NullValueHandling.Ignore)]
        public double? BearingAccuracy { get; set; }

        [JsonProperty("SpeedAccuracy", NullValueHandling = NullValueHandling.Ignore)]
        public double? SpeedAccuracy { get; set; }
    }
}
