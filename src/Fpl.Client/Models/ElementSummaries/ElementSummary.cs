using System.Text.Json.Serialization;

namespace Fpl.Client.Models.ElementSummaries
{
    public class ElementSummary
    {
        [JsonPropertyName("fixtures")]
        public List<Fixture> Fixtures { get; set; }

        [JsonPropertyName("history")]
        public List<History> History { get; set; }

        [JsonPropertyName("history_past")]
        public List<HistoryPast> HistoryPast { get; set; }
    }
}
