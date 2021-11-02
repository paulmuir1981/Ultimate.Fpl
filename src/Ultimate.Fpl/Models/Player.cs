using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Ultimate.Fpl.Models
{
    public class Player : BaseModel
    {
        public static readonly int[] Availabilities = {0, 25, 50, 75, 100 };
        [DisplayName("Name")] public string WebName { get; set; }

        [DisplayName("Price (£m)")]
        [DisplayFormat(DataFormatString = "{0:0.0}")]
        public decimal Price { get; set; }

        [DisplayName("Value Form")]
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public decimal ValueForm { get; set; }

        [DisplayName("Value Season")]
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public decimal ValueSeason { get; set; }

        [DisplayName("First Name Diacriticless")]
        public string FirstNameDiacriticless { get; set; }

        [DisplayName("Second Name Diacriticless")]
        public string SecondNameDiacriticless { get; set; }

        [DisplayName("Web Name Diacriticless")]
        public string WebNameDiacriticless { get; set; }

        [DisplayName("ICT Index Value")]
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public decimal IctIndexValue { get; set; }

        [DisplayName("Points Per Min")]
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public decimal PointsPerMinute { get; set; }

        [DisplayName("Points Per Game Value")]
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public decimal PointsPerGameValue { get; set; }

        [DisplayName("Club")] public int ClubId { get; set; }

        [DisplayName("Club")] public string ClubName { get; set; }

        [DisplayName("Club")] public string ClubShortName { get; set; }

        [DisplayName("Availability")] public int Availability { get; set; }

        [DisplayName("Cost Change Event")] public int CostChangeEvent { get; set; }

        [DisplayName("Cost Change Event Fall")]
        public int CostChangeEventFall { get; set; }

        [DisplayName("Cost Change Start")] public int CostChangeStart { get; set; }

        [DisplayName("Cost Change Start Fall")]
        public int CostChangeStartFall { get; set; }

        [DisplayName("Dreamteam Count")] public int DreamteamCount { get; set; }

        [DisplayName("Position")] public int PositionId { get; set; }

        [DisplayName("Expected Points Next")] public decimal? EpNext { get; set; }

        [DisplayName("Expected Points This")] public decimal? EpThis { get; set; }

        [DisplayName("Event Points")] public int EventPoints { get; set; }

        [DisplayName("First Name")] public string FirstName { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.0}")]
        public decimal Form { get; set; }

        [DisplayName("In Dreamteam?")] public bool InDreamteam { get; set; }

        public string News { get; set; }

        [DisplayName("News Added")] public DateTime? NewsAdded { get; set; }

        public string Photo { get; set; }

        [DisplayName("Points Per Game")]
        [DisplayFormat(DataFormatString = "{0:0.0}")]
        public decimal PointsPerGame { get; set; }

        [DisplayName("Second Name")] public string SecondName { get; set; }

        [DisplayName("Selected (%)")]
        [DisplayFormat(DataFormatString = "{0:0.0}")]
        public decimal SelectedByPercent { get; set; }

        [DisplayName("Points")] public int TotalPoints { get; set; }

        [DisplayName("Transfers In")] public int TransfersIn { get; set; }

        [DisplayName("Transfers In Event")] public int TransfersInEvent { get; set; }

        [DisplayName("Transfers Out")] public int TransfersOut { get; set; }

        [DisplayName("Transfers Out Event")] public int TransfersOutEvent { get; set; }

        public int Minutes { get; set; }

        [DisplayName("Goals Scored")] public int GoalsScored { get; set; }

        public int Assists { get; set; }

        [DisplayName("Clean Sheets")] public int CleanSheets { get; set; }

        [DisplayName("Goals Conceded")] public int GoalsConceded { get; set; }

        [DisplayName("Own Goals")] public int OwnGoals { get; set; }

        [DisplayName("Penalties Saved")] public int PenaltiesSaved { get; set; }

        [DisplayName("Penalties Missed")] public int PenaltiesMissed { get; set; }

        [DisplayName("Yellow Cards")] public int YellowCards { get; set; }

        [DisplayName("Red Cards")] public int RedCards { get; set; }

        public int Saves { get; set; }

        [DisplayName("Bonus Points")] public int Bonus { get; set; }

        [DisplayName("Bonus Points System")] public int Bps { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.0}")]
        public decimal Influence { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.0}")]
        public decimal Creativity { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.0}")]
        public decimal Threat { get; set; }

        [DisplayName("ICT Index")]
        [DisplayFormat(DataFormatString = "{0:0.0}")]
        public decimal IctIndex { get; set; }

        [DisplayName("Influence Rank")] public int InfluenceRank { get; set; }

        [DisplayName("Influence Rank Type")] public int InfluenceRankType { get; set; }

        [DisplayName("Creativity Rank")] public int CreativityRank { get; set; }

        [DisplayName("Creativity Rank Type")] public int CreativityRankType { get; set; }

        [DisplayName("Threat Rank")] public int ThreatRank { get; set; }

        [DisplayName("Threat Rank Type")] public int ThreatRankType { get; set; }

        [DisplayName("ICT Index Rank")] public int IctIndexRank { get; set; }

        [DisplayName("ICT Index Rank Type")] public int IctIndexRankType { get; set; }

        [DisplayName("Corners / Indirect Freekicks Order")]
        public int? CornersAndIndirectFreekicksOrder { get; set; }

        [DisplayName("Direct Freekicks Order")]
        public int? DirectFreekicksOrder { get; set; }

        [DisplayName("Penalties Order")] public int? PenaltiesOrder { get; set; }

        [DisplayName("Position")] public string PositionName { get; set; }

        [DisplayName("Position")] public string PositionShortName { get; set; }

        [DisplayName("Name")] [JsonIgnore] public string FullName => $"{FirstName} {SecondName}".Trim();

        [DisplayName("Name Diacriticless")]
        [JsonIgnore]
        public string FullNameDiacriticless => $"{FirstNameDiacriticless} {SecondNameDiacriticless}".Trim();

        [DisplayName("Availability")]
        [JsonIgnore]
        public string AvailabilityText
        {
            get
            {
                var builder = new StringBuilder();

                if (NewsAdded.HasValue)
                {
                    builder.Append($"{NewsAdded}: ");
                }

                builder.Append($"{Availability}%");

                if (!string.IsNullOrEmpty(News))
                {
                    builder.Append($" - {News}");
                }

                return builder.ToString();
            }
        }
    }
}