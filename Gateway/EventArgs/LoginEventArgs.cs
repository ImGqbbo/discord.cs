using Newtonsoft.Json;

namespace Discord.Gateway
{
    public class LoginEventArgs
    {
        [JsonProperty("user")]
        public DiscordClientUser User { get; private set; }
    }
}
