using System.Linq;
using System.Text.Json;
using System.Collections.Generic;
using System.Xml;

namespace SortableChallenge
{
    public class ProcessAudition
    {
        private readonly ReadWriteJSON ReadWriteJSON = new ReadWriteJSON();
        private readonly BidConfiguration Configuration;
        private readonly AuctionEntry[] Auctions;
        private readonly Calculations Calculations = new Calculations();
        private readonly Validations Validations = new Validations();
        List<HighestAuctionerForUnit[]> FinalResult = new List<HighestAuctionerForUnit[]>();

        public ProcessAudition() : this(Constants.CONFIG_PATH, Constants.INPUT_PATH)
        {

        }

        public ProcessAudition(string configPath, string inputPath)
        {
            Configuration = ReadWriteJSON.ReadAndParseJSON<BidConfiguration>(configPath);
            Auctions = ReadWriteJSON.ReadAndParseJSONList<AuctionEntry>().ToArray();
        }

        public void PorcessBids()
        {
            foreach (AuctionEntry auction in Auctions)
            {
                if (!Validations.IsSiteValid(auction) || auction.Bids.Length == 0)
                {
                    //add empty result for this auction and move to next
                    FinalResult.Add(new HighestAuctionerForUnit[] { });
                    continue;
                }

                //get permitted bids for current bid
                string[] biddersAllowedOnSite = Configuration.Sites.First(cs => cs.Name == auction.Site).Bidders;
                string[] knownBidders = Configuration.Bidders.Select(bi => bi.Name).ToArray();
                //remove bids from bidders not on permmited bidders list or unknown
                auction.Bids = Validations.FilterBidsNotPermitted(auction.Bids, biddersAllowedOnSite);
                auction.Bids = Validations.FilterBidsNotPermitted(auction.Bids, knownBidders);

                //remove ad units that are not permitted
                auction.Bids = Validations.FilterBidsAdUnitsNotPermitted(auction.Bids, auction.Units);

                //retrive floor value for from config for current bid
                int floorValue = Configuration.Sites.First(cs => cs.Name == auction.Site).Floor;
                //adjust bids by adjustment factor
                auction.Bids = Calculations.CalculateAdjustBidValue(auction.Bids, Configuration.Bidders);
                //remove bids lower than floor value
                auction.Bids = Validations.FilterBidsUnderFloor(auction.Bids, floorValue);

                //calculate the highest bidder
                FinalResult.Add(Calculations.CalculateHighestBidder(auction));
            }
            JsonSerializerOptions formatJSONString = new JsonSerializerOptions();
            formatJSONString.WriteIndented = true;
            ReadWriteJSON.PrintResult(JsonSerializer.Serialize<List<HighestAuctionerForUnit[]>>(FinalResult, formatJSONString));
        }
    }
}
