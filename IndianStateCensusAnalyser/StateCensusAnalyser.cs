using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace IndianStateCensusAnalyser
{
    public class StateCensusAnalyser : ICSVBuilder
    {
        List<string> lines = new List<string>();

        public delegate object CSVData(string csvFilePath, string header);
        public object loadCSVDataFile(string csvFilePath, string header)
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

            lines = File.ReadAllLines(csvFilePath).ToList();
            foreach (string line in lines)
            {
                if (!line.Contains(','))
                {
                    throw new StateCensusAnalyserException("Incorrect delimiter",
                    StateCensusAnalyserException.ExceptionType.NO_SUCH_DELIMITER);
                }  
            }

            if (lines[0] != header)
            {
                throw new StateCensusAnalyserException("Incorrect header", StateCensusAnalyserException.ExceptionType.NO_SUCH_HEADER);
            }

            return lines.Skip(1).ToList();
        }
        
        public object GetSortedStateWiseCensusData(string csvFilePath, string sortedFilePath)
        {
            string[] lines = File.ReadAllLines(csvFilePath);
            var data = lines.Skip(1);

            var sortedData = from line in data
                             let field = line.Split(',')
                             orderby field[0]
                             select line;

            File.WriteAllLines(sortedFilePath, lines.Take(1).Concat(sortedData.ToArray()));
            List<string> sortedFile = sortedData.ToList<string>();

            return JsonConvert.SerializeObject(sortedFile);
        }
    }
}