using Newtonsoft.Json;
using System;

namespace Discord
{
    public class ThreadMetadata
    {
        [JsonProperty("create_timestamp")]
        public DateTime? CreatedAt { get; private set; }

        [JsonProperty("archived")]
        public bool Archivied { get; private set; }

        [JsonProperty("auto_archive_duration")]
        public uint AutoArchiveDuration { get; private set; }

        [JsonProperty("archive_timestamp")]
        public DateTime? ArchivedAt { get; private set; }

        [JsonProperty("locked")]
        public bool Locked { get; private set; }

        [JsonProperty("invitable")]
        public bool? Invitable { get; private set; }
    }
}
