using System;

namespace Discord
{
    internal class Utils
    {
        private static Random random = new Random();

        public static string RandomString(int length)
        {
            string str1 = "";
            string str2 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            for (int index = 0; index < length; ++index)
                str1 += str2[Utils.random.Next(0, str2.Length)].ToString();
            return str1;
        }
    }
}
