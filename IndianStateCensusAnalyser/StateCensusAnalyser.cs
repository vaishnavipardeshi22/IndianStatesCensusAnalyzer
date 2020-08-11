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
        Dictionary<int, string> dataMap = new Dictionary<int, string>();
        int key = 0;

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

            string[] lines = File.ReadAllLines(csvFilePath);
            foreach (string line in lines)
            {
                key++;
                dataMap.Add(key, line);
                if (!line.Contains(','))
                {
                    throw new StateCensusAnalyserException("Incorrect delimiter",
                    StateCensusAnalyserException.ExceptionType.NO_SUCH_DELIMITER);
                }  
            }

            if (lines[0] != header)
            {
                throw new StateCensusAnalyserException("Incorrect header", 
                    StateCensusAnalyserException.ExceptionType.NO_SUCH_HEADER);
            }

            return dataMap.Skip(1).ToDictionary(field => field.Key, field => field.Value);
        }
        
        public object GetSortedStateWiseCensusData(string csvFilePath, string header, int headerField)
        {
            Dictionary<int, string> dataMap = (Dictionary<int, string>)loadCSVDataFile(csvFilePath, header);
            string[] lines = dataMap.Values.ToArray();
            var data = lines;

            var sortedData = from line in data
                             let field = line.Split(',')
                             orderby field[headerField]
                             select line;

            File.WriteAllLines(header, lines.Take(1).Concat(sortedData.ToArray()));
            List<string> sortedFile = sortedData.ToList();

            return JsonConvert.SerializeObject(sortedFile);
        }
    }
}