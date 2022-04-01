// Decompiled with JetBrains decompiler
// Type: Discord.Gateway.InteractionEventArgs
// Assembly: discord.cs, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3F1BA3C4-36E7-4736-BD8F-136AE0BE56EE
// Assembly location: C:\Users\catal\Downloads\discord.cs.dll

using Newtonsoft.Json;

namespace Discord.Gateway
{
  public class InteractionEventArgs
  {
    [JsonProperty("id")]
    public ulong InteractionId { get; private set; }

    [JsonProperty("application_id")]
    public ulong ApplicationId { get; private set; }

    [JsonProperty("data")]
    public InteractionData Data { get; private set; }

    [JsonProperty("guild_id")]
    public ulong GuildId { get; private set; }

    [JsonProperty("channel_id")]
    public ulong ChannelId { get; private set; }

    [JsonProperty("member")]
    public GuildMember Member { get; private set; }

    [JsonProperty("message")]
    public DiscordMessage Message { get; private set; }

    [JsonProperty("locale")]
    public string Locale { get; private set; }

    [JsonProperty("token")]
    public string InteractionToken { get; private set; }

    [JsonProperty("type")]
    public InteractionType Type { get; private set; }
  }
}
