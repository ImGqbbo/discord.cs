using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Discord
{
    public static class GuildMemberExtensions
    {
        public static async Task AddRoleAsync(this DiscordClient client, ulong guildId, ulong memberId, ulong roleId)
        {
            await client.HttpClient.PutAsync(string.Format("{0}/guilds/{1}/members/{2}/roles/{3}", DiscordClient.Handler.BaseURL, guildId, memberId, roleId));
        }

        public static void AddRole(this DiscordClient client, ulong guildId, ulong memberId, ulong roleId)
        {
            client.AddRoleAsync(guildId, memberId, roleId).GetAwaiter().GetResult();
        }

        public static async Task RemoveRoleAsync(this DiscordClient client, ulong guildId, ulong memberId, ulong roleId)
        {
            await client.HttpClient.DeleteAsync(string.Format("{0}/guilds/{1}/members/{2}/roles/{3}", DiscordClient.Handler.BaseURL, guildId, memberId, roleId));
        }

        public static void RemoveRole(this DiscordClient client, ulong guildId, ulong memberId, ulong roleId)
        {
            client.RemoveRoleAsync(guildId, memberId, roleId).GetAwaiter().GetResult();
        }

        public static async Task TimeoutMemberAsync(this DiscordClient client, ulong guildId, ulong memberId, TimeSpan duration)
        {
            await client.HttpClient.PatchAsync(string.Format("{0}/guilds/{1}/members/{2}", DiscordClient.Handler.BaseURL, guildId, memberId), JsonConvert.SerializeObject(new
            {
                communication_disabled_until = (DateTime.Now + duration)
            }));
        }

        public static void TimeoutMember(this DiscordClient client, ulong guildId, ulong memberId, TimeSpan duration)
        {
            client.TimeoutMemberAsync(guildId, memberId, duration).GetAwaiter().GetResult();
        }

        public static async Task RemoveTimeoutAsync(this DiscordClient client, ulong guildId, ulong memberId)
        {
            await client.HttpClient.PatchAsync(string.Format("{0}/guilds/{1}/members/{2}", DiscordClient.Handler.BaseURL, guildId, memberId), "{\"communication_disabled_until\":null}");
        }

        public static void RemoveTimeout(this DiscordClient client, ulong guildId, ulong memberId)
        {
            client.RemoveTimeoutAsync(guildId, memberId).GetAwaiter().GetResult();
        }

        public static async Task ModifyGuildMemberAsync(this DiscordClient client, ulong guildId, ulong memberId, GuildMemberProperties properties)
        {
            await client.HttpClient.PatchAsync(string.Format("{0}/guilds/{1}/members/{2}", DiscordClient.Handler.BaseURL, guildId, memberId), JsonConvert.SerializeObject(properties));
        }

        public static void ModifyGuildMember(this DiscordClient client, ulong guildId, ulong memberId, GuildMemberProperties properties)
        {
            client.ModifyGuildMemberAsync(guildId, memberId, properties).GetAwaiter().GetResult();
        }

        public static async Task BanUserAsync(this DiscordClient client, ulong guildId, ulong userId, string reason = null, uint deleteMessagesDays = 0)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", client.Token);

            if (reason != null && reason != "")
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("X-Audit-Log-Reason", reason);

            await httpClient.PutAsync(string.Format("{0}/guilds/{1}/bans/{2}", DiscordClient.Handler.BaseURL, guildId, userId), new StringContent(JsonConvert.SerializeObject(new
            {
                delete_message_days = deleteMessagesDays,
            }), System.Text.Encoding.UTF8, "application/json"));
        }

        public static void BanUser(this DiscordClient client, ulong guildId, ulong userId, string reason = null, uint deleteMessagesDays = 0)
        {
            client.BanUserAsync(guildId, userId, reason, deleteMessagesDays).GetAwaiter().GetResult();
        }

        public static async Task KickGuildMemberAsync(this DiscordClient client, ulong guildId, ulong memberId)
        {
            await client.HttpClient.DeleteAsync(string.Format("{0}/guilds/{1}/members/{2}", DiscordClient.Handler.BaseURL, guildId, memberId));
        }

        public static void KickGuildMember(this DiscordClient client, ulong guildId, ulong memberId)
        {
            client.KickGuildMemberAsync(guildId, memberId).GetAwaiter().GetResult();
        }

        public static async Task<GuildBan> GetGuildBanAsync(this DiscordClient client, ulong guildId, ulong userId)
        {
            return JsonConvert.DeserializeObject<GuildBan>((await client.HttpClient.GetAsync(string.Format("{0}/guilds/{1}/bans/{2}", DiscordClient.Handler.BaseURL, guildId, userId))).Result);
        }

        public static GuildBan GetGuildBan(this DiscordClient client, ulong guildId, ulong userId)
        {
            return client.GetGuildBanAsync(guildId, userId).GetAwaiter().GetResult();
        }

        public static async Task UnbanUserAsync(this DiscordClient client, ulong guildId, ulong userId)
        {
            await client.HttpClient.DeleteAsync(string.Format("{0}/guilds/{1}/bans/{2}", DiscordClient.Handler.BaseURL, guildId, userId));
        }

        public static void UnbanUser(this DiscordClient client, ulong guildId, ulong userId)
        {
            client.UnbanUserAsync(guildId, userId).GetAwaiter().GetResult();
        }

        public static async Task<IReadOnlyList<GuildBan>> GetGuildBansAsync(this DiscordClient client, ulong guildId, uint limit = 1000)
        {
            if (limit > 1000)
                throw new InvalidOperationException("Cannot request more than 1000 bans.");

            return JsonConvert.DeserializeObject<IReadOnlyList<GuildBan>>((await client.HttpClient.GetAsync(string.Format("{0}/guilds/{1}/bans?limit={2}", DiscordClient.Handler.BaseURL, guildId, limit))).Result);
        }

        public static IReadOnlyList<GuildBan> GetGuildBans(this DiscordClient client, ulong guildId, uint limit = 1000)
        {
            return client.GetGuildBansAsync(guildId, limit).GetAwaiter().GetResult();
        }
    }
}
