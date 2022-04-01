// Decompiled with JetBrains decompiler
// Type: Discord.Gateway.DiscordGateawayIntent
// Assembly: discord.cs, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3F1BA3C4-36E7-4736-BD8F-136AE0BE56EE
// Assembly location: C:\Users\catal\Downloads\discord.cs.dll

namespace Discord.Gateway
{
  public enum DiscordGateawayIntent
  {
    Guilds = 1,
    GuildMembers = 2,
    GuildBans = 4,
    GuildEmojisAndStickers = 8,
    GuildIntegrations = 16, // 0x00000010
    GuildWebhooks = 32, // 0x00000020
    GuildInvites = 64, // 0x00000040
    GuildVoiceStates = 128, // 0x00000080
    GuildPresences = 256, // 0x00000100
    GuildMessages = 512, // 0x00000200
    GuildMessageReactions = 1024, // 0x00000400
    GuildMessageTyping = 2048, // 0x00000800
    DirectMessages = 4096, // 0x00001000
    DirectMessageReactions = 8192, // 0x00002000
    DirectMessageTyping = 16384, // 0x00004000
  }
}
