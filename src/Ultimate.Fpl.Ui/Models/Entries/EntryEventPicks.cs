namespace Ultimate.Fpl.Ui.Models.Entries
{
    public class EntryEventPicks
    {
        public int EntryId { get; set; }
        public int EventId { get; set; }
        public Chip ActiveChip { get; set; }
        public int Points { get; set; }
        public int TotalPoints { get; set; }
        public int Rank { get; set; }
        public int OverallRank { get; set; }
        public decimal Bank { get; set; }
        public decimal Value { get; set; }
        public int TransferCount{ get; set; }
        public int TransferCost { get; set; }
        public int PointsOnBench { get; set; }
        public List<Pick> Picks { get; set; }
    }
}
