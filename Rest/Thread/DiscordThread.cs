using Newtonsoft.Json;

namespace Discord
{
    public class DiscordThread : DiscordChannel
    {
        [JsonProperty("default_auto_archive_duration")]
        public uint DefaultAutoArchiveDuration { get; private set; }

        [JsonProperty("member")]
        public GuildMember Member { get; private set; }

        [JsonProperty("thread_metadata")]
        public ThreadMetadata Metadata { get; private set; }
    }
}
