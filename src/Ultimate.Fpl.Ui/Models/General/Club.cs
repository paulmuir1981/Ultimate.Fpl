using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Ultimate.Fpl.Ui.Models.General
{
    public class Club : BaseModel
    {
        public string Name { get; set; }

        [DisplayName("Name")]
        public string ShortName { get; set; }
        public int Strength { get; set; }

        [DisplayName("Strength Overall Home")]
        public int StrengthOverallHome { get; set; }

        [DisplayName("Strength Overall Away")]
        public int StrengthOverallAway { get; set; }

        [DisplayName("Strength Attack Home")]
        public int StrengthAttackHome { get; set; }

        [DisplayName("Strength Attack Away")]
        public int StrengthAttackAway { get; set; }

        [DisplayName("Strength Defense Home")]
        public int StrengthDefenceHome { get; set; }

        [DisplayName("Strength Defense Away")]
        public int StrengthDefenceAway { get; set; }

        public List<Player> PenaltyTakers { get; set; }

        public List<Player> CornersAndIndirectFreekickTakers { get; set; }

        public List<Player> DirectFreekickTakers { get; set; }

        [DisplayName("Penalty Takers")]
        [JsonIgnore]
        public string PenaltyTakersSummary => string.Join(", ", PenaltyTakers.Select(x => x.WebName));

        [DisplayName("Corners / Indirect Freekick Takers")]
        [JsonIgnore]
        public string CornersAndIndirectFreekickTakersSummary => string.Join(", ", CornersAndIndirectFreekickTakers.Select(x => x.WebName));

        [DisplayName("Direct Freekick Takers")]
        [JsonIgnore]
        public string DirectFreekickTakersSummary => string.Join(", ", DirectFreekickTakers.Select(x => x.WebName));
    }
}