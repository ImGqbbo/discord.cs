using Newtonsoft.Json;

namespace Discord
{
    public class DiscordEmoji
    {
        [JsonProperty("id")]
        public string Id { get; set; } = null;

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
