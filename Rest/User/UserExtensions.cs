using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace Discord
{
    public static class UserExtensions
    {
        public static async Task<DiscordClientUser> GetCurrentUserAsync(this DiscordClient client)
        {
            var response = await client.HttpClient.GetAsync(string.Format("{0}/users/@me", DiscordClient.Handler.BaseURL));
            return JsonConvert.DeserializeObject<DiscordClientUser>(response.Result);
        }

        public static async Task<DiscordUser> GetUserAsync(this DiscordClient client, ulong userId)
        {
            var response = await client.HttpClient.GetAsync(string.Format("{0}/users/{1}", DiscordClient.Handler.BaseURL, userId));
            return JsonConvert.DeserializeObject<DiscordUser>(response.Result);
        }

        public static DiscordClientUser GetCurrentUser(this DiscordClient client)
        {
            return GetCurrentUserAsync(client).GetAwaiter().GetResult();
        }

        public static DiscordUser GetUser(this DiscordClient client, ulong userId)
        {
            return GetUserAsync(client, userId).GetAwaiter().GetResult();
        }

        public static async Task<ulong> CreateDMAsync(this DiscordClient client, ulong userId)
        {
            var response = await client.HttpClient.PostAsync(string.Format("{0}/users/@me/channels", DiscordClient.Handler.BaseURL), "{\"recipient_id\":\"" + userId + "\"}");
            JObject parsed = JObject.Parse(response.Result);

            return parsed.Value<ulong>("id");
        }

        public static ulong CreateDM(this DiscordClient client, ulong userId)
        {
            return client.CreateDMAsync(userId).GetAwaiter().GetResult();
        }
    }
}
