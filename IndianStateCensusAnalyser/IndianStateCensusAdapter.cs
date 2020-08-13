using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace IndianStateCensusAnalyser
{
    class IndianStateCensusAdapter : CensusAdapter
    {
        Dictionary<string, CensusDTO> dataMap = new Dictionary<string, CensusDTO>();   
        public Dictionary<string, CensusDTO> LoadCensusData(string csvFilePath, string headers)
        {
            string[] lines = GetCensusData(csvFilePath, headers);
            foreach (string line in lines.Skip(1))
            {
                if (!line.Contains(','))
                {
                    throw new StateCensusAnalyserException("Incorrect delimiter",
                    StateCensusAnalyserException.ExceptionType.NO_SUCH_DELIMITER);
                }

                string[] field = line.Split(',');

                if (csvFilePath.Contains("StateCode.csv"))
                    dataMap.Add(field[1], new CensusDTO(new CSVStateCode(field[0], field[1], field[2], field[3])));
                if (csvFilePath.Contains("StateCensusData.csv"))
                    dataMap.Add(field[0], new CensusDTO(new CSVStateCensus(field[0], field[1], field[2], field[3])));
            }

            return dataMap.Skip(1).ToDictionary(field => field.Key, field => field.Value);
        }
    }
}
