using System.Text.Json.Serialization;

namespace Fpl.Client.Models.Fixtures
{
    public class Stat
    {
        [JsonPropertyName("identifier")]
        public string Identifier { get; set; }

        [JsonPropertyName("a")]
        public List<TeamStat> A { get; set; }

        [JsonPropertyName("h")]
        public List<TeamStat> H { get; set; }
    }
}