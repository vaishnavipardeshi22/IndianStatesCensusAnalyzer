using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateCensusAnalyser
{
    public class CensusAdapterFactory
    {
        public Dictionary<string, CensusDTO> LoadCSVCensusData(StateCensusAnalyser.Country country, string csvFilePath, string headers)
        {
            return country switch
            {
                (StateCensusAnalyser.Country.INDIA) => new IndianStateCensusAdapter().LoadCensusData(csvFilePath, headers),
                (StateCensusAnalyser.Country.US) => new USCensusAdapter().LoadCensusData(csvFilePath, headers),
                _ => throw new StateCensusAnalyserException("No such country found", StateCensusAnalyserException.ExceptionType.NO_SUCH_COUNTRY),
            };
        }
    }
}
