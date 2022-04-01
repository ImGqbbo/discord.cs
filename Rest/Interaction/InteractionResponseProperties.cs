using Newtonsoft.Json;

namespace Discord
{
    public class InteractionResponseProperties : MessageProperties
    {
        [JsonIgnore]
        public bool Ephemeral { get; set; }

        [JsonProperty("flags")]
        private int Flags => Ephemeral ? 64 : 0;
    }
}
