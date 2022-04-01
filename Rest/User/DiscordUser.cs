using Newtonsoft.Json;

namespace Discord
{
    public class DiscordUser
    {
        [JsonProperty("id")]
        public ulong Id { get; private set; }

        [JsonProperty("username")]
        public string Username { get; private set; }

        [JsonProperty("discriminator")]
        public ushort Discriminator { get; private set; }

        [JsonProperty("avatar")]
        private string _avatarHash { get; set; }

        [JsonProperty("bot")]
        public bool? Bot { get; private set; }

        [JsonProperty("system")]
        public bool? System { get; private set; }

        [JsonProperty("banner")]
        protected string _bannerHash { get; set; }

        [JsonProperty("flags")]
        public int? Flags { get; private set; }

        [JsonProperty("premium_type")]
        public NitroSubscriptionType? PremiumType { get; private set; }

        [JsonProperty("public_flags")]
        public int? PublicFlags { get; private set; }

        public string Tag() => $"{Username}#{"0000".Substring(4 - Discriminator.ToString().Length) + Discriminator}";

        public DiscordImage Avatar => _avatarHash != null ? new DiscordImage(Id, _avatarHash) : null;
    }
}
