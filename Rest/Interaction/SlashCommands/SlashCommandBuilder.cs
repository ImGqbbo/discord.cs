using Newtonsoft.Json;
using System.Collections.Generic;

namespace Discord
{
    public class SlashCommandBuilder
    {
        [JsonProperty("name")]
        protected string Name { get; set; }

        [JsonProperty("description")]
        protected string Description { get; set; }

        [JsonProperty("type")]
        protected ApplicationCommandType Type { get; set; } = ApplicationCommandType.SlashCommand;

        [JsonProperty("options")]
        protected List<DiscordCommandOption> Options { get; set; }

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

        public SlashCommandBuilder AddOption(DiscordCommandOption option)
        {
            Options.Add(option);

            return this;
        }
    }
}
