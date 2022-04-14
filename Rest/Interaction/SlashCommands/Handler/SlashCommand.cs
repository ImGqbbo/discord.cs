using System;

namespace Discord
{
    [AttributeUsage(AttributeTargets.Class)]
    internal abstract class SlashCommand : Attribute
    {
        internal string _name { get; set; }
        internal string _description { get; set; }
        internal bool _ephemeral { get; set; }

        public SlashCommand(string name, string description, bool ephemeral = false)
        {
            _name = name;
            _description = description;
            _ephemeral = ephemeral;
        }

        public abstract InteractionResponseProperties Run();
    }
}
