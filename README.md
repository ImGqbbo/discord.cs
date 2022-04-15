<div align="center">
  <br/>
  <p>
    <a href="https://github.com/ImGqbbo/discord.cs"><img src="https://github.com/ImGqbbo/discord.cs/blob/main/images/DiscordCSLogo.png" width="600" alt="discord.cs" /></a>
  </p>
  <br/>
  <p>
    <a href="https://github.com/ImGqbbo/discord.cs/blob/main/LICENSE"><img src="https://img.shields.io/badge/License-MIT-blue.svg" alt="License" /></a>
  </p>
</div>

**[discord.cs](https://github.com/ImGqbbo/discord.cs) is a [Discord](https://www.discord.com) API wrapper written for C#.**

# How to use it?
As first decide if use the websocket client or the rest client

Websocket:
```csharp
DiscordSocketClient client = new DiscordSocketClient(new DiscordSocketHandler() { ApiVersion = ApiVersion.Default });

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

Ispired by [Anarchy](https://github.com/not-ilinked/Anarchy) & [discord.js](https://github.com/discordjs/discord.js)
