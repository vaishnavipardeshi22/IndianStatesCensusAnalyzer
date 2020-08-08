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
            if (Path.GetFileNameWithoutExtension(csvFilePath) != "StateCensusData")
            {
                throw new StateCensusAnalyserException("File not found", StateCensusAnalyserException.ExceptionType.NO_SUCH_FILE);
            }
            /*if (!csvFilePath.Contains("StateCensusData"))
            {
                throw new StateCensusAnalyserException("File not found", StateCensusAnalyserException.ExceptionType.NO_SUCH_FILE);
            }*/

            if (Path.GetExtension(csvFilePath) != ".csv")
            {
                throw new StateCensusAnalyserException("Incorrect file type", StateCensusAnalyserException.ExceptionType.NO_SUCH_FILE_TYPE);
            }

            string[] lines = File.ReadAllLines(csvFilePath);
            return lines.Length-1;
        }
    }
}
