using System.Text.Json.Serialization;

namespace Fpl.Client.Models.Entries
{
    public class Leagues
    {
        [JsonPropertyName("classic")]
        public List<Classic> Classic { get; set; }

        [JsonPropertyName("h2h")]
        public List<H2h> H2h { get; set; }

        [JsonPropertyName("cup")]
        public Cup Cup { get; set; }

        [JsonPropertyName("cup_matches")]
        public List<CupMatch> CupMatches { get; set; }
    }
}