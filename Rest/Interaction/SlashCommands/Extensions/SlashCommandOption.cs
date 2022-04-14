using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Discord
{
    public class SlashCommandOption
    {
        [JsonProperty("name")]
        public string Name { get; private set; }

        [JsonProperty("value")]
        public string Value { get; private set; }

        [JsonProperty("options")]
        public List<SlashCommandOption> Options { get; private set; }

        [JsonProperty("type")]
        public ApplicationOptionType Type { get; private set; }
    }
}
