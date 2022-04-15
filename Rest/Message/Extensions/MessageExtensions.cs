using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Discord
{
    public static class MessageExtensions
    {
        public static async Task SendMessageAsync(this DiscordClient client, ulong channelId, string message, bool tts = false)
        {
            await client.HttpClient.PostAsync(string.Format("{0}/channels/{1}/messages", DiscordClient.Handler.BaseURL, channelId), JsonConvert.SerializeObject(new
            {
                content = message,
                tts = tts
            }));
        }

        public static void SendMessage(this DiscordClient client, ulong channelId, string message, bool tts = false)
        {
            client.SendMessageAsync(channelId, message, tts).GetAwaiter().GetResult();
        }

        public static async Task SendMessageAsync(this DiscordClient client, ulong channelId, MessageProperties properties)
        {
            await client.HttpClient.PostAsync(string.Format("{0}/channels/{1}/messages", DiscordClient.Handler.BaseURL, channelId), JsonConvert.SerializeObject(properties));
        }

        public static void SendMessage(this DiscordClient client, ulong channelId, MessageProperties properties)
        {
            client.SendMessageAsync(channelId, properties).GetAwaiter().GetResult();
        }

        public static async Task EditMessageAsync(this DiscordClient client, ulong channelId, ulong messageId, MessageProperties properties)
        {
            await client.HttpClient.PatchAsync(string.Format("{0}/channels/{1}/messages/{2}", DiscordClient.Handler.BaseURL, channelId, messageId), JsonConvert.SerializeObject(properties));
        }

        public static void EditMessage(this DiscordClient client, ulong channelId, ulong messageId, MessageProperties properties)
        {
            client.EditMessageAsync(channelId, messageId, properties).GetAwaiter().GetResult();
        }

        public static async Task EditMessageAsync(this DiscordClient client, ulong channelId, ulong messageId, string message, bool tts = false)
        {
            await client.HttpClient.PatchAsync(string.Format("{0}/channels/{1}/messages/{2}", DiscordClient.Handler.BaseURL, channelId, messageId), JsonConvert.SerializeObject(new
            {
                content = message,
                tts = tts
            }));
        }

        public static void EditMessage(this DiscordClient client, ulong channelId, ulong messageId, string message, bool tts = false)
        {
            client.EditMessageAsync(channelId, messageId, message, tts).GetAwaiter().GetResult();
        }

        public static async Task DeleteMessageAsync(this DiscordClient client, ulong channelId, ulong messageId)
        {
            await client.HttpClient.DeleteAsync(string.Format("{0}/channels/{1}/messages/{2}", DiscordClient.Handler.BaseURL, channelId, messageId));
        }

        public static void DeleteMessage(this DiscordClient client, ulong channelId, ulong messageId)
        {
            client.DeleteMessageAsync(channelId, messageId).GetAwaiter().GetResult();
        }
    }
}
