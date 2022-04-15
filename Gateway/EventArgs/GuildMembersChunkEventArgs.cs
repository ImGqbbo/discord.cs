using Newtonsoft.Json;
using System.Collections.Generic;

namespace Discord
{
    public class GuildMembersChunkEventArgs
    {
        [JsonProperty("guild_id")]
        public ulong GuildId { get; private set; }

        [JsonProperty("members")]
        public IReadOnlyList<GuildMember> Members { get; private set; }

        [JsonProperty("chunk_index")]
        public uint ChunkIndex { get; private set; }

        [JsonProperty("chunk_count")]
        public uint ChunkCount { get; private set; }
    }
}
