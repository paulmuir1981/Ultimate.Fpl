using System.Text.Json.Serialization;

namespace Fpl.Client.Models.EventStatus
{
    public class EventStatus
    {
        [JsonPropertyName("status")]
        public List<Status> Status { get; set; }

        [JsonPropertyName("leagues")]
        public string Leagues { get; set; }
    }
}
