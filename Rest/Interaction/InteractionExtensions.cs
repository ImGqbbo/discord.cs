using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Discord
{
    public static class InteractionExtensions
    {
        public static async Task RespondToInteractionAsync(this DiscordClient client, ulong interactionId, string interactionToken, InteractionCallbackType type, InteractionResponseProperties properties)
        {
            string data = JsonConvert.SerializeObject((object)new
            {
                type = type,
                data = properties
            });
            await client.HttpClient.PostAsync(string.Format("https://discord.com/api/v9/interactions/{0}/{1}/callback", (object)interactionId, (object)interactionToken), data);
        }

        public static void RespondToInteraction(this DiscordClient client, ulong interactionId, string interactionToken, InteractionCallbackType type, InteractionResponseProperties properties)
        {
            client.RespondToInteractionAsync(interactionId, interactionToken, type, properties).GetAwaiter().GetResult();
        }

        public static async Task RespondWithModalAsync(this DiscordClient client, ulong interactionId, string interactionToken, ModalBuilder modal)
        {
            string data = JsonConvert.SerializeObject(new
            {
                type = 9,
                data = modal
            });
            await client.HttpClient.PostAsync(string.Format("https://discord.com/api/v9/interactions/{0}/{1}/callback", interactionId, interactionToken), data);
        }

        public static void RespondWithModal(this DiscordClient client, ulong interactionId, string interactionToken, ModalBuilder modal)
        {
            client.RespondWithModalAsync(interactionId, interactionToken, modal).GetAwaiter().GetResult();
        }
    }
}
