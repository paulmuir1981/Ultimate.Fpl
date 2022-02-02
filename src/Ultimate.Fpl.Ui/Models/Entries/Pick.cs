using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Ultimate.Fpl.Ui.Models.Entries
{
    public class Pick : BaseModel
    {
        [DisplayName("Price (£m)")]
        [DisplayFormat(DataFormatString = "{0:0.0}")]
        public decimal Price { get; set; }
        public int Ordinal { get; set; }
        public int Multiplier { get; set; }
        public bool IsCaptain { get; set; }
        public bool IsViceCaptain { get; set; }
        [DisplayName("Name")]
        public string WebName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        [DisplayName("Club")]
        public string ClubName { get; set; }
        [DisplayName("Club")]
        public string ClubShortName { get; set; }
        [DisplayName("Position")] public int PositionId { get; set; }
        [DisplayName("Position")] public string PositionName { get; set; }
        [DisplayName("Position")] public string PositionShortName { get; set; }
        [DisplayName("Points")]
        public int EventPoints { get; set; }

        [JsonIgnore]
        [DisplayName("Actual Points")]
        public int Points => EventPoints * Multiplier;

        [JsonIgnore]
        [DisplayName("Starter?")]
        public bool IsStarter => Multiplier > 0;

        [DisplayName("Name")]
        [JsonIgnore]
        public string FullName => $"{FirstName} {SecondName}".Trim();

        [DisplayName("Name")]
        [JsonIgnore]
        public string DisplayName
        {
            get
            {
                if (IsCaptain)
                {
                    return $"{WebName} (c)";
                }
                else if (IsViceCaptain)
                {
                    return $"{WebName} (v)";
                }
                return WebName;
            }
        }
    }
}