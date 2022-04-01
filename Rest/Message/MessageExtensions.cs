using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Discord
{
    public static class MessageExtensions
    {
        public static async Task SendMessageAsync(
          this DiscordClient client, ulong channelId, string message, bool tts = false)
        {
            await client.HttpClient.PostAsync(string.Format("https://discord.com/api/v9/channels/{0}/messages", (object)channelId), JsonConvert.SerializeObject((object)new
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
            await client.HttpClient.PostAsync(string.Format("https://discord.com/api/v9/channels/{0}/messages", (object)channelId), JsonConvert.SerializeObject((object)properties));
        }

        public static void SendMessage(this DiscordClient client, ulong channelId, MessageProperties properties)
        {
            client.SendMessageAsync(channelId, properties).GetAwaiter().GetResult();
        }
    }
}
