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
        public DiscordSocketHandler Handler;

        public event DiscordClientEventHandler<InteractionEventArgs> OnInteractionCreated;
        public event DiscordClientEventHandler<MessageEventArgs> OnMessageCreated;
        public event DiscordClientEventHandler<MessageEventArgs> OnMessageUpdated;
        public event DiscordClientEventHandler<InteractionEventArgs> OnModalSubmit;

        public DiscordSocketClient(DiscordSocketHandler handler)
        {
            session = new DiscordSocketSession(handler);
            Handler = handler;
        }

        public void Login(string token)
        {
            Token = "Bot " + token;
            HttpClient.Token = Token;

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
                    intents = Handler.Intents
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
            try
            {
                if (!string.IsNullOrEmpty(e.Data))
                {
                    JObject token = JObject.Parse(e.Data);
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
                    }
                }
            }
            catch
            {

            }
        }

        public delegate void DiscordClientEventHandler<T>(DiscordSocketClient client, T e);
    }
}
