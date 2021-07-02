using System;
using Newtonsoft.Json;

namespace OpenpilotToolkit.Json
{
    public partial class MapillaryData
    {
        [JsonProperty("MAPSettingsUsername", NullValueHandling = NullValueHandling.Ignore)]
        public string MapSettingsUsername { get; set; }

        [JsonProperty("MAPSettingsUserKey", NullValueHandling = NullValueHandling.Ignore)]
        public string MapSettingsUserKey { get; set; }

        [JsonProperty("MAPLatitude", NullValueHandling = NullValueHandling.Ignore)]
        public double? MapLatitude { get; set; }

        [JsonProperty("MAPLongitude", NullValueHandling = NullValueHandling.Ignore)]
        public double? MapLongitude { get; set; }

        [JsonProperty("MAPCaptureTime", NullValueHandling = NullValueHandling.Ignore)]
        public string MapCaptureTime { get; set; }

        [JsonProperty("MAPAltitude", NullValueHandling = NullValueHandling.Ignore)]
        public double? MapAltitude { get; set; }

        [JsonProperty("MAPCompassHeading", NullValueHandling = NullValueHandling.Ignore)]
        public MapCompassHeading MapCompassHeading { get; set; }

        [JsonProperty("MAPSequenceUUID", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? MapSequenceUuid { get; set; }

        [JsonProperty("MAPOrientation", NullValueHandling = NullValueHandling.Ignore)]
        public long? MapOrientation { get; set; }

        [JsonProperty("MAPDeviceMake", NullValueHandling = NullValueHandling.Ignore)]
        public string MapDeviceMake { get; set; }

        [JsonProperty("MAPDeviceModel", NullValueHandling = NullValueHandling.Ignore)]
        public string MapDeviceModel { get; set; }

        [JsonProperty("MAPMetaTags", NullValueHandling = NullValueHandling.Ignore)]
        public MapMetaTags MapMetaTags { get; set; }

        [JsonProperty("MAPPhotoUUID", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? MapPhotoUuid { get; set; }

        
    }
}
