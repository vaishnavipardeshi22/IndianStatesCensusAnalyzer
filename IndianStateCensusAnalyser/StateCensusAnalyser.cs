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
            string[] lines = File.ReadAllLines(csvFilePath);
            return lines.Length-1;
        }
    }
}
