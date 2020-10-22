using System.Linq;

namespace SortableChallenge
{
    public class ProcessAudition
    {
        private readonly ReadWriteJSON ReadWriteJSON = new ReadWriteJSON();
        private readonly BidConfiguration Configuration;
        private readonly SiteBidEntry[] SiteBids;
        private readonly Calculations Calculations = new Calculations();
        private readonly Validations Validations = new Validations();

        public ProcessAudition() : this(Constants.CONFIG_PATH, Constants.INPUT_PATH)
        {

        }

        public ProcessAudition(string configPath, string inputPath)
        {
            Configuration = ReadWriteJSON.ReadAndParseJSON<BidConfiguration>(configPath);
            foreach (var item in Configuration.Bidders)
            {
                item.AdjustmentFactor = item.Adjustment < 0 ? AdjustmentFactor.NEGATIVE : AdjustmentFactor.POSITIVE;
            }
            SiteBids = ReadWriteJSON.ReadAndParseJSONList<SiteBidEntry>(inputPath).ToArray();
        }

        public void PorcessBids()
        {
            foreach (SiteBidEntry sitebid in SiteBids)
            {
                //retrive floor value for from config for current bid
                int floorValue = Configuration.Sites.Where(cs => cs.Name == sitebid.Site).Select(cs => cs.Floor).First();
                //remove bids lower than floor value
                sitebid.Bids = Validations.FilterBidsUnderFloor(sitebid.Bids, floorValue);
                //retrive permitted bids for current bid
                string[] permittedBids = Configuration.Sites.Where(cs => cs.Name == sitebid.Site).Select(cs => cs.Bidders).First();
                //remove bids from bidders not on permmited bidders list
                sitebid.Bids = Validations.FilterBidsNotPermitted(sitebid.Bids, permittedBids);
		
            }
        }
    }
}
