using System;

namespace Discord
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class SlashOption : Attribute
    {
        internal string _name { get; set; }
        internal string _description { get; set; }
        internal ApplicationCommandType _type { get; set; }

        public SlashOption(string name, string description, ApplicationCommandType type)
        {
            _name = name;
            _description = description;
            _type = type;
        }
    }
}
