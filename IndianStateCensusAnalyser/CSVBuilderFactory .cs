using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateCensusAnalyser
{
    public class CSVBuilderFactory
    {
        public ICSVBuilder createCSVBuilder()
        {
            return new StateCensusAnalyser();
        }
    }
}
