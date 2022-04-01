using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Discord
{
    public class GuildMemberProperties
    {
        [JsonProperty("nick")]
        public string Nick { get; set; }

        [JsonProperty("roles")]
        public List<ulong> Roles { get; set; }

        [JsonProperty("communication_disabled_until")]
        public DateTime ComunicationDisabledUntil { get; set; }
    }
}
