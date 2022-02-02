using System.Text.Json.Serialization;

namespace Fpl.Client.Models.Entries
{
    public class Pick
    {
        [JsonPropertyName("element")]
        public int Element { get; set; }

        [JsonPropertyName("position")]
        public int Position { get; set; }

        [JsonPropertyName("multiplier")]
        public int Multiplier { get; set; }

        [JsonPropertyName("is_captain")]
        public bool IsCaptain { get; set; }

        [JsonPropertyName("is_vice_captain")]
        public bool IsViceCaptain { get; set; }
    }
}