using System;
using System.Collections.Generic;

namespace SortableChallenge
{
    public class Validations
    {
        private List<BidEntry> result;
        Calculations Calculations = new Calculations();

        public BidEntry[] FilterBidsUnderFloor(BidEntry[] bids, int floorAmount)
        {
            result = new List<BidEntry>();
            foreach (BidEntry bid in bids)
            {
                if (bid.AdjustedBid < floorAmount)
                {
                    continue;
                }
                result.Add(bid);
            }
            return result.ToArray();
        }

        public BidEntry[] FilterBidsNotPermitted(BidEntry[] bids, string[] permittedBidders)
        {
            result = new List<BidEntry>();
            foreach (BidEntry bid in bids)
            {
                if (Array.IndexOf(permittedBidders, bid.Bidder) < 0)
                {
                    continue;
                }
                result.Add(bid);
            }
            return result.ToArray();
        }

        public BidEntry[] FilterBidsAdUnitsNotPermitted(BidEntry[] bids, string[] adUnits)
        {
            result = new List<BidEntry>();
            foreach (BidEntry bid in bids)
            {
                if (Array.IndexOf(adUnits, bid.Unit) < 0)
                {
                    continue;
                }
                result.Add(bid);
            }
            return result.ToArray();
        }

        public BidEntry[] FilterUnrecognizableBidders(BidEntry[] bids)
        {
            result = new List<BidEntry>();
            foreach (BidEntry bid in bids)
            {
                if (bid.Bidder == null || bid.Bidder == "")
                {
                    continue;
                }
                result.Add(bid);
            }
            return result.ToArray();
        }

        public bool IsSiteValid(AuctionEntry auction)
        {
            if (auction.Site == null || auction.Site == "")
            {
                return false;
            }
            return true;
        }
    }
}
