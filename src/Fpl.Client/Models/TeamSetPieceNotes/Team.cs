using System.Text.Json.Serialization;

namespace Fpl.Client.Models.TeamSetPieceNotes
{
    public class Team
    {
        [JsonPropertyName("notes")]
        public List<Note> Notes { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}