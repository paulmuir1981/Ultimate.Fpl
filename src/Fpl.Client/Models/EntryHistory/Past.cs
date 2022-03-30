using System.Text.Json.Serialization;

namespace Fpl.Client.Models.EntryHistory
{
    public class Past
    {
        [JsonPropertyName("season_name")]
        public string SeasonName { get; set; }

        [JsonPropertyName("total_points")]
        public int TotalPoints { get; set; }

        [JsonPropertyName("rank")]
        public int Rank { get; set; }
    }
}