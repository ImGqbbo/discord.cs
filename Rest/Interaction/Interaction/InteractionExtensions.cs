using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Discord
{
    public static class InteractionExtensions
    {
        public static async Task RespondToInteractionAsync(this DiscordClient client, ulong interactionId, string interactionToken, InteractionCallbackType type, InteractionResponseProperties properties)
        {
            string data = JsonConvert.SerializeObject(new { type, data = properties });
            await client.HttpClient.PostAsync(string.Format("{0}/interactions/{1}/{2}/callback", DiscordClient.Handler.BaseURL, interactionId, interactionToken), data);

            if (type == InteractionCallbackType.DeferredMessage)
            {
                await client.EditInteractionResponseAsync(interactionToken, properties);
            }
        }

        public static void RespondToInteraction(this DiscordClient client, ulong interactionId, string interactionToken, InteractionCallbackType type, InteractionResponseProperties properties)
        {
            client.RespondToInteractionAsync(interactionId, interactionToken, type, properties).GetAwaiter().GetResult();
        }

        public static async Task EditInteractionResponseAsync(this DiscordClient client, string interactionToken, InteractionResponseProperties properties)
        {
            string data = JsonConvert.SerializeObject(properties);
            await client.HttpClient.PatchAsync(string.Format("{0}/webhooks/{1}/{2}/messages/@original", DiscordClient.Handler.BaseURL, client.GetCurrentUser().Id, interactionToken), data);
        }

        public static void EditInteractionResponse(this DiscordClient client, string interactionToken, InteractionResponseProperties properties)
        {
            client.EditInteractionResponseAsync(interactionToken, properties).GetAwaiter().GetResult();
        }

        public static async Task RespondWithModalAsync(this DiscordClient client, ulong interactionId, string interactionToken, ModalBuilder modal)
        {
            string data = JsonConvert.SerializeObject(new
            {
                type = 9,
                data = modal
            });
            await client.HttpClient.PostAsync(string.Format("{0}/interactions/{0}/{1}/callback", DiscordClient.Handler.BaseURL, interactionId, interactionToken), data);
        }

        public static void RespondWithModal(this DiscordClient client, ulong interactionId, string interactionToken, ModalBuilder modal)
        {
            client.RespondWithModalAsync(interactionId, interactionToken, modal).GetAwaiter().GetResult();
        }

        public static SlashCommandOption GetOption(this List<SlashCommandOption> list, string name)
        {
            foreach (var option in list)
            {
                if (option.Name.ToLower() == name.ToLower())
                {
                    return option;
                }
            }

            throw new ArgumentException("Cannot find that option.");
        }

        public static T GetOptionValue<T>(this List<SlashCommandOption> list, string name)
        {
            var opt = GetOption(list, name);

            return (T)Convert.ChangeType(opt.Value, typeof(T));
        }
    }
}
