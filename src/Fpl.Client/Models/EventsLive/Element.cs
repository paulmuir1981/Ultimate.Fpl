using System.Text.Json.Serialization;

namespace Fpl.Client.Models.EventsLive
{
    public class Element
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("stats")]
        public Stats Stats { get; set; }

        [JsonPropertyName("explain")]
        public List<Explain> Explain { get; set; }
    }
}