using Discord.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Discord
{
    public static class SlashCommandsExtensions
    {
        public static async Task BulkOverwriteGlobalSlashCommandsAsync(this DiscordClient client, List<SlashCommandBuilder> commands)
        {
            var res = await client.HttpClient.PutAsync(string.Format("https://discord.com/api/v9/applications/{0}/commands", client.User.Id), JsonConvert.SerializeObject(commands));
        }

        public static void BulkOverwriteGlobalSlashCommands(this DiscordClient client, List<SlashCommandBuilder> commands)
        {
            client.BulkOverwriteGlobalSlashCommandsAsync(commands).GetAwaiter().GetResult();
        }

        public static async Task<ApplicationCommand> RegisterGlobalSlashCommandAsync(this DiscordClient client, SlashCommandBuilder properties)
        {
            var res = await client.HttpClient.PostAsync(string.Format("https://discord.com/api/v9/applications/{0}/commands", client.User.Id), JsonConvert.SerializeObject(properties));
            return JsonConvert.DeserializeObject<ApplicationCommand>(res.Result);
        }

        public static ApplicationCommand RegisterGlobalSlashCommand(this DiscordClient client, SlashCommandBuilder properties)
        {
            return client.RegisterGlobalSlashCommandAsync(properties).GetAwaiter().GetResult();
        }

        public static async Task<ApplicationCommand> RegisterGuildSlashCommandAsync(this DiscordClient client, ulong guildId, SlashCommandBuilder properties)
        {
            var res = await client.HttpClient.PostAsync(string.Format("https://discord.com/api/v9/applications/{0}/guilds/{1}/commands", client.User.Id, guildId), JsonConvert.SerializeObject(properties));
            return JsonConvert.DeserializeObject<ApplicationCommand>(res.Result);
        }

        public static ApplicationCommand RegisterGuildSlashCommand(this DiscordClient client, ulong guildId, SlashCommandBuilder properties)
        {
            return client.RegisterGuildSlashCommandAsync(guildId, properties).GetAwaiter().GetResult();
        }

        public static async Task DeleteSlashCommandAsync(this DiscordClient client, ulong commandId)
        {
            await client.HttpClient.DeleteAsync(string.Format("https://discord.com/api/v9/applications/{0}/commands/{1}", client.User.Id, commandId));
        }

        public static void DeleteSlashCommand(this DiscordClient client, ulong commandId)
        {
            client.DeleteSlashCommandAsync(commandId).GetAwaiter().GetResult();
        }

        public static async Task<IReadOnlyList<ApplicationCommand>> GetGlobalSlashCommandsAsync(this DiscordClient client)
        {
            var res = await client.HttpClient.GetAsync(string.Format("https://discord.com/api/v9/applications/{0}/commands", client.User.Id));
            return JsonConvert.DeserializeObject<IReadOnlyList<ApplicationCommand>>(res.Result);
        }

        public static IReadOnlyList<ApplicationCommand> GetGlobalSlashCommands(this DiscordClient client)
        {
            return client.GetGlobalSlashCommandsAsync().GetAwaiter().GetResult();
        }

        public static async Task DeleteAllCommandsAsync(this DiscordClient client)
        {
            foreach (ApplicationCommand command in await client.GetGlobalSlashCommandsAsync())
            {
                await client.DeleteSlashCommandAsync(command.Id);
            }
        }

        public static void DeleteAllCommands(this DiscordClient client)
        {
            client.DeleteAllCommandsAsync().GetAwaiter().GetResult();
        }
    }
}
