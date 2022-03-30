using System.Text.Json.Serialization;

namespace Fpl.Client.Models.Leagues
{
    public class NewEntry
    {
        [JsonPropertyName("entry")]
        public int Entry { get; set; }

        [JsonPropertyName("entry_name")]
        public string EntryName { get; set; }

        [JsonPropertyName("joined_time")]
        public DateTime JoinedTime { get; set; }

        [JsonPropertyName("player_first_name")]
        public string PlayerFirstName { get; set; }

        [JsonPropertyName("player_last_name")]
        public string PlayerLastName { get; set; }
    }
}