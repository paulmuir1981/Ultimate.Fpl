using System.Text.Json.Serialization;

namespace Fpl.Client.Models.DreamTeams
{
    public class TopPlayer
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("points")]
        public int Points { get; set; }
    }
}