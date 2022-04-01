using Newtonsoft.Json;

namespace Discord
{
    public class ModalComponent
    {
        [JsonProperty("value")]
        public string Value { get; private set; }

        [JsonProperty("type")]
        public ComponentType Type { get; private set; }

        [JsonProperty("custom_id")]
        public string CustomId { get; private set; }
    }
}
