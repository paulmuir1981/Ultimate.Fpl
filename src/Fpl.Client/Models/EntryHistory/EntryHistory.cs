using System.Text.Json.Serialization;

namespace Fpl.Client.Models.EntryHistory
{
    public class EntryHistory
    {
        [JsonPropertyName("current")]
        public List<Current> Current { get; set; }

        [JsonPropertyName("past")]
        public List<Past> Past { get; set; }

        [JsonPropertyName("chips")]
        public List<Chip> Chips { get; set; }
    }
}
