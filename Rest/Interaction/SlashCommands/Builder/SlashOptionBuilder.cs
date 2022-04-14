using Newtonsoft.Json;
using System.Collections.Generic;

namespace Discord
{
    public class SlashOptionBuilder
    {
        [JsonProperty("name")]
        protected string Name { get; set; }

        [JsonProperty("description")]
        protected string Description { get; set; }

        [JsonProperty("required")]
        protected bool? Required { get; set; }

        [JsonProperty("type")]
        protected ApplicationOptionType Type { get; set; }

        [JsonProperty("choices")]
        protected List<CommandOptionChoice> Choices = new List<CommandOptionChoice>();

        [JsonProperty("options")]
        protected List<SlashOptionBuilder> Options = new List<SlashOptionBuilder>();

        public SlashOptionBuilder(string name, string description, bool required = false)
        {
            Name = name;
            Description = description;
            Required = required;
        }

        public SlashOptionBuilder() { }

        public SlashOptionBuilder SetName(string name)
        {
            Name = name;
            return this;
        }

        public SlashOptionBuilder SetDescription(string description)
        {
            Description = description;
            return this;
        }

        public SlashOptionBuilder SetRequired(bool required)
        {
            Required = required;
            return this;
        }

        public SlashOptionBuilder SetType(ApplicationOptionType type)
        {
            Type = type;
            return this;
        }

        public SlashOptionBuilder AddChoice(string name, string value)
        {
            Choices.Add(new CommandOptionChoice() 
            {
                Name = name, 
                Value = value
            });
            return this;
        }

        public SlashOptionBuilder AddOption(SlashOptionBuilder option)
        {
            Options.Add(option);
            return this;
        }
    }
}
