using System.Text.Json.Serialization;

namespace Fpl.Client.Models.EventsLive
{
    public class EventLive
    {
        [JsonPropertyName("elements")]
        public List<Element> Elements { get; set; }
    }
}
