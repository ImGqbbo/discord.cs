using Discord.Http;
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

        public WebProxy Proxy { get; set; }

        public DiscordClientUser User { get; private set; }

        internal bool _logResponses;

        public DiscordClient()
        {
            HttpClient = new DiscordHttpClient(this);
        }

        public DiscordClient(string token, bool logHttpResponses = false)
        {
            HttpClient = new DiscordHttpClient(this);

            Token = "Bot " + token;
            _logResponses = logHttpResponses;
        }
    }
}
