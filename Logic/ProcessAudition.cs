using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SortableChallenge
{
    public class ProcessAudition
    {
        private ReadWriteJSON ReadWriteJSON = new ReadWriteJSON();
        private BidConfiguration[] Configuration;

        public ProcessAudition() : this(Constants.CONFIG_PATH, Constants.INPUT_PATH)
        {

        }

        public ProcessAudition(string configPath, string inputPath)
        {
            BidConfiguration config = ReadWriteJSON.ReadAndParseJSON<BidConfiguration>(configPath);

            //Gaurd clause - file read/parse error
            if (config == null)
            {
                throw new Exception();
            }
        }
    }
}

