using Discord;

namespace Discord.Gateway
{
    public class DiscordSocketHandler
    {
        public DiscordSocketHandler()
        {

        }

        public DiscordGateawayIntent Intents { get; set; }
        public ApiVersion ApiVersion = ApiVersion.Default;
    }
}
