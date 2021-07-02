using Newtonsoft.Json;

namespace OpenpilotToolkit.Json
{
    public partial class MapCompassHeading
    {
        [JsonProperty("TrueHeading", NullValueHandling = NullValueHandling.Ignore)]
        public double? TrueHeading { get; set; }

        [JsonProperty("MagneticHeading", NullValueHandling = NullValueHandling.Ignore)]
        public double? MagneticHeading { get; set; }
    }
}
