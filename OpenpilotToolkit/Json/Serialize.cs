using Newtonsoft.Json;

namespace OpenpilotToolkit.Json
{
    public static class Serialize
    {
        public static string ToJson(this MapillaryData self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }
}
