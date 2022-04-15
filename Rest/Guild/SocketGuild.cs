using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Discord
{
    public class SocketGuild
    {
        [JsonProperty("application_id")]
        public ulong? ApplicationId { get; private set; }

        [JsonProperty("name")]
        public string Name { get; private set; }

        [JsonProperty("roles")]
        public IReadOnlyList<GuildRole> Roles { get; private set; }

        [JsonProperty("channels")]
        public IReadOnlyList<DiscordChannel> Channels { get; private set; }

        [JsonProperty("description")]
        public string Description { get; private set; }

        [JsonProperty("afk_timeout")]
        public uint? AfkTimeout { get; private set; }

        [JsonProperty("joined_at")]
        public DateTime? JoinedAt { get; private set; }

        [JsonProperty("id")]
        public ulong? Id { get; private set; }

        [JsonProperty("members")]
        public IReadOnlyList<GuildMember> Members { get; private set; }
    }
}
