using System;

namespace Discord
{
    public class DiscordImage
    {
        public string Url { get; private set; }

        /// <summary>
        /// Get the display avatar URL of the given user.
        /// </summary>
        /// <param name="user">The Discord user.</param>
        /// <returns>The display avatar URL.</returns>
        internal DiscordImage(DiscordUser user)
        {
            if (user.AvatarHash == null)
            {
                Url = string.Format("https://cdn.discordapp.com/embed/avatars/{0}.png", user.Discriminator % 5);
            }
            else
            {
                Url = string.Format("https://cdn.discordapp.com/avatars/{0}/{1}.png", user.Id, user.AvatarHash);
            }
        }
    }
}
