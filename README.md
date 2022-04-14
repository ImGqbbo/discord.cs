# discord.cs
Unofficial API wrapper for https://discord.com

# How to use it?
As first decide if use the websocket client or the rest client

Websocket:
```
DiscordSocketClient client = new DiscordSocketClient(new DiscordSocketHandler() { ApiVersion = ApiVersion.V9 });

client.Authenticate("your bot token here");
client.OnLoggedIn += (s, e) => 
{
    Console.WriteLine("Logged in as: " + e.User.Tag());
};
```

Rest:
```
DiscordClient client = new DiscordClient("your bot token");
client.SendMessage(123456789012345678, "Hello, world!");
```

# Contact or report a bug
- Discord: ImGqbbo#9549
- Telegram: @ImGqbbo