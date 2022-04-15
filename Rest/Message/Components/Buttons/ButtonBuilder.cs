using Newtonsoft.Json;

namespace Discord
{
    public class ButtonBuilder : DiscordFormComponent
    {
        [JsonProperty("type")]
        protected int Type = 2;

        [JsonProperty("style")]
        protected DiscordButtonStyle Style { get; set; }

        [JsonProperty("label")]
        protected string Label { get; set; }

        [JsonProperty("emoji")]
        protected DiscordEmoji Emoji { get; set; }

        [JsonProperty("custom_id")]
        protected string CustomId { get; set; } = Utils.RandomString(30);

        [JsonProperty("url")]
        protected string Url { get; set; }

        [JsonProperty("disabled")]
        protected bool Disabled { get; set; } = false;

        public ButtonBuilder SetLabel(string text)
        {
            Label = text;
            return this;
        }

        public ButtonBuilder SetEmoji(DiscordEmoji emoji)
        {
            Emoji = emoji;
            return this;
        }

        public ButtonBuilder SetStyle(DiscordButtonStyle style)
        {
            Style = style;
            return this;
        }

        public ButtonBuilder SetCustomId(string id)
        {
            CustomId = id;
            return this;
        }

        public ButtonBuilder SetUrl(string url)
        {
            Url = url;
            return this;
        }

        public ButtonBuilder SetDisabled(bool disabled)
        {
            Disabled = disabled;
            return this;
        }
    }
}
