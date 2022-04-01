// Decompiled with JetBrains decompiler
// Type: Discord.Http.DiscordHttpResponse
// Assembly: discord.cs, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3F1BA3C4-36E7-4736-BD8F-136AE0BE56EE
// Assembly location: C:\Users\catal\Downloads\discord.cs.dll

using System.Net;

namespace Discord.Http
{
  public class DiscordHttpResponse
  {
    public string Result { get; internal set; }

    public HttpStatusCode StatusCode { get; internal set; }
  }
}
