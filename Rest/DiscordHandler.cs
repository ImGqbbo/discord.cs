namespace Discord
{
    public class DiscordHandler
    {
        public DiscordHandler() { }

        public ApiVersion ApiVersion = ApiVersion.Default;

        public string BaseURL = string.Format("https://discord.com/api/v{0}", ApiVersion);
    }
}
