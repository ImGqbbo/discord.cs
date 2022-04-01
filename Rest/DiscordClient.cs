using Discord.Http;
using System.Net;

namespace Discord
{
    public class DiscordClient
    {
        public string Token { get; set; }

        public DiscordHttpClient HttpClient { get; internal set; }

        public WebProxy Proxy { get; set; }

        public DiscordClient() => this.HttpClient = new DiscordHttpClient()
        {
            Proxy = this.Proxy,
            Token = this.Token
        };

        public DiscordClient(string token)
        {
            Token = "Bot " + token;
            HttpClient = new DiscordHttpClient()
            {
                Proxy = Proxy,
                Token = Token
            };
        }
    }
}
