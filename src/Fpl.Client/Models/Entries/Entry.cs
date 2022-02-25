using System.Text.Json.Serialization;

namespace Fpl.Client.Models.Entries
{
    public class Entry
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("joined_time")]
        public DateTime JoinedTime { get; set; }

        [JsonPropertyName("started_event")]
        public int StartedEvent { get; set; }

        [JsonPropertyName("favourite_team")]
        public int? FavouriteTeam { get; set; }

        [JsonPropertyName("player_first_name")]
        public string PlayerFirstName { get; set; }

        [JsonPropertyName("player_last_name")]
        public string PlayerLastName { get; set; }

        [JsonPropertyName("player_region_id")]
        public int PlayerRegionId { get; set; }

        [JsonPropertyName("player_region_name")]
        public string PlayerRegionName { get; set; }

        [JsonPropertyName("player_region_iso_code_short")]
        public string PlayerRegionIsoCodeShort { get; set; }

        [JsonPropertyName("player_region_iso_code_long")]
        public string PlayerRegionIsoCodeLong { get; set; }

        [JsonPropertyName("summary_overall_points")]
        public int SummaryOverallPoints { get; set; }

        [JsonPropertyName("summary_overall_rank")]
        public int SummaryOverallRank { get; set; }

        [JsonPropertyName("summary_event_points")]
        public int SummaryEventPoints { get; set; }

        [JsonPropertyName("summary_event_rank")]
        public int? SummaryEventRank { get; set; }

        [JsonPropertyName("current_event")]
        public int CurrentEvent { get; set; }

        [JsonPropertyName("leagues")]
        public Leagues Leagues { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("name_change_blocked")]
        public bool NameChangeBlocked { get; set; }

        [JsonPropertyName("kit")]
        public string Kit { get; set; }

        [JsonPropertyName("last_deadline_bank")]
        public int LastDeadlineBank { get; set; }

        [JsonPropertyName("last_deadline_value")]
        public int LastDeadlineValue { get; set; }

        [JsonPropertyName("last_deadline_total_transfers")]
        public int LastDeadlineTotalTransfers { get; set; }
    }
}
