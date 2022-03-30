﻿using System.Text.Json.Serialization;

namespace Fpl.Client.Models.Leagues.H2h
{
    public class Standing
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("division")]
        public int Division { get; set; }

        [JsonPropertyName("entry")]
        public int? Entry { get; set; }

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

        [JsonPropertyName("entry_name")]
        public string EntryName { get; set; }

        [JsonPropertyName("matches_played")]
        public int MatchesPlayed { get; set; }

        [JsonPropertyName("matches_won")]
        public int MatchesWon { get; set; }

        [JsonPropertyName("matches_drawn")]
        public int MatchesDrawn { get; set; }

        [JsonPropertyName("matches_lost")]
        public int MatchesLost { get; set; }

        [JsonPropertyName("points_for")]
        public int PointsFor { get; set; }
    }
}