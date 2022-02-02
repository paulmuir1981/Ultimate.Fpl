using System.Text.Json.Serialization;

namespace Fpl.Client.Models.Entries
{
    public class Status
    {
        [JsonPropertyName("qualification_event")]
        public int? QualificationEvent { get; set; }

        [JsonPropertyName("qualification_numbers")]
        public int? QualificationNumbers { get; set; }

        [JsonPropertyName("qualification_rank")]
        public int? QualificationRank { get; set; }

        [JsonPropertyName("qualification_state")]
        public int? QualificationState { get; set; }
    }
}