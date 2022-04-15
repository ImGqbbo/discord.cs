using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Discord.Gateway
{
    public static class GuildMembersExtensions
    {
        public static Task<IReadOnlyList<GuildMember>> RequestGuildMembersAsync(this DiscordSocketClient client, ulong guildId, uint limit = 0)
        {
            TaskCompletionSource<IReadOnlyList<GuildMember>> task = new TaskCompletionSource<IReadOnlyList<GuildMember>>();

            void Handle(DiscordSocketClient c, GuildMembersChunkEventArgs e)
            {
                if (e.GuildId == guildId)
                {
                    task.SetResult(e.Members);

                    client.OnGuildMembersReceived -= Handle;
                }
            }

            client.OnGuildMembersReceived += Handle;
            client.session.Send(JsonConvert.SerializeObject(new { op = 8, d = new { guild_id = guildId.ToString(), limit, query = "" } }));

            return task.Task;
        }

        public static IReadOnlyList<GuildMember> RequestGuildMembers(this DiscordSocketClient client, ulong guildId, uint limit = 0)
        {
            return client.RequestGuildMembersAsync(guildId, limit).GetAwaiter().GetResult();
        }
    }
}
