using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Discord
{
    public class EmbedBuilder
    {
        [JsonProperty("color")]
        protected uint? _color;

        [JsonProperty("fields")]
        protected List<EmbedField> Fields = new List<EmbedField>();

        [JsonProperty("title")]
        protected string Title { get; set; }

        [JsonProperty("description")]
        protected string Description { get; set; }

        [JsonProperty("url")]
        protected string Url { get; set; }

        [JsonProperty("timestamp")]
        protected DateTime? Timestamp { get; set; }

        protected Color Color
        {
            get => Color.FromArgb((int)_color.Value);
            set => _color = (uint)Color.FromArgb(0, value.R, value.G, value.B).ToArgb();
        }

        [JsonProperty("footer")]
        protected EmbedFooter Footer { get; set; }

        [JsonProperty("author")]
        protected EmbedAuthor Author { get; set; }

        [JsonProperty("image")]
        protected EmbedImage Image { get; set; }

        [JsonProperty("thumbnail")]
        protected EmbedImage Thumbnail { get; set; }

        public EmbedBuilder SetTitle(string title)
        {
            Title = title.Length <= 256 ? title : throw new InvalidOperationException("Embed title characters limit is 256.");
            return this;
        }

        public EmbedBuilder SetDescription(string description)
        {
            Description = description.Length <= 4096 ? description : throw new InvalidOperationException("Embed description characters limit is 4096.");
            return this;
        }

        public EmbedBuilder SetUrl(string url)
        {
            Url = url;
            return this;
        }

        public EmbedBuilder SetTimestamp(DateTime timestamp)
        {
            Timestamp = new DateTime?(timestamp);
            return this;
        }

        public EmbedBuilder SetColor(Color color)
        {
            Color = color;
            return this;
        }

        public EmbedBuilder SetImage(string url, int height = 512, int width = 512, string proxyUrl = null)
        {
            Image = new EmbedImage()
            {
                Url = url,
                Height = height,
                Width = width,
                ProxyUrl = proxyUrl
            };
            return this;
        }

        public EmbedBuilder SetThumbnail(string url, int height = 512, int width = 512, string proxyUrl = null)
        {
            Thumbnail = new EmbedImage()
            {
                Url = url,
                Height = height,
                Width = width,
                ProxyUrl = proxyUrl
            };
            return this;
        }

        public EmbedBuilder SetFooter(string text, string iconUrl = null)
        {
            Footer = new EmbedFooter()
            {
                Text = text,
                IconUrl = iconUrl
            };
            return this;
        }

        public EmbedBuilder SetAuthor(string name, string url = null, string iconUrl = null, string proxyIconUrl = null)
        {
            Author = new EmbedAuthor()
            {
                Name = name,
                Url = url,
                IconUrl = iconUrl,
                ProxyIconUrl = proxyIconUrl
            };
            return this;
        }

        public EmbedBuilder AddField(string name, string value, bool inline = false)
        {
            Fields.Add(new EmbedField()
            {
                Name = name,
                Value = value,
                Inline = inline
            });
            return this;
        }

        [JsonProperty("type")]
        protected string Type = "rich";
    }
}
