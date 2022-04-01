namespace Discord
{
    public class DiscordImage
    {
        public string Url { get; private set; }

        internal DiscordImage(ulong id, string hash) => Url = string.Format("https://cdn.discordapp.com/avatars/{0}/{1}.png", id, hash);
    }
}
