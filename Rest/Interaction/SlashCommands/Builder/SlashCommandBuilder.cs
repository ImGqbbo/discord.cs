using Newtonsoft.Json;
using System.Collections.Generic;

namespace Discord
{
    public class SlashCommandBuilder
    {
        public SlashCommandBuilder(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public SlashCommandBuilder() { }

        [JsonProperty("name")]
        protected string Name { get; set; }

        [JsonProperty("description")]
        protected string Description { get; set; }

        [JsonProperty("type")]
        protected ApplicationCommandType Type = ApplicationCommandType.SlashCommand;

        [JsonProperty("options")]
        protected List<SlashOptionBuilder> Options = new List<SlashOptionBuilder>();

        public SlashCommandBuilder SetName(string name)
        {
            Name = name;
            return this;
        }

        public SlashCommandBuilder SetDescription(string description)
        {
            Description = description;
            return this;
        }

        public SlashCommandBuilder SetType(ApplicationCommandType type)
        {
            Type = type;
            return this;
        }

        public SlashCommandBuilder AddOption(SlashOptionBuilder option)
        {
            Options.Add(option);
            return this;
        }
    }
}
