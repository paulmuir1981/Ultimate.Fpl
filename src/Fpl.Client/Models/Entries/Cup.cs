using System.Text.Json.Serialization;

namespace Fpl.Client.Models.Entries
{
    public class Cup
    {
        [JsonPropertyName("matches")]
        public List<object> Matches { get; set; }

        [JsonPropertyName("status")]
        public Status Status { get; set; }

        [JsonPropertyName("cup_league")]
        public int CupLeague { get; set; }
    }
}