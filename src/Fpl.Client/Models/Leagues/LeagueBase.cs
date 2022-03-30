using System.Text.Json.Serialization;

namespace Fpl.Client.Models.Leagues
{
    public abstract class LeagueBase<TLeague, TStanding>
    {
        [JsonPropertyName("new_entries")]
        public NewEntries NewEntries { get; set; }

        [JsonPropertyName("last_updated_data")]
        public DateTime? LastUpdatedData { get; set; }

        [JsonPropertyName("league")]
        public TLeague League { get; set; }

        [JsonPropertyName("standings")]
        public Standings<TStanding> Standings { get; set; }
    }
}
