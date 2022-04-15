using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Discord
{
    public class DiscordEmbed
    {
        [JsonProperty("color")]
        private uint? _color;

        [JsonProperty("fields")]
        public List<EmbedField> Fields { get; private set; } = new List<EmbedField>();

        [JsonProperty("title")]
        public string Title { get; private set; }

        [JsonProperty("description")]
        public string Description { get; private set; }

        [JsonProperty("url")]
        public string Url { get; private set; }

        [JsonProperty("timestamp")]
        public DateTime? Timestamp { get; private set; }

        public Color Color
        {
            get => Color.FromArgb((int)_color.Value);
            private set => _color = (uint)Color.FromArgb(0, value.R, value.G, value.B).ToArgb();
        }

        [JsonProperty("footer")]
        public EmbedFooter Footer { get; private set; }

        [JsonProperty("author")]
        public EmbedAuthor Author { get; private set; }

        [JsonProperty("image")]
        public EmbedImage Image { get; private set; }

        [JsonProperty("thumbnail")]
        public EmbedImage Thumbnail { get; private set; }

        [JsonProperty("type")]
        public string Type { get; private set; }
    }
}
