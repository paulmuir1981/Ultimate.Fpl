using System.Text.Json.Serialization;

namespace Fpl.Client.Models.ElementSummaries
{
    public class History
    {
        [JsonPropertyName("element")]
        public int Element { get; set; }

        [JsonPropertyName("fixture")]
        public int Fixture { get; set; }

        [JsonPropertyName("opponent_team")]
        public int OpponentTeam { get; set; }

        [JsonPropertyName("total_points")]
        public int TotalPoints { get; set; }

        [JsonPropertyName("was_home")]
        public bool WasHome { get; set; }

        [JsonPropertyName("kickoff_time")]
        public DateTime KickoffTime { get; set; }

        [JsonPropertyName("team_h_score")]
        public int? TeamHScore { get; set; }

        [JsonPropertyName("team_a_score")]
        public int? TeamAScore { get; set; }

        [JsonPropertyName("round")]
        public int Round { get; set; }

        [JsonPropertyName("minutes")]
        public int Minutes { get; set; }

        [JsonPropertyName("goals_scored")]
        public int GoalsScored { get; set; }

        [JsonPropertyName("assists")]
        public int Assists { get; set; }

        [JsonPropertyName("clean_sheets")]
        public int CleanSheets { get; set; }

        [JsonPropertyName("goals_conceded")]
        public int GoalsConceded { get; set; }

        [JsonPropertyName("own_goals")]
        public int OwnGoals { get; set; }

        [JsonPropertyName("penalties_saved")]
        public int PenaltiesSaved { get; set; }

        [JsonPropertyName("penalties_missed")]
        public int PenaltiesMissed { get; set; }

        [JsonPropertyName("yellow_cards")]
        public int YellowCards { get; set; }

        [JsonPropertyName("red_cards")]
        public int RedCards { get; set; }

        [JsonPropertyName("saves")]
        public int Saves { get; set; }

        [JsonPropertyName("bonus")]
        public int Bonus { get; set; }

        [JsonPropertyName("bps")]
        public int Bps { get; set; }

        [JsonPropertyName("influence")]
        public decimal Influence { get; set; }

        [JsonPropertyName("creativity")]
        public decimal Creativity { get; set; }

        [JsonPropertyName("threat")]
        public decimal Threat { get; set; }

        [JsonPropertyName("ict_index")]
        public decimal IctIndex { get; set; }

        [JsonPropertyName("value")]
        public int Value { get; set; }

        [JsonPropertyName("transfers_balance")]
        public int TransfersBalance { get; set; }

        [JsonPropertyName("selected")]
        public int Selected { get; set; }

        [JsonPropertyName("transfers_in")]
        public int TransfersIn { get; set; }

        [JsonPropertyName("transfers_out")]
        public int TransfersOut { get; set; }
    }
}