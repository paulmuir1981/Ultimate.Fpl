using System.Text.Json.Serialization;

namespace Fpl.Client.Models.DreamTeams
{
    public class Element
    {
        [JsonPropertyName("element")]
        public int Id { get; set; }

        [JsonPropertyName("points")]
        public int Points { get; set; }

        [JsonPropertyName("position")]
        public int Position { get; set; }
    }
}