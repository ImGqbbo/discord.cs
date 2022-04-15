using Newtonsoft.Json;

namespace Discord
{
    public class EmbedField
    {
        [JsonProperty("name")]
        public string Name { get; internal set; }

        [JsonProperty("value")]
        public string Value { get; internal set; }

        [JsonProperty("inline")]
        public bool Inline { get; internal set; }
    }
}
