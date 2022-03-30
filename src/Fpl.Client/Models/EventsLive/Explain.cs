using System.Text.Json.Serialization;

namespace Fpl.Client.Models.EventsLive
{
    public class Explain
    {
        [JsonPropertyName("fixture")]
        public int Fixture { get; set; }

        [JsonPropertyName("stats")]
        public List<Stat> Stats { get; set; }
    }
}