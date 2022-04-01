// Decompiled with JetBrains decompiler
// Type: Discord.Utils
// Assembly: discord.cs, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3F1BA3C4-36E7-4736-BD8F-136AE0BE56EE
// Assembly location: C:\Users\catal\Downloads\discord.cs.dll

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
