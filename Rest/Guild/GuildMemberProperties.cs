// Decompiled with JetBrains decompiler
// Type: Discord.GuildMemberProperties
// Assembly: discord.cs, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3F1BA3C4-36E7-4736-BD8F-136AE0BE56EE
// Assembly location: C:\Users\catal\Downloads\discord.cs.dll

using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Discord
{
  public class GuildMemberProperties
  {
    [JsonProperty("nick")]
    public string Nick { get; set; }

    [JsonProperty("roles")]
    public List<ulong> Roles { get; set; }

    [JsonProperty("communication_disabled_until")]
    public DateTime ComunicationDisabledUntil { get; set; }
  }
}
