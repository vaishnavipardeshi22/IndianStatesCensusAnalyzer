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
            if (!csvFilePath.Contains("StateCensusData.csv"))
            {
                throw new StateCensusAnalyserException("File not found", StateCensusAnalyserException.ExceptionType.NO_SUCH_FILE);
            }
          
            string[] lines = File.ReadAllLines(csvFilePath);
            return lines.Length-1;
        }
    }
}
