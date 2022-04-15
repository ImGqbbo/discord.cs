using Newtonsoft.Json;

namespace Discord
{
    public class GuildRole
    {
        [JsonProperty("position")]
        public uint? Position { get; private set; }

        [JsonProperty("name")]
        public string Name { get; private set; }

        [JsonProperty("mentionable")]
        public bool? Mentionable { get; private set; }

        [JsonProperty("id")]
        public ulong? Id { get; private set; }

        [JsonProperty("color")]
        public uint Color { get; private set; }
    }
}
