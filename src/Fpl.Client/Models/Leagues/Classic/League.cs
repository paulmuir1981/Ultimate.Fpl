using System.Text.Json.Serialization;

namespace Fpl.Client.Models.Leagues.Classic
{
    public class League
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("created")]
        public DateTime Created { get; set; }

        [JsonPropertyName("closed")]
        public bool Closed { get; set; }

        [JsonPropertyName("max_entries")]
        public int? MaxEntries { get; set; }

        [JsonPropertyName("league_type")]
        public string LeagueType { get; set; }

        [JsonPropertyName("scoring")]
        public string Scoring { get; set; }

        [JsonPropertyName("admin_entry")]
        public int AdminEntry { get; set; }

        [JsonPropertyName("start_event")]
        public int StartEvent { get; set; }

        [JsonPropertyName("code_privacy")]
        public string CodePrivacy { get; set; }

        [JsonPropertyName("has_cup")]
        public bool HasCup { get; set; }

        [JsonPropertyName("cup_league")]
        public int CupLeague { get; set; }

        [JsonPropertyName("rank")]
        public int? Rank { get; set; }
    }
}