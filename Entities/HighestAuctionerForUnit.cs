using System;
namespace SortableChallenge
{
    public class HighestAuctionerForUnit
    {
        public string Bidder { get; set; }
        public int Bid { get; set; }
        public string Unit { get; set; }

        public HighestAuctionerForUnit()
        {
        }

        public HighestAuctionerForUnit(string bidder, string unit, int bid)
        {
            Bidder = bidder;
            Unit = unit;
            Bid = bid;
        }
    }
}
