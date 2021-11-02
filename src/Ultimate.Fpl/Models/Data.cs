using System.Collections.Generic;

namespace Ultimate.Fpl.Models
{
    public class Data
    {
        public List<Player> Players { get; set; }
        public List<Club> Clubs { get; set; }
        public List<Position> Positions { get; set; }
        public List<decimal> Prices { get; set; }
    }
}