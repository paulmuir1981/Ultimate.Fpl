using System;
using System.Text.Json.Serialization;

namespace Ultimate.Fpl.Models
{
    public class Player : BaseModel
    {
        public string WebName { get; set; }
        public decimal Price { get; set; }
        public decimal ValueForm { get; set; }
        public decimal ValueSeason { get; set; }
        public string FirstNameDiacriticless { get; set; }
        public string SecondNameDiacriticless { get; set; }
        public string WebNameDiacriticless { get; set; }
        public decimal IctIndexValue { get; set; }
        public decimal PointsPerMinute { get; set; }
        public decimal PointsPerGameValue { get; set; }
        public int ClubId { get; set; }
        public string ClubName { get; set; }
        public string ClubShortName { get; set; }
        public int? ChanceOfPlayingNextRound { get; set; }

        public int? ChanceOfPlayingThisRound { get; set; }

        public int Code { get; set; }

        public int CostChangeEvent { get; set; }

        public int CostChangeEventFall { get; set; }

        public int CostChangeStart { get; set; }

        public int CostChangeStartFall { get; set; }

        public int DreamteamCount { get; set; }

        public int PositionId { get; set; }

        public decimal? EpNext { get; set; }

        public decimal? EpThis { get; set; }

        public int EventPoints { get; set; }

        public string FirstName { get; set; }

        public decimal Form { get; set; }

        public bool InDreamteam { get; set; }

        public string News { get; set; }

        public DateTime? NewsAdded { get; set; }

        public string Photo { get; set; }

        public decimal PointsPerGame { get; set; }

        public string SecondName { get; set; }

        public decimal SelectedByPercent { get; set; }

        public bool Special { get; set; }

        public int? SquadNumber { get; set; }

        public string Status { get; set; }

        public int TeamCode { get; set; }

        public int TotalPoints { get; set; }

        public int TransfersIn { get; set; }

        public int TransfersInEvent { get; set; }

        public int TransfersOut { get; set; }

        public int TransfersOutEvent { get; set; }

        public int Minutes { get; set; }

        public int GoalsScored { get; set; }

        public int Assists { get; set; }

        public int CleanSheets { get; set; }

        public int GoalsConceded { get; set; }

        public int OwnGoals { get; set; }

        public int PenaltiesSaved { get; set; }

        public int PenaltiesMissed { get; set; }

        public int YellowCards { get; set; }

        public int RedCards { get; set; }

        public int Saves { get; set; }

        public int Bonus { get; set; }

        public int Bps { get; set; }

        public decimal Influence { get; set; }

        public decimal Creativity { get; set; }

        public decimal Threat { get; set; }

        public decimal IctIndex { get; set; }

        public int InfluenceRank { get; set; }

        public int InfluenceRankType { get; set; }

        public int CreativityRank { get; set; }

        public int CreativityRankType { get; set; }

        public int ThreatRank { get; set; }

        public int ThreatRankType { get; set; }

        public int IctIndexRank { get; set; }

        public int IctIndexRankType { get; set; }

        public int? CornersAndIndirectFreekicksOrder { get; set; }

        public string CornersAndIndirectFreekicksText { get; set; }

        public int? DirectFreekicksOrder { get; set; }

        public string DirectFreekicksText { get; set; }

        public int? PenaltiesOrder { get; set; }

        public string PenaltiesText { get; set; }
        public string PositionName { get; set; }
        public string PositionShortName { get; set; }
        [JsonIgnore] public string FullName => $"{FirstName} {SecondName}".Trim();
    }
}