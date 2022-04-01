using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Discord.Http
{
    public class DiscordHttpClient
    {
        private static HttpClient httpClient;
        public string Token;
        public WebProxy Proxy;

        public DiscordHttpClient()
        {
            if (Proxy != null)
                httpClient = new HttpClient(new HttpClientHandler()
                {
                    Proxy = Proxy,
                    UseProxy = true
                });
            else
                httpClient = new HttpClient();
        }

        private async Task<DiscordHttpResponse> RawAsync(HttpMethod method, string endpoint, string data = null)
        {
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", Token);
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "discord.cs/1.0");
            if (data != null)
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");

            HttpRequestMessage message = new HttpRequestMessage()
            {
                RequestUri = new Uri(endpoint),
                Method = method
            };
            if (data != null)
                message.Content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.SendAsync(message);
            DiscordHttpResponse discordHttpResponse = new DiscordHttpResponse()
            {
                Result = response.Content.ReadAsStringAsync().Result,
                StatusCode = response.StatusCode
            };

            return discordHttpResponse;
        }

        public async Task<DiscordHttpResponse> PostAsync(string endpoint, string data = null)
        {
            DiscordHttpResponse discordHttpResponse = await RawAsync(HttpMethod.Post, endpoint, data);
            return discordHttpResponse;
        }

        public async Task<DiscordHttpResponse> PatchAsync(string endpoint, string data = null)
        {
            DiscordHttpResponse discordHttpResponse = await RawAsync(new HttpMethod("PATCH"), endpoint, data);
            return discordHttpResponse;
        }

        public async Task<DiscordHttpResponse> DeleteAsync(string endpoint, string data = null)
        {
            DiscordHttpResponse discordHttpResponse = await RawAsync(HttpMethod.Delete, endpoint, data);
            return discordHttpResponse;
        }

        public async Task<DiscordHttpResponse> PutAsync(string endpoint, string data = null)
        {
            DiscordHttpResponse discordHttpResponse = await RawAsync(HttpMethod.Put, endpoint, data);
            return discordHttpResponse;
        }

        public async Task<DiscordHttpResponse> GetAsync(string endpoint)
        {
            DiscordHttpResponse async = await RawAsync(HttpMethod.Get, endpoint);
            return async;
        }
    }
}
