using Newtonsoft.Json;

namespace Discord
{
    public class EmbedFooter
    {
        [JsonProperty("text")]
        public string Text { get; internal set; }

        [JsonProperty("icon_url")]
        public string IconUrl { get; internal set; }
    }
}
