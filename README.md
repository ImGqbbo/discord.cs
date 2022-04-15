![unknown (1)](https://user-images.githubusercontent.com/78982354/163561001-f588bd8f-3325-4125-b94a-99eeec293d6d.png)
# discord.cs
Unofficial API wrapper for https://discord.com.

# How to use it?
As first decide if use the websocket client or the rest client

Websocket:
```csharp
DiscordSocketClient client = new DiscordSocketClient(new DiscordSocketHandler() { ApiVersion = ApiVersion.V9 });

client.Authenticate("your bot token here");
client.OnLoggedIn += (s, e) => 
{
    Console.WriteLine("Logged in as: " + e.User.Tag());
};
```

Rest:
```csharp
DiscordClient client = new DiscordClient("your bot token");
client.SendMessage(123456789012345678, "Hello, world!");
```

# Contact or report a bug
- Discord: ImGqbbo#9549
- Telegram: @ImGqbbo

Ispired by Anarchy & discord.js
