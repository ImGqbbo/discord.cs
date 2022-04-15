using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Discord.Gateway
{
    public class DiscordSocketClient : DiscordClient
    {
        internal DiscordSocketSession session;

        public event DiscordClientEventHandler<InteractionEventArgs> OnInteractionCreated;
        public event DiscordClientEventHandler<MessageEventArgs> OnMessageCreated;
        public event DiscordClientEventHandler<MessageEventArgs> OnMessageUpdated;
        public event DiscordClientEventHandler<InteractionEventArgs> OnModalSubmit;
        public event DiscordClientEventHandler<LoginEventArgs> OnLoggedIn;
        public event DiscordClientEventHandler<SocketGuild> OnGuildCreated;
        public event DiscordClientEventHandler<SocketGuild> OnGuildUpdated;
        public event DiscordClientEventHandler<UnavailableGuild> OnGuildDeleted;
        public event DiscordClientEventHandler<DiscordThread> OnThreadCreated;
        public event DiscordClientEventHandler<DiscordThread> OnThreadUpdated;
        public event DiscordClientEventHandler<DiscordThread> OnThreadDeleted;
        public event DiscordClientEventHandler<GuildMembersChunkEventArgs> OnGuildMembersReceived;

        public DiscordSocketClient(DiscordHandler handler)
        {
            session = new DiscordSocketSession(handler);
        }

        public DiscordSocketClient()
        {
            session = new DiscordSocketSession(new DiscordHandler() { ApiVersion = ApiVersion.V9 });
        }

        public void Authenticate(string token)
        {
            Token = "Bot " + token;

            session.Send(JsonConvert.SerializeObject(new
            {
                op = 2,
                d = new
                {
                    token = Token,
                    properties = new
                    {
                        os = "Windows",
                        browser = "discord.cs/1.0",
                        device = ""
                    },
                    presence = new { status = "online", afk = false },
                    intents = 32767,
                }
            }));
            session.webSocket.OnMessage += HandleMessages;
        }

        public void SetActivity(string name, ActivityType type, DiscordStatus status)
        {
            string realStatusNoScam = status.ToString().ToLower();
            if (status == DiscordStatus.DoNotDisturb) realStatusNoScam = "dnd";

            string data = JsonConvert.SerializeObject(new
            {
                op = 3,
                d = new
                {
                    since = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
                    activities = new List<object>()
                    {
                        new
                        {
                            name,
                            type,
                        }
                    },
                    status = realStatusNoScam,
                    afk = false,
                },
            });

            session.Send(data);
        }

        public void Logout() => session.webSocket.Close();

        private void HandleMessages(object sender, WebSocketSharp.MessageEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                JObject token = JObject.Parse(e.Data);
                if(logHttp) Console.WriteLine(token);

                if (token.Value<int>("op") == 10)
                {
                    Task.Run(() =>
                    {
                        int millisecondsTimeout = token["d"].Value<int>("heartbeat_interval");
                        while (true)
                        {
                            session.Send(JsonConvert.SerializeObject((object)new
                            {
                                op = 1,
                                d = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
                            }));
                            Thread.Sleep(millisecondsTimeout);
                        }
                    });
                }

                string t = token.Value<string>("t");

                switch (t)
                {
                    case "INTERACTION_CREATE":
                        InteractionEventArgs args = token["d"].ToObject<InteractionEventArgs>();
                        if (args.Type == InteractionType.ModalSubmit)
                        {
                            DiscordClientEventHandler<InteractionEventArgs> onModalSubmit = OnModalSubmit;
                            if (onModalSubmit != null)
                                onModalSubmit(this, args);
                        }
                        else
                        {
                            DiscordClientEventHandler<InteractionEventArgs> onInteractionCreated = OnInteractionCreated;
                            if (onInteractionCreated != null)
                                onInteractionCreated(this, args);
                        }
                        break;
                    case "MESSAGE_CREATE":
                        MessageEventArgs args1 = token["d"].ToObject<MessageEventArgs>();
                        DiscordClientEventHandler<MessageEventArgs> onMessageCreated = OnMessageCreated;
                        if (onMessageCreated != null)
                            onMessageCreated(this, args1);
                        break;
                    case "MESSAGE_UPDATE":
                        MessageEventArgs args2 = token["d"].ToObject<MessageEventArgs>();
                        DiscordClientEventHandler<MessageEventArgs> onMessageUpdated = OnMessageUpdated;
                        if (onMessageUpdated != null)
                            onMessageUpdated(this, args2);
                        break;
                    case "READY":
                        LoginEventArgs args3 = token["d"].ToObject<LoginEventArgs>();
                        DiscordClientEventHandler<LoginEventArgs> onLoggedIn = OnLoggedIn;
                        if (onLoggedIn != null)
                            onLoggedIn(this, args3);
                        break;
                    case "GUILD_CREATE":
                        SocketGuild args4 = token["d"].ToObject<SocketGuild>();
                        DiscordClientEventHandler<SocketGuild> onGuildCreated = OnGuildCreated;
                        if (onGuildCreated != null)
                            onGuildCreated(this, args4);
                        break;
                    case "GUILD_UPDATE":
                        SocketGuild args5 = token["d"].ToObject<SocketGuild>();
                        DiscordClientEventHandler<SocketGuild> onGuildUpdated = OnGuildUpdated;
                        if (onGuildUpdated != null)
                            onGuildUpdated(this, args5);
                        break;
                    case "GUILD_DELETE":
                        UnavailableGuild args6 = token["d"].ToObject<UnavailableGuild>();
                        DiscordClientEventHandler<UnavailableGuild> onGuildDeleted = OnGuildDeleted;
                        if (onGuildDeleted != null)
                            onGuildDeleted(this, args6);
                        break;
                    case "THREAD_CREATE":
                        DiscordThread args7 = token["d"].ToObject<DiscordThread>();
                        DiscordClientEventHandler<DiscordThread> onThreadCreated = OnThreadCreated;
                        if (onThreadCreated != null)
                            onThreadCreated(this, args7);
                        break;
                    case "THREAD_UPDATE":
                        DiscordThread args8 = token["d"].ToObject<DiscordThread>();
                        DiscordClientEventHandler<DiscordThread> onThreadUpdated = OnThreadUpdated;
                        if (onThreadUpdated != null)
                            onThreadUpdated(this, args8);
                        break;
                    case "THREAD_DELETE":
                        DiscordThread args9 = token["d"].ToObject<DiscordThread>();
                        DiscordClientEventHandler<DiscordThread> onThreadDeleted = OnThreadDeleted;
                        if (onThreadDeleted != null)
                            onThreadDeleted(this, args9);
                        break;
                    case "GUILD_MEMBERS_CHUNK":
                        GuildMembersChunkEventArgs args10 = token["d"].ToObject<GuildMembersChunkEventArgs>();
                        DiscordClientEventHandler<GuildMembersChunkEventArgs> onGuildMembersChunk = OnGuildMembersReceived;
                        if (onGuildMembersChunk != null)
                            onGuildMembersChunk(this, args10);
                        break;
                }
            }
        }

        public delegate void DiscordClientEventHandler<T>(DiscordSocketClient client, T e);
    }
}
