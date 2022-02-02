using System.Text.Json.Serialization;

namespace Fpl.Client.Models.General
{
    public class Phase
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("start_event")]
        public int StartEvent { get; set; }

        [JsonPropertyName("stop_event")]
        public int StopEvent { get; set; }
    }
}