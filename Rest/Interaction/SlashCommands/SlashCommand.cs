using Newtonsoft.Json;
using System.Collections.Generic;

namespace Discord
{
    public class SlashCommand
    {
        [JsonProperty("name")]
        public string Name { get; private set; }

        [JsonProperty("id")]
        public ulong Id { get; private set; }

        [JsonProperty("type")]
        public ApplicationCommandType Type { get; private set; }

        [JsonProperty("options")]
        public IReadOnlyList<DiscordCommandOption> Options { get; private set; }

        [JsonProperty("application_id")]
        public ulong ApplicationId { get; private set; }
    }
}
