using System;

namespace Discord
{
    internal class Utils
    {
        private static readonly Random _rand = new Random();

        public static string RandomString(int length)
        {
            string result = "";
            string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            for (int index = 0; index < length; index++)
            {
                result += chars[_rand.Next(0, chars.Length)];
            }

            return result;
        }
    }
}
