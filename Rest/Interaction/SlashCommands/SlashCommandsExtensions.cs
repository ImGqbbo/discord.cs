using Discord.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Discord
{
    public static class SlashCommandsExtensions
    {
        public static async Task<SlashCommand> RegisterGlobalSlashCommandAsync(this DiscordClient client, ulong appId, SlashCommandBuilder properties)
        {
            DiscordHttpResponse discordHttpResponse = await client.HttpClient.PostAsync(string.Format("https://discord.com/api/v9/applications/{0}/commands", appId), JsonConvert.SerializeObject(properties));
            return JsonConvert.DeserializeObject<SlashCommand>(discordHttpResponse.Result);
        }

        public static SlashCommand RegisterGlobalSlashCommand(this DiscordClient client, ulong appId, SlashCommandBuilder properties)
        {
            return client.RegisterGlobalSlashCommandAsync(appId, properties).GetAwaiter().GetResult();
        }

        public static async Task DeleteSlashCommandAsync(this DiscordClient client, ulong appId, ulong commandId)
        {
            await client.HttpClient.DeleteAsync(string.Format("https://discord.com/api/v9/applications/{0}/commands/{1}", appId, commandId));
        }

        public static void DeleteSlashCommand(this DiscordClient client, ulong appId, ulong commandId) => client.DeleteSlashCommandAsync(appId, commandId).GetAwaiter().GetResult();

        public static async Task<IReadOnlyList<SlashCommand>> GetGlobalSlashCommandsAsync(this DiscordClient client, ulong appId)
        {
            DiscordHttpResponse async = await client.HttpClient.GetAsync(string.Format("https://discord.com/api/v9/applications/{0}/commands", appId));
            return JsonConvert.DeserializeObject<IReadOnlyList<SlashCommand>>(async.Result);
        }

        public static IReadOnlyList<SlashCommand> GetGlobalSlashCommands(this DiscordClient client, ulong appId)
        {
            return client.GetGlobalSlashCommandsAsync(appId).GetAwaiter().GetResult();
        }
    }
}
