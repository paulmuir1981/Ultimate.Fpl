using System.Text.Json.Serialization;

namespace Fpl.Client.Models.TeamSetPieceNotes
{
    public class Note
    {
        [JsonPropertyName("external_link")]
        public bool ExternalLink { get; set; }

        [JsonPropertyName("info_message")]
        public string InfoMessage { get; set; }

        [JsonPropertyName("source_link")]
        public string SourceLink { get; set; }
    }
}