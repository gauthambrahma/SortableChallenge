using System;

namespace SortableChallenge
{
    public class ProcessAudition
    {
        private ReadWriteJSON ReadWriteJSON = new ReadWriteJSON();
        private BidConfiguration Configuration;
        private SiteBidEntry[] SiteBids;

        public ProcessAudition() : this(Constants.CONFIG_PATH, Constants.INPUT_PATH)
        {

        }

        public ProcessAudition(string configPath, string inputPath)
        {
            Configuration = ReadWriteJSON.ReadAndParseJSON<BidConfiguration>(configPath);
            SiteBids = ReadWriteJSON.ReadAndParseJSONList<SiteBidEntry>(inputPath).ToArray();
        }
    }
}
