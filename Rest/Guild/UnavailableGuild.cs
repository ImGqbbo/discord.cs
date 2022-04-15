using Newtonsoft.Json;

namespace Discord
{
    public class UnavailableGuild
    {
        [JsonProperty("id")]
        public ulong Id { get; set; }

        [JsonProperty("unavailable")]
        public bool? Unavailable { get; set; }
    }
}
