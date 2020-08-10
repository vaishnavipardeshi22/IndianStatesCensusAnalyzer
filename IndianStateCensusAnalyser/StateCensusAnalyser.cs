using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IndianStateCensusAnalyser
{
    public class StateCensusAnalyser
    {
        public int loadCSVDataFile(string csvFilePath)
        {
            if (!csvFilePath.Contains("StateCensusData"))
            {
                throw new StateCensusAnalyserException("File not found",
                    StateCensusAnalyserException.ExceptionType.NO_SUCH_FILE);
            }
           
            if (Path.GetExtension(csvFilePath) != ".csv")
            {
                throw new StateCensusAnalyserException("Incorrect file type",
                    StateCensusAnalyserException.ExceptionType.NO_SUCH_FILE_TYPE);
            }

            string[] lines = File.ReadAllLines(csvFilePath);
            foreach (string line in lines)
            {
                if (!line.Contains(','))
                {
                    throw new StateCensusAnalyserException("Incorrect delimiter",
                    StateCensusAnalyserException.ExceptionType.NO_SUCH_DELIMITER);
                }  
            }

            List<CSVStateCensus> list = new List<CSVStateCensus>();
            StreamReader reader = new StreamReader(csvFilePath);
            string header = reader.ReadLine();

            if (!header.Contains("State") || !header.Contains("Population") || !header.Contains("AreaInSqKm") || !header.Contains("DensityPerSqKm"))
            {
                throw new StateCensusAnalyserException("Incorrect header", StateCensusAnalyserException.ExceptionType.NO_SUCH_HEADER);
            }

            return lines.Length-1;
        }
    }
}
