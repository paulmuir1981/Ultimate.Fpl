using System.Text.Json.Serialization;

namespace Fpl.Client.Models.DreamTeams
{
    public class DreamTeam
    {
        [JsonPropertyName("top_player")]
        public TopPlayer TopPlayer { get; set; }

        [JsonPropertyName("team")]
        public List<Element> Team { get; set; }
    }
}
