using Newtonsoft.Json;
using System.Collections.Generic;

namespace Discord
{
    public class DiscordActionRow
    {
        [JsonProperty("type")]
        protected int Type = 1;

        [JsonProperty("components")]
        public List<DiscordFormComponent> Components { get; set; }
    }
}
