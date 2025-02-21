using Newtonsoft.Json;

namespace OpenpilotToolkit.Json
{
    public partial class OsmTokenResponse
    {
        [JsonProperty("access_token", NullValueHandling = NullValueHandling.Ignore)]
        public string AccessToken { get; set; }

        [JsonProperty("token_type", NullValueHandling = NullValueHandling.Ignore)]
        public string TokenType { get; set; }

        [JsonProperty("scope", NullValueHandling = NullValueHandling.Ignore)]
        public string Scope { get; set; }

        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public long? CreatedAt { get; set; }
    }
}
