using Discord;
using Discord.Gateway;
using System;

namespace ModerateBot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Insert your token: ");
            string token = Console.ReadLine();

            DiscordSocketClient client = new DiscordSocketClient(new DiscordSocketHandler()
            {
                ApiVersion = ApiVersion.V9,
            }, false);

            client.Authenticate(token);
            client.OnInteractionCreated += (s, e) =>
            {
                if (!e.IsCommand()) return;

                var subCmd = e.GetSubCommand();
                ulong member = subCmd.Options.GetOptionValue<ulong>("target");
                switch (subCmd.Name)
                {
                    case "mute":
                        TimeSpan time = new TimeSpan();
                        switch (subCmd.Options.GetOption("time").Value)
                        {
                            case "5m":
                                time = TimeSpan.FromMinutes(5);
                                break;
                            case "1h":
                                time = TimeSpan.FromHours(1);
                                break;
                            case "24h":
                                time = TimeSpan.FromHours(24);
                                break;
                            case "1w":
                                time = TimeSpan.FromDays(7);
                                break;
                            case "1m":
                                time = TimeSpan.FromDays(28);
                                break;
                        }

                        if (member == e.GuildId)
                        {
                            client.RespondToInteraction(e.InteractionId, e.InteractionToken, InteractionCallbackType.DeferredMessage, new InteractionResponseProperties()
                            {
                                Content = $"You cannot mute everyone",
                                Ephemeral = true,
                            });
                            break;
                        }

                        client.TimeoutMember(e.GuildId, member, time);
                        client.RespondToInteraction(e.InteractionId, e.InteractionToken, InteractionCallbackType.DeferredMessage, new InteractionResponseProperties()
                        {
                            Content = $"Succesfully muted `{member}` for `{time.Days}d {time.Hours}h {time.Minutes}m {time.Seconds}s`",
                            Ephemeral = true,
                        });
                        break;
                    case "unmute":
                        if (member == e.GuildId)
                        {
                            client.RespondToInteraction(e.InteractionId, e.InteractionToken, InteractionCallbackType.DeferredMessage, new InteractionResponseProperties()
                            {
                                Content = $"You cannot unmute everyone",
                                Ephemeral = true,
                            });
                            break;
                        }

                        client.RemoveTimeout(e.GuildId, member);
                        client.RespondToInteraction(e.InteractionId, e.InteractionToken, InteractionCallbackType.DeferredMessage, new InteractionResponseProperties()
                        {
                            Content = $"Succesfully unmuted `{member}`",
                            Ephemeral = true,
                        });
                        break;
                }
            };
            client.OnLoggedIn += (s, e) =>
            {
                Console.WriteLine("Logged in as: " + e.User.Tag());

                SlashCommandBuilder mutecmd = new SlashCommandBuilder()
                .SetName("member")
                .SetDescription("Manage a member")
                .AddOption(
                    new SlashOptionBuilder()
                    .SetName("mute")
                    .SetDescription("Mute a member")
                    .SetType(ApplicationOptionType.SubCommand)
                    .AddOption(
                        new SlashOptionBuilder()
                        .SetRequired(true)
                        .SetName("target")
                        .SetDescription("The member you want to mute")
                        .SetType(ApplicationOptionType.Mentionable)
                    )                
                    .AddOption(
                        new SlashOptionBuilder()
                        .SetRequired(true)
                        .SetName("time")
                        .SetDescription("The amount of time")
                        .SetType(ApplicationOptionType.String)
                        .AddChoice("5 minutes", "5m")
                        .AddChoice("1 hours", "1h")
                        .AddChoice("24 hours", "24h")
                        .AddChoice("1 week", "1w")
                        .AddChoice("1 month", "1m")
                    )
                )
                .AddOption(
                    new SlashOptionBuilder()
                    .SetName("unmute")
                    .SetDescription("Unmute a member")
                    .SetType(ApplicationOptionType.SubCommand)
                    .AddOption(
                        new SlashOptionBuilder()
                        .SetRequired(true)
                        .SetName("target")
                        .SetDescription("The member you want to unmute")
                        .SetType(ApplicationOptionType.Mentionable)
                    )
                );

                client.RegisterGlobalSlashCommand(mutecmd);
            };

            Console.ReadLine();
        }
    }
}
