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
        internal string AvatarHash { get; set; }

        [JsonProperty("bot")]
        public bool? Bot { get; private set; }

        [JsonProperty("system")]
        public bool? System { get; private set; }

        [JsonProperty("banner")]
        protected string BannerHash { get; set; }

        [JsonProperty("flags")]
        public uint? Flags { get; private set; }

        [JsonProperty("premium_type")]
        public NitroSubscriptionType? PremiumType { get; private set; }

        [JsonProperty("public_flags")]
        public uint? PublicFlags { get; private set; }

        public string Tag() => $"{Username}#{"0000".Remove(4 - Discriminator.ToString().Length) + Discriminator}";

        public DiscordImage Avatar
        {
            get
            {
                return new DiscordImage(this);
            }
        }
    }
}
