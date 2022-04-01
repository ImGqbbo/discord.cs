using Newtonsoft.Json;
using System.Collections.Generic;

namespace Discord
{
    public class DiscordCommandOption
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("required")]
        public bool Required { get; set; }

        [JsonProperty("type")]
        public ApplicationCommandOptionType Type { get; set; }

        [JsonProperty("choices")]
        public List<CommandOptionChoice> Choices { get; set; }

        [JsonProperty("options")]
        public List<DiscordCommandOption> Options { get; set; }
    }
}
