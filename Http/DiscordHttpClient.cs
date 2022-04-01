// Decompiled with JetBrains decompiler
// Type: Discord.Http.DiscordHttpClient
// Assembly: discord.cs, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3F1BA3C4-36E7-4736-BD8F-136AE0BE56EE
// Assembly location: C:\Users\catal\Downloads\discord.cs.dll

using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Discord.Http
{
  public class DiscordHttpClient
  {
    private static HttpClient _httpClient;
    public string Token;
    public WebProxy Proxy;

    public DiscordHttpClient()
    {
      if (this.Proxy != null)
        DiscordHttpClient._httpClient = new HttpClient((HttpMessageHandler) new HttpClientHandler()
        {
          Proxy = (IWebProxy) this.Proxy,
          UseProxy = true
        });
      else
        DiscordHttpClient._httpClient = new HttpClient();
    }

    private async Task<DiscordHttpResponse> RawAsync(
      HttpMethod method,
      string endpoint,
      string data = null)
    {
      DiscordHttpClient._httpClient.DefaultRequestHeaders.Clear();
      DiscordHttpClient._httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", this.Token);
      DiscordHttpClient._httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "discord.cs/1.0");
      if (data != null)
        DiscordHttpClient._httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
      HttpRequestMessage message = new HttpRequestMessage()
      {
        RequestUri = new Uri(endpoint),
        Method = method
      };
      if (data != null)
        message.Content = (HttpContent) new StringContent(data, Encoding.UTF8, "application/json");
      HttpResponseMessage response = await DiscordHttpClient._httpClient.SendAsync(message);
      DiscordHttpResponse discordHttpResponse = new DiscordHttpResponse()
      {
        Result = response.Content.ReadAsStringAsync().Result,
        StatusCode = response.StatusCode
      };
      message = (HttpRequestMessage) null;
      response = (HttpResponseMessage) null;
      return discordHttpResponse;
    }

    public async Task<DiscordHttpResponse> PostAsync(
      string endpoint,
      string data = null)
    {
      DiscordHttpResponse discordHttpResponse = await this.RawAsync(HttpMethod.Post, endpoint, data);
      return discordHttpResponse;
    }

    public async Task<DiscordHttpResponse> PatchAsync(
      string endpoint,
      string data = null)
    {
      DiscordHttpResponse discordHttpResponse = await this.RawAsync(new HttpMethod("PATCH"), endpoint, data);
      return discordHttpResponse;
    }

    public async Task<DiscordHttpResponse> DeleteAsync(
      string endpoint,
      string data = null)
    {
      DiscordHttpResponse discordHttpResponse = await this.RawAsync(HttpMethod.Delete, endpoint, data);
      return discordHttpResponse;
    }

    public async Task<DiscordHttpResponse> PutAsync(
      string endpoint,
      string data = null)
    {
      DiscordHttpResponse discordHttpResponse = await this.RawAsync(HttpMethod.Put, endpoint, data);
      return discordHttpResponse;
    }

    public async Task<DiscordHttpResponse> GetAsync(string endpoint)
    {
      DiscordHttpResponse async = await this.RawAsync(HttpMethod.Get, endpoint);
      return async;
    }
  }
}
