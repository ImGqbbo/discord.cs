using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Discord
{
    public static class GuildMemberExtensions
    {
        public static async Task AddRoleAsync(this DiscordClient client, ulong guildId, ulong memberId, ulong roleId)
        {
            await client.HttpClient.PutAsync(string.Format("https://discord.com/api/v9/guilds/{0}/members/{1}/roles/{2}", guildId, memberId, roleId));
        }

        public static void AddRole(this DiscordClient client, ulong guildId, ulong memberId, ulong roleId)
        {
            client.AddRoleAsync(guildId, memberId, roleId).GetAwaiter().GetResult();
        }

        public static async Task RemoveRoleAsync(this DiscordClient client, ulong guildId, ulong memberId, ulong roleId)
        {
            await client.HttpClient.DeleteAsync(string.Format("https://discord.com/api/v9/guilds/{0}/members/{1}/roles/{2}", guildId, memberId, roleId));
        }

        public static void RemoveRole(this DiscordClient client, ulong guildId, ulong memberId, ulong roleId)
        {
            client.RemoveRoleAsync(guildId, memberId, roleId).GetAwaiter().GetResult();
        }

        public static async Task TimeoutMemberAsync(this DiscordClient client, ulong guildId, ulong memberId, TimeSpan duration)
        {
            await client.HttpClient.PatchAsync(string.Format("https://discord.com/api/v9/guilds/{0}/members/{1}", guildId, memberId), JsonConvert.SerializeObject(new
            {
                communication_disabled_until = (DateTime.Now + duration)
            }));
        }

        public static void TimeoutMember(this DiscordClient client, ulong guildId, ulong memberId, TimeSpan duration)
        {
            client.TimeoutMemberAsync(guildId, memberId, duration).GetAwaiter().GetResult();
        }

        public static async Task ModifyGuildMemberAsync(this DiscordClient client, ulong guildId, ulong memberId, GuildMemberProperties properties)
        {
            await client.HttpClient.PatchAsync(string.Format("https://discord.com/api/v9/guilds/{0}/members/{1}", guildId, memberId), JsonConvert.SerializeObject(properties));
        }
    }
}
