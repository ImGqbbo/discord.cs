﻿using Newtonsoft.Json;

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

        /// <summary>
        /// This function returns the timestamp of when the user was created.
        /// To take the timestamp you need to convert the Snowflake, which is the user id. (For Snowflake: https://discord.com/developers/docs/reference#snowflakes).
        /// You need to divide the user id for 2^22, add the Discord epoch (1420070400000 = the first second of 2015) and divide for milliseconds per second (1000).
        /// </summary>
        /// <returns>The timestamp of when the user was created.</returns>
        public string createdAtTimestamp() => (Id / 2^22 + 1420070400000) / 1000;

        /// <summary>
        /// Convert the timestamp of when the user was created into a DateTime.
        /// </summary>
        /// <returns>The DateTime of when the user was created.</returns>
        public string createdAt() => new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(Math.Round(createdAtTimestamp() / 1000d)).ToLocalTime();

        public string Tag() => $"{Username}#{"0000".Remove(4 - Discriminator.ToString().Length) + Discriminator}";

        public DiscordImage Avatar
        {
            get
            {
                return new DiscordImage(this);
            }
        }

        public DiscordImage DefaultAvatar
        {
            get
            {
                return new DefaultDiscordImage(this);
            }
        }
    }
}
