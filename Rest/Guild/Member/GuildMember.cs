using Newtonsoft.Json;
using System;

namespace Discord
{
    public class GuildMember
    {
        [JsonProperty("id")]
        public ulong Id { get; private set; }

        [JsonProperty("nick")]
        public string Nick { get; private set; }

        [JsonProperty("user")]
        public DiscordUser User { get; private set; }

        [JsonProperty("joined_at")]
        public DateTime JoinedAt { get; private set; }

        [JsonProperty("communication_disabled_until")]
        public DateTime? ComunicationDisabledUntil { get; private set; }
    }
}
