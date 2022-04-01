using Newtonsoft.Json;

namespace Discord
{
    public class ButtonComponent
    {
        [JsonProperty("type")]
        protected int Type = 2;

        [JsonProperty("style")]
        public DiscordButtonStyle Style { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("emoji")]
        public DiscordEmoji Emoji { get; set; }

        [JsonProperty("custom_id")]
        public string CustomId { get; set; } = Utils.RandomString(30);

        [JsonProperty("url")]
        public string Url { get; set; } = (string)null;

        [JsonProperty("disabled")]
        public bool Disabled { get; set; } = false;
    }
}
