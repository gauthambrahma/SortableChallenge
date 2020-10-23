using System.Collections;
using System.Linq;
namespace SortableChallenge
{
    public class Calculations
    {
        private HighestAuctionerForUnit[] Result;
        private HighestAuctionerForUnit HighestAuctionerForUnit;
        public BidEntry[] CalculateAdjustBidValue(BidEntry[] bids, Bidder[] bidders)
        {
            foreach (BidEntry bid in bids)
            {
                float AdjustmentFactor = bidders.First(b => b.Name == bid.Bidder).Adjustment;
                bid.AdjustedBid = bid.Bid + bid.Bid * AdjustmentFactor;
            }
            return bids;
        }

        public HighestAuctionerForUnit[] CalculateHighestBidder(AuctionEntry auction)
        {
            int noOfUnits = auction.Units.Length;
            Result = new HighestAuctionerForUnit[noOfUnits];
            for (int i = 0; i < noOfUnits; i++)
            {
                HighestAuctionerForUnit = new HighestAuctionerForUnit();
                HighestAuctionerForUnit.Unit = auction.Units[i];
                Result[i] = HighestAuctionerForUnit;
            }

            foreach (BidEntry bid in auction.Bids)
            {
                HighestAuctionerForUnit currentBidForUnit = Result.First(hafu => hafu.Unit == bid.Unit);
                if (currentBidForUnit.Bid < bid.Bid)
                {
                    int indexOfChange = Result.ToList().FindIndex(hafu => hafu.Unit == bid.Unit);
                    Result[indexOfChange] = new HighestAuctionerForUnit(bid.Bidder, bid.Unit, bid.Bid);
                }
            }
            return Result.ToList().Where(x=>x.Bid>0).ToArray();
        }

    }
}
