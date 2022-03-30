using System.Text.Json.Serialization;

namespace Fpl.Client.Models.Fixtures
{
    public class TeamStat
    {
        [JsonPropertyName("value")]
        public int Value { get; set; }

        [JsonPropertyName("element")]
        public int Element { get; set; }
    }
}