using Newtonsoft.Json;
using System.Collections.Generic;

namespace Discord
{
    public class ModalBuilder
    {
        [JsonProperty("title")]
        protected string Title { get; set; }

        [JsonProperty("custom_id")]
        protected string CustomId { get; set; }

        [JsonProperty("components")]
        protected List<DiscordActionRow> Components = new List<DiscordActionRow>();

        public ModalBuilder SetTitle(string title)
        {
            Title = title;

            return this;
        }

        public ModalBuilder SetCustomId(string id)
        {
            CustomId = id;

            return this;
        }

        public ModalBuilder AddTextInput(DiscordTextInputBuilder input)
        {
            Components.Add(new DiscordActionRow()
            {
                Components = new List<DiscordFormComponent>() { input }
            });

            return this;
        }
    }
}
