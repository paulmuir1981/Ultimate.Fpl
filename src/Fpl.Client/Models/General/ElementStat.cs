using System.Text.Json.Serialization;

namespace Fpl.Client.Models.General
{
    public class ElementStat
    {
        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}