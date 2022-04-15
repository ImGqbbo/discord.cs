using Newtonsoft.Json;
using System.Collections.Generic;

namespace Discord
{
    public class PrivateChannel : DiscordChannel
    {
        [JsonProperty("recipients")]
        public IReadOnlyList<DiscordUser> Recipients { get; private set; }
    }
}
