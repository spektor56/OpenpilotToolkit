using Newtonsoft.Json;

namespace OpenpilotSdk.OpenPilot.Cereal.Json
{
    public partial class OpenpilotLogRecord
    {
        public static OpenpilotLogRecord FromJson(string json) => JsonConvert.DeserializeObject<OpenpilotLogRecord>(json, Converter.Settings);

        [JsonProperty("LogMonoTime", NullValueHandling = NullValueHandling.Ignore)]
        public string LogMonoTime { get; set; }

        [JsonProperty("Valid", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Valid { get; set; }

        [JsonProperty("GpsLocationExternal", NullValueHandling = NullValueHandling.Ignore)]
        public GpsLocationExternal GpsLocationExternal { get; set; }
    }
}
