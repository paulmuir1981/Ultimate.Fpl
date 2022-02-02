using System.Text.Json.Serialization;

namespace Fpl.Client.Models.Entries
{
    public class EntryEventPicks
    {
        [JsonPropertyName("active_chip")]
        public string ActiveChip { get; set; }

        [JsonPropertyName("automatic_subs")]
        public List<AutomaticSub> AutomaticSubs { get; set; }

        [JsonPropertyName("entry_history")]
        public EntryHistory EntryHistory { get; set; }

        [JsonPropertyName("picks")]
        public List<Pick> Picks { get; set; }
    }
}
