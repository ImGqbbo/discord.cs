using System;

namespace Discord
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class SlashChoice : Attribute
    {
        internal string _name { get; set; }
        internal string _value { get; set; }

        public SlashChoice(string name, string value)
        {
            _name = name;
            _value = value;
        }
    }
}
