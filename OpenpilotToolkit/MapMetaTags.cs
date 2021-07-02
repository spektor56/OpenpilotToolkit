using System;
using Newtonsoft.Json;

namespace OpenpilotToolkit
{
    public partial class MapMetaTags
    {
        [JsonProperty("strings", NullValueHandling = NullValueHandling.Ignore)]
        public String[] Strings { get; set; }
    }
}
