using Discord.Http;
using System;
using System.Net;

namespace Discord
{
    public class DiscordClient
    {
        private string _token { get; set; }
        public string Token
        {
            get
            {
                return _token;
            }
            set
            {
                _token = value;

                User = this.GetCurrentUser();
            }
        }

        public DiscordHttpClient HttpClient { get; internal set; }

        public DiscordHandler Handler { get; set; }

        public WebProxy Proxy { get; set; }

        public DiscordClientUser User { get; private set; }

        public bool logHttp { get; set; } = false;

        public DiscordClient()
        {
            Handler = new DiscordHandler() { ApiVersion = ApiVersion.V9 };
            HttpClient = new DiscordHttpClient(this);
        }

        public DiscordClient(string token)
        {
            Handler = new DiscordHandler() { ApiVersion = ApiVersion.V9 };
            HttpClient = new DiscordHttpClient(this);
            Token = "Bot " + token;
        }

        public DiscordClient(string token, DiscordHandler handler)
        {
            Handler = handler;
            HttpClient = new DiscordHttpClient(this);
            Token = "Bot " + token;
        }
    }
}
