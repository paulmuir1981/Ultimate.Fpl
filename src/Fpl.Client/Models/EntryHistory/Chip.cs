using System.Text.Json.Serialization;

namespace Fpl.Client.Models.EntryHistory
{
    public class Chip
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("time")]
        public DateTime Time { get; set; }

        [JsonPropertyName("event")]
        public int Event { get; set; }
    }
}