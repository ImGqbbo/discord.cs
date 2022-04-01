using Newtonsoft.Json;
using System.Collections.Generic;

namespace Discord
{
    public class InteractionData
    {
        [JsonProperty("custom_id")]
        public string CustomId { get; private set; }

        [JsonProperty("name")]
        public string CommandName { get; private set; }

        [JsonProperty("id")]
        public ulong? CommandId { get; private set; }

        [JsonProperty("options")]
        public List<DiscordCommandOption> Options { get; private set; }
    }
}
