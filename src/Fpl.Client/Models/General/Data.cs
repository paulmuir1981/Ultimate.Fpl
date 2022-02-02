using System.Text.Json.Serialization;

namespace Fpl.Client.Models.General
{
    public class Data
    {
        [JsonPropertyName("events")]
        public List<Event> Events { get; set; }

        [JsonPropertyName("game_settings")]
        public GameSettings GameSettings { get; set; }

        [JsonPropertyName("phases")]
        public List<Phase> Phases { get; set; }

        [JsonPropertyName("teams")]
        public List<Team> Teams { get; set; }

        [JsonPropertyName("total_players")]
        public int TotalPlayers { get; set; }

        [JsonPropertyName("elements")]
        public List<Element> Elements { get; set; }

        [JsonPropertyName("element_stats")]
        public List<ElementStat> ElementStats { get; set; }

        [JsonPropertyName("element_types")]
        public List<ElementType> ElementTypes { get; set; }
    }
}