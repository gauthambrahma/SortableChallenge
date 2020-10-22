using System.Collections.Generic;

namespace SortableChallenge
{
    public class Validations
    {
        public BidderBidEntry[] FilterBidsUnderFloor(BidderBidEntry[] bids, int floorAmount)
        {
            List<BidderBidEntry> result = new List<BidderBidEntry>();
            foreach (BidderBidEntry bid in bids)
            {
                if (bid.Bid < floorAmount)
                {
                    continue;
                }
                result.Add(bid);
            }
            return result.ToArray();
        }
    }
}
