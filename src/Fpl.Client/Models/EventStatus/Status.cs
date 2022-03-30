using System.Text.Json.Serialization;

namespace Fpl.Client.Models.EventStatus
{
    public class Status
    {
        [JsonPropertyName("bonus_added")]
        public bool BonusAdded { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("event")]
        public int Event { get; set; }

        [JsonPropertyName("points")]
        public string Points { get; set; }
    }
}