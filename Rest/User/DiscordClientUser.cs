using Newtonsoft.Json;

namespace Discord
{
    public class DiscordClientUser : DiscordUser
    {
        [JsonProperty("mfa_enabled")]
        public bool? MfaEnabled { get; private set; }

        [JsonProperty("verified")]
        public bool? Verified { get; private set; }

        [JsonProperty("email")]
        public string Email { get; private set; }

        [JsonProperty("locale")]
        public string Locale { get; private set; }

        [JsonProperty("flags")]
        public uint? Flags { get; private set; }
    }
}
