﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace IndianStateCensusAnalyser
{
    public class StateCensusAnalyser : ICSVBuilder
    {
        Dictionary<string, CensusDTO> dataMap = new Dictionary<string, CensusDTO>();

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

            if (lines[0] != header)
            {
                throw new StateCensusAnalyserException("Incorrect header", 
                    StateCensusAnalyserException.ExceptionType.NO_SUCH_HEADER);
            }

            return dataMap.Skip(1).ToDictionary(field => field.Key, field => field.Value);
        }

        public object GetSortedStateWiseCensusDataInJsonFormat(string csvFilePath, string header, string headerField, string sortBy)
        {
            var data = (Dictionary<string, CensusDTO>)loadCSVDataFile(csvFilePath, header);
            List<CensusDTO> censusDataList = data.Values.ToList();
            List<CensusDTO> sortedList = getSortedData(headerField, censusDataList);

            if (sortBy.Contains("DESC")) sortedList.Reverse();

            return JsonConvert.SerializeObject(sortedList);
        }

        public List<CensusDTO> getSortedData(string headerField, List<CensusDTO> censusDataList)
        {
            switch (headerField)
            {
                case "stateName": return censusDataList.OrderBy(field => field.stateName).ToList();
                case "stateCode": return censusDataList.OrderBy(field => field.stateCode).ToList();
                case "state": return censusDataList.OrderBy(field => field.state).ToList();
                case "area": return censusDataList.OrderBy(field => field.areaInSqKm).ToList();
                case "population": return censusDataList.OrderBy(field => field.population).ToList();
                default: return censusDataList.OrderBy(field => field.tin).ToList();
            }
        }
    }
}