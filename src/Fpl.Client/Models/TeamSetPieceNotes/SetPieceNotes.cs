using System.Text.Json.Serialization;

namespace Fpl.Client.Models.TeamSetPieceNotes
{
    public class SetPieceNotes
    {
        [JsonPropertyName("last_updated")]
        public DateTime LastUpdated { get; set; }

        [JsonPropertyName("teams")]
        public List<Team> Teams { get; set; }
    }
}
