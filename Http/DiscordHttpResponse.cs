using System.Net;

namespace Discord.Http
{
    public class DiscordHttpResponse
    {
        public string Result { get; internal set; }

        public HttpStatusCode StatusCode { get; internal set; }
    }
}
