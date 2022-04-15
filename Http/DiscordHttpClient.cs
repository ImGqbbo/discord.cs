using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Discord.Http
{
    public class DiscordHttpClient
    {
        private static DiscordClient _client;
        private static HttpClient _httpClient;

        private string _baseUrl;

        public DiscordHttpClient(DiscordClient client)
        {
            _client = client;
            _httpClient = new HttpClient();
            _baseUrl = "https://discord.com/api/v" + (ushort)_client.Handler.ApiVersion;
        }

        private async Task<DiscordHttpResponse> RawAsync(HttpMethod method, string endpoint, string data = null)
        {
            if (endpoint.StartsWith("https://discord.com/api/v9"))
            {
                endpoint = endpoint.Replace("https://discord.com/api/v9", _baseUrl);
            }

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", _client.Token);
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "discord.cs/0.1");

            if (data != null)
                _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");

            HttpRequestMessage message = new HttpRequestMessage()
            {
                RequestUri = new Uri(endpoint),
                Method = method
            };

            if (data != null)
                message.Content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.SendAsync(message);
            DiscordHttpResponse discordHttpResponse = new DiscordHttpResponse()
            {
                Result = await response.Content.ReadAsStringAsync(),
                StatusCode = response.StatusCode
            };

            if (_client.logHttp)
            {
                Console.WriteLine($"[Http] Response from ({endpoint}) => {discordHttpResponse.Result}");
            }

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
