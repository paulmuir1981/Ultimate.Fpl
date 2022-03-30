using System.Text.Json.Serialization;

namespace Fpl.Client.Models.EventsLive
{
    public class Stat
    {
        [JsonPropertyName("identifier")]
        public string Identifier { get; set; }

        [JsonPropertyName("points")]
        public int Points { get; set; }

        [JsonPropertyName("value")]
        public int Value { get; set; }
    }
}