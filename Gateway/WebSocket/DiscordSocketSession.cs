using WebSocketSharp;

namespace Discord.Gateway
{
    public class DiscordSocketSession
    {
        internal WebSocket webSocket;
        public bool IsConnected;

        public DiscordSocketSession(DiscordSocketHandler handler)
        {
            webSocket = new WebSocket($"wss://gateway.discord.gg/?v={(ushort)handler.ApiVersion}&encoding=json");
            IsConnected = false;
        }

        public void Connect()
        {
            webSocket.Connect();
            IsConnected = true;
        }

        public void Send(string data)
        {
            try
            {
                if (!IsConnected)
                {
                    Connect();
                }

                webSocket.Send(data);
            }
            catch
            {

            }
        }
    }
}
