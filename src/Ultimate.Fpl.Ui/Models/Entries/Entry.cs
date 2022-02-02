using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Ultimate.Fpl.Ui.Models.Entries
{
    public class Entry
    {
        public string PlayerFirstName { get; set; }
        public string PlayerLastName { get; set; }
        [DisplayName("Player Name")] [JsonIgnore] public string PlayerFullName => $"{PlayerFirstName} {PlayerLastName}".Trim();

    }
}
