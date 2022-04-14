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

        [JsonProperty("premium_type")]
        public NitroSubscriptionType? PremiumType { get; private set; }

        [JsonProperty("public_flags")]
        public uint? PublicFlags { get; private set; }
    }
}
