using Newtonsoft.Json;

namespace Discord
{
    public class DiscordChannel
    {
        [JsonProperty("name")]
        public string Name { get; private set; }

        [JsonProperty("topic")]
        public string Topic { get; private set; }

        [JsonProperty("id")]
        public ulong Id { get; private set; }

        [JsonProperty("nsfw")]
        public bool NSFW { get; private set; }

        [JsonProperty("rate_limit_per_user")]
        public uint RateLimit { get; private set; }

        [JsonProperty("last_message_id")]
        public ulong LastMessageId { get; private set; }

        [JsonProperty("type")]
        public ChannelType Type { get; private set; }

        [JsonProperty("guild_id")]
        public ulong GuildId { get; private set; }
    }
}
