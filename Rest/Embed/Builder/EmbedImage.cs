﻿using Newtonsoft.Json;

namespace Discord
{
    internal class EmbedImage
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("proxy_url")]
        public string ProxyUrl { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }
    }
}