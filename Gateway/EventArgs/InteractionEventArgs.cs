using Newtonsoft.Json;
using System;

namespace Discord.Gateway
{
    public class InteractionEventArgs
    {
        [JsonProperty("id")]
        public ulong InteractionId { get; private set; }

        [JsonProperty("application_id")]
        public ulong ApplicationId { get; private set; }

        [JsonProperty("data")]
        public InteractionData Data { get; private set; }

        [JsonProperty("guild_id")]
        public ulong GuildId { get; private set; }

        [JsonProperty("channel_id")]
        public ulong ChannelId { get; private set; }

        [JsonProperty("member")]
        public GuildMember Member { get; private set; }

        [JsonProperty("message")]
        public DiscordMessage Message { get; private set; }

        [JsonProperty("locale")]
        public string Locale { get; private set; }

        [JsonProperty("token")]
        public string InteractionToken { get; private set; }

        [JsonProperty("type")]
        public InteractionType Type { get; private set; }

        public bool IsCommand() => Type == InteractionType.ApplicationCommand;
        
        public SlashCommandOption GetSubCommand()
        {
            foreach (var option in Data.Options)
            {
                if (option.Type == ApplicationOptionType.SubCommand)
                {
                    return option;
                }
            }

            throw new ArgumentException("Cannot find that option.");
        }
    }
}
