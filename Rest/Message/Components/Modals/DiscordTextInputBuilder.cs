using Newtonsoft.Json;

namespace Discord
{
    public class DiscordTextInputBuilder : DiscordFormComponent
    {
        [JsonProperty("type")]
        protected ComponentType Type = ComponentType.TextInput;

        [JsonProperty("custom_id")]
        protected string CustomId = Utils.RandomString(30);

        [JsonProperty("label")]
        protected string Label { get; set; }

        [JsonProperty("style")]
        protected DiscordTextInputStyle Style = DiscordTextInputStyle.Short;

        [JsonProperty("min_length")]
        protected uint MinLength = 1;

        [JsonProperty("max_length")]
        protected uint MaxLength = 4000;

        [JsonProperty("placeholder")]
        protected string Placeholder { get; set; }

        [JsonProperty("required")]
        protected bool Required = true;

        public DiscordTextInputBuilder SetCustomId(string id)
        {
            CustomId = id;

            return this;
        }

        public DiscordTextInputBuilder SetLabel(string text)
        {
            Label = text;

            return this;
        }

        public DiscordTextInputBuilder SetStyle(DiscordTextInputStyle style)
        {
            Style = style;

            return this;
        }

        public DiscordTextInputBuilder SetMinLength(uint minLength)
        {
            MinLength = minLength;

            return this;
        }

        public DiscordTextInputBuilder SetMaxLength(uint maxLength)
        {
            MaxLength = maxLength;

            return this;
        }

        public DiscordTextInputBuilder SetPlaceholderText(string text)
        {
            Placeholder = text;

            return this;
        }

        public DiscordTextInputBuilder SetRequired(bool required)
        {
            Required = required;

            return this;
        }
    }
}
