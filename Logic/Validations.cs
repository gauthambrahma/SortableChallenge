using System;
using System.Collections.Generic;

namespace SortableChallenge
{
    public class Validations
    {
        private List<BidderBidEntry> result;

        public BidderBidEntry[] FilterBidsUnderFloor(BidderBidEntry[] bids, int floorAmount)
        {
            result = new List<BidderBidEntry>();
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

        public BidderBidEntry[] FilterBidsNotPermitted(BidderBidEntry[] bids, string[] permittedBidders)
        {
            result = new List<BidderBidEntry>();
            foreach (BidderBidEntry bid in bids)
            {
                if (Array.IndexOf(permittedBidders, bid.Bidder) < 0)
                {
                    continue;
                }
                result.Add(bid);
            }
            return result.ToArray();
        }
    }
}
