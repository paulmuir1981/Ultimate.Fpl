using System.Text.Json.Serialization;

namespace Fpl.Client.Models.Leagues.Classic
{
    public class Standing
    {
        [JsonPropertyName("entry")]
        public int Entry { get; set; }

        [JsonPropertyName("entry_name")]
        public string EntryName { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("event_total")]
        public int EventTotal { get; set; }

        [JsonPropertyName("player_name")]
        public string PlayerName { get; set; }

        [JsonPropertyName("rank")]
        public int Rank { get; set; }

        [JsonPropertyName("last_rank")]
        public int LastRank { get; set; }

        [JsonPropertyName("rank_sort")]
        public int RankSort { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }
    }
}