using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IndianStateCensusAnalyser
{
    public abstract class CensusAdapter
    {
        protected string[] GetCensusData(string csvFilePath, string headers)
        {
            if (!File.Exists(csvFilePath))
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
            if (lines[0] != headers)
            {
                throw new StateCensusAnalyserException("Incorrect header",
                    StateCensusAnalyserException.ExceptionType.NO_SUCH_HEADER);
            }

            return lines;
        }
    }
}
