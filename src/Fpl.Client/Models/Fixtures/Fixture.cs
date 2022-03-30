using System.Text.Json.Serialization;

namespace Fpl.Client.Models.Fixtures
{
    public class Fixture
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("event")]
        public int? Event { get; set; }

        [JsonPropertyName("finished")]
        public bool Finished { get; set; }

        [JsonPropertyName("finished_provisional")]
        public bool FinishedProvisional { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("kickoff_time")]
        public DateTime? KickoffTime { get; set; }

        [JsonPropertyName("minutes")]
        public int Minutes { get; set; }

        [JsonPropertyName("provisional_start_time")]
        public bool ProvisionalStartTime { get; set; }

        [JsonPropertyName("started")]
        public bool? Started { get; set; }

        [JsonPropertyName("team_a")]
        public int TeamA { get; set; }

        [JsonPropertyName("team_a_score")]
        public int? TeamAScore { get; set; }

        [JsonPropertyName("team_h")]
        public int TeamH { get; set; }

        [JsonPropertyName("team_h_score")]
        public int? TeamHScore { get; set; }

        [JsonPropertyName("stats")]
        public List<Stat> Stats { get; set; }

        [JsonPropertyName("team_h_difficulty")]
        public int TeamHDifficulty { get; set; }

        [JsonPropertyName("team_a_difficulty")]
        public int TeamADifficulty { get; set; }

        [JsonPropertyName("pulse_id")]
        public int PulseId { get; set; }
    }
}
