using Newtonsoft.Json;
using System.Collections.Generic;

namespace Discord
{
    public class MessageProperties
    {
        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("tts")]
        public bool Tts { get; set; }

        //[JsonProperty("embeds")]
        //public List<DiscordEmbed> Embeds { get; set; }

        [JsonProperty("components")]
        public List<DiscordActionRow> Components { get; set; }
    }
}
