using System.Text.Json.Serialization;

namespace Fpl.Client.Models.ElementSummaries
{
    public class Fixture
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("team_h")]
        public int TeamH { get; set; }

        [JsonPropertyName("team_h_score")]
        public int? TeamHScore { get; set; }

        [JsonPropertyName("team_a")]
        public int TeamA { get; set; }

        [JsonPropertyName("team_a_score")]
        public int? TeamAScore { get; set; }

        [JsonPropertyName("event")]
        public int? Event { get; set; }

        [JsonPropertyName("finished")]
        public bool Finished { get; set; }

        [JsonPropertyName("minutes")]
        public int Minutes { get; set; }

        [JsonPropertyName("provisional_start_time")]
        public bool ProvisionalStartTime { get; set; }

        [JsonPropertyName("kickoff_time")]
        public DateTime? KickoffTime { get; set; }

        [JsonPropertyName("event_name")]
        public string EventName { get; set; }

        [JsonPropertyName("is_home")]
        public bool IsHome { get; set; }

        [JsonPropertyName("difficulty")]
        public int Difficulty { get; set; }
    }
}