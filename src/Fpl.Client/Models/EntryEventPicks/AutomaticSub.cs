using System.Text.Json.Serialization;

namespace Fpl.Client.Models.EntryEventPicks
{
    public class AutomaticSub
    {
        [JsonPropertyName("entry")]
        public int Entry { get; set; }

        [JsonPropertyName("element_in")]
        public int ElementIn { get; set; }

        [JsonPropertyName("element_out")]
        public int ElementOut { get; set; }

        [JsonPropertyName("event")]
        public int Event { get; set; }
    }
}