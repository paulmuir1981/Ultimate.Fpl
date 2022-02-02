using System.Text.Json.Serialization;

namespace Fpl.Client.Models.Entries
{
    public class Classic
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("short_name")]
        public string ShortName { get; set; }

        [JsonPropertyName("created")]
        public DateTime Created { get; set; }

        [JsonPropertyName("closed")]
        public bool Closed { get; set; }

        [JsonPropertyName("rank")]
        public int? Rank { get; set; }

        [JsonPropertyName("max_entries")]
        public int? MaxEntries { get; set; }

        [JsonPropertyName("league_type")]
        public string LeagueType { get; set; }

        [JsonPropertyName("scoring")]
        public string Scoring { get; set; }

        [JsonPropertyName("admin_entry")]
        public int? AdminEntry { get; set; }

        [JsonPropertyName("start_event")]
        public int StartEvent { get; set; }

        [JsonPropertyName("entry_can_leave")]
        public bool EntryCanLeave { get; set; }

        [JsonPropertyName("entry_can_admin")]
        public bool EntryCanAdmin { get; set; }

        [JsonPropertyName("entry_can_invite")]
        public bool EntryCanInvite { get; set; }

        [JsonPropertyName("has_cup")]
        public bool HasCup { get; set; }

        [JsonPropertyName("cup_league")]
        public int? CupLeague { get; set; }

        [JsonPropertyName("cup_qualified")]
        public bool? CupQualified { get; set; }

        [JsonPropertyName("entry_rank")]
        public int EntryRank { get; set; }

        [JsonPropertyName("entry_last_rank")]
        public int EntryLastRank { get; set; }
    }
}