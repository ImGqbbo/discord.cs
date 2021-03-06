using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Discord
{
    public class DiscordMessage
    {
        [JsonProperty("id")]
        public ulong Id { get; private set; }

        [JsonProperty("channel_id")]
        public ulong ChannelId { get; private set; }

        [JsonProperty("guild_id")]
        public ulong? GuildId { get; private set; }

        [JsonProperty("author")]
        public DiscordUser Author { get; private set; }

        [JsonProperty("member")]
        public GuildMember Member { get; private set; }

        [JsonProperty("edited_timestamp")]
        public DateTime? EditedTimestamp { get; private set; }

        [JsonProperty("type")]
        public MessageType Type { get; private set; }

        [JsonProperty("webhook_id")]
        public ulong WebhookId { get; private set; }

        [JsonProperty("content")]
        public string Content { get; private set; }

        [JsonProperty("mention_everyone")]
        public bool MentionEveryone { get; private set; }

        [JsonProperty("mention_roles")]
        public IReadOnlyList<ulong> RolesMentions { get; private set; }

        [JsonProperty("mentions")]
        public IReadOnlyList<DiscordUser> Mentions { get; private set; }

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; private set; }

        [JsonProperty("embeds")]
        public IReadOnlyList<DiscordEmbed> Embeds { get; private set; }

        [JsonProperty("referenced_message")]
        public DiscordMessage ReferencedMessage { get; private set; }
    }
}
