using Newtonsoft.Json;

namespace Discord
{
    public class GuildBan
    {
        [JsonProperty("reason")]
        public string Reason { get; private set; }

        [JsonProperty("user")]
        public DiscordUser User { get; private set; }
    }
}
