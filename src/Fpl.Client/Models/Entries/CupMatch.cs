using System.Text.Json.Serialization;

namespace Fpl.Client.Models.Entries
{
    public class CupMatch
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("entry_1_entry")]
        public int Entry1Entry { get; set; }

        [JsonPropertyName("entry_1_name")]
        public string Entry1Name { get; set; }

        [JsonPropertyName("entry_1_player_name")]
        public string Entry1PlayerName { get; set; }

        [JsonPropertyName("entry_1_points")]
        public int Entry1Points { get; set; }

        [JsonPropertyName("entry_1_win")]
        public int Entry1Win { get; set; }

        [JsonPropertyName("entry_1_draw")]
        public int Entry1Draw { get; set; }

        [JsonPropertyName("entry_1_loss")]
        public int Entry1Loss { get; set; }

        [JsonPropertyName("entry_1_total")]
        public int Entry1Total { get; set; }

        [JsonPropertyName("entry_2_entry")]
        public int Entry2Entry { get; set; }

        [JsonPropertyName("entry_2_name")]
        public string Entry2Name { get; set; }

        [JsonPropertyName("entry_2_player_name")]
        public string Entry2PlayerName { get; set; }

        [JsonPropertyName("entry_2_points")]
        public int Entry2Points { get; set; }

        [JsonPropertyName("entry_2_win")]
        public int Entry2Win { get; set; }

        [JsonPropertyName("entry_2_draw")]
        public int Entry2Draw { get; set; }

        [JsonPropertyName("entry_2_loss")]
        public int Entry2Loss { get; set; }

        [JsonPropertyName("entry_2_total")]
        public int Entry2Total { get; set; }

        [JsonPropertyName("is_knockout")]
        public bool IsKnockout { get; set; }

        [JsonPropertyName("league")]
        public int League { get; set; }

        [JsonPropertyName("winner")]
        public int? Winner { get; set; }

        [JsonPropertyName("seed_value")]
        public object SeedValue { get; set; }

        [JsonPropertyName("event")]
        public int Event { get; set; }

        [JsonPropertyName("tiebreak")]
        public string Tiebreak { get; set; }

        [JsonPropertyName("is_bye")]
        public bool IsBye { get; set; }

        [JsonPropertyName("knockout_name")]
        public string KnockoutName { get; set; }
    }
}