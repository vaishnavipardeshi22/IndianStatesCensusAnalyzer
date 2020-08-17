// <copyright file="CensusAnalyserTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace IndianStateCensusAnalyserTest
{
    using System.Collections.Generic;
    using IndianStateCensusAnalyser;
    using Newtonsoft.Json;
    using NUnit.Framework;
    using static IndianStateCensusAnalyser.StateCensusAnalyser;

    /// <summary>
    /// Test class for census analyser.
    /// </summary>
    public class CensusAnalyserTest
    {
        // Indian census data file path.
        private string stateCensusDataCSVFilePath = "C:/Users/admin/source/repos/IndianStateCensusAnalyser/IndianStateCensusAnalyserTest/resources/StateCensusData.csv";
        private string stateCensusDataCSVFileIncorrectPath = "C:/Users/admin/source/repos/IndianStateCensusAnalyser/IndianStateCensusAnalyserTest/resources/CensusData.csv";
        private string stateCensusDataCSVIncorrectFileType = "C:/Users/admin/source/repos/IndianStateCensusAnalyser/IndianStateCensusAnalyserTest/resources/StateCensusData.txt";
        private string stateCensusAnalyserCSVIncorrectDelimiterFileType = "C:/Users/admin/source/repos/IndianStateCensusAnalyser/IndianStateCensusAnalyserTest/resources/StateCensusDataIncorrectDelimiter.csv";
        private string stateCensusDataCSVIncorrectHeaderFile = "C:/Users/admin/source/repos/IndianStateCensusAnalyser/IndianStateCensusAnalyserTest/resources/StateCensusDataIncorrectHeader.csv";

        // Indian code data file path.
        private string stateCodeDataCSVFilePath = "C:/Users/admin/source/repos/IndianStateCensusAnalyser/IndianStateCensusAnalyserTest/resources/StateCode.csv";
        private string stateCodeDataCSVFileIncorrectPath = "C:/Users/admin/source/repos/IndianStateCensusAnalyser/IndianStateCensusAnalyserTest/resources/StatesCode.csv";
        private string stateCodeDataCSVFileIncorrectType = "C:/Users/admin/source/repos/IndianStateCensusAnalyser/IndianStateCensusAnalyserTest/resources/StateCode.txt";
        private string stateCodeDataCSVFileIncorrectDelimiter = "C:/Users/admin/source/repos/IndianStateCensusAnalyser/IndianStateCensusAnalyserTest/resources/StateCodeIncorrectDelimiter.csv";
        private string stateCodeDataCSVFileIncorrectHeader = "C:/Users/admin/source/repos/IndianStateCensusAnalyser/IndianStateCensusAnalyserTest/resources/StateCodeIncorrectHeader.csv";

        // US census data file path.
        private string usCensusDataCSVFilePath = "C:/Users/admin/source/repos/IndianStateCensusAnalyser/IndianStateCensusAnalyserTest/resources/USCensusData.csv";
        private string usCensusDataCSVFileIncorrectPath = "C:/Users/admin/source/repos/IndianStateCensusAnalyser/IndianStateCensusAnalyserTest/resources/USData.csv";
        private string usCensusDataCSVIncorrectFileType = "C:/Users/admin/source/repos/IndianStateCensusAnalyser/IndianStateCensusAnalyserTest/resources/USCensusData.txt";
        private string usCensusDataCSVIncorrectDelimiter = "C:/Users/admin/source/repos/IndianStateCensusAnalyser/IndianStateCensusAnalyserTest/resources/USCensusDataIncorrectDelimiter.csv";
        private string usCensusDataCSVIncorrectHeader = "C:/Users/admin/source/repos/IndianStateCensusAnalyser/IndianStateCensusAnalyserTest/resources/USCensusDataIncorrectHeader.csv";

        // CSV header.
        private string indianCensusHeader = "State,Population,AreaInSqKm,DensityPerSqKm";
        private string indianStateCodeHeader = "SrNo,StateName,TIN,StateCode";
        private string usCensusHeader = "State Id,State,Population,Housing units,Total area,Water area,Land area,Population Density,Housing Density";

        private StateCensusAnalyser stateCensusAnalyser;
        private Dictionary<string, CensusDTO> numberOfRecords = new Dictionary<string, CensusDTO>();
        private Dictionary<string, CensusDTO> totalRecords = new Dictionary<string, CensusDTO>();

        /// <summary>
        /// Set up method.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.stateCensusAnalyser = new StateCensusAnalyser();
            this.numberOfRecords = new Dictionary<string, CensusDTO>();
            this.totalRecords = new Dictionary<string, CensusDTO>();
        }

        /// <summary>
        /// Test method to match the number of records of csv data.
        /// </summary>
        [Test]
        public void GivenIndianStatesCensusCSVFile_WhenMatchNoOfRecord_ThenReturnTrue()
        {
            this.numberOfRecords = this.stateCensusAnalyser.loadCSVDataFile(Country.INDIA, this.stateCensusDataCSVFilePath, this.indianCensusHeader);
            this.totalRecords = this.stateCensusAnalyser.loadCSVDataFile(Country.INDIA, this.stateCodeDataCSVFilePath, this.indianStateCodeHeader);
            Assert.AreEqual(29, this.numberOfRecords.Count);
            Assert.AreEqual(37, this.totalRecords.Count);
        }

        /// <summary>
        /// Test method to check incorrect file path.
        /// </summary>
        [Test]
        public void GivenIncorrectIndianStatesCensusCSVFile_WhenUnmatch_ThenThrowCustomException()
        {
            var censusResult = Assert.Throws<StateCensusAnalyserException>(() => this.stateCensusAnalyser.loadCSVDataFile(Country.INDIA, this.stateCensusDataCSVFileIncorrectPath, this.indianCensusHeader));
            var codeResult = Assert.Throws<StateCensusAnalyserException>(() => this.stateCensusAnalyser.loadCSVDataFile(Country.INDIA, this.stateCodeDataCSVFileIncorrectPath, this.indianStateCodeHeader));
            Assert.AreEqual(StateCensusAnalyserException.ExceptionType.NO_SUCH_FILE, censusResult.type);
            Assert.AreEqual(StateCensusAnalyserException.ExceptionType.NO_SUCH_FILE, codeResult.type);
        }

        /// <summary>
        /// Test method to check incorrect file type.
        /// </summary>
        [Test]
        public void GivenIncorrectIndianStatesCensusCSVFileType_WhenUnmatch_ThenThrowCustomException()
        {
            var censusResult = Assert.Throws<StateCensusAnalyserException>(() => this.stateCensusAnalyser.loadCSVDataFile(Country.INDIA, this.stateCensusDataCSVIncorrectFileType, this.indianCensusHeader));
            var codeResult = Assert.Throws<StateCensusAnalyserException>(() => this.stateCensusAnalyser.loadCSVDataFile(Country.INDIA, this.stateCodeDataCSVFileIncorrectType, this.indianStateCodeHeader));
            Assert.AreEqual(StateCensusAnalyserException.ExceptionType.NO_SUCH_FILE_TYPE, censusResult.type);
            Assert.AreEqual(StateCensusAnalyserException.ExceptionType.NO_SUCH_FILE_TYPE, codeResult.type);
        }

        /// <summary>
        /// Test method to check incorrect delimiter.
        /// </summary>
        [Test]
        public void GivenIncorrectDelimiterIndianStatesCensusCSVFile_WhenUnmatch_ThenThrowCustomException()
        {
            var censusResult = Assert.Throws<StateCensusAnalyserException>(() => this.stateCensusAnalyser.loadCSVDataFile(Country.INDIA, this.stateCensusAnalyserCSVIncorrectDelimiterFileType, this.indianCensusHeader));
            var codeResult = Assert.Throws<StateCensusAnalyserException>(() => this.stateCensusAnalyser.loadCSVDataFile(Country.INDIA, this.stateCodeDataCSVFileIncorrectDelimiter, this.indianStateCodeHeader));
            Assert.AreEqual(StateCensusAnalyserException.ExceptionType.NO_SUCH_DELIMITER, censusResult.type);
            Assert.AreEqual(StateCensusAnalyserException.ExceptionType.NO_SUCH_DELIMITER, codeResult.type);
        }

        /// <summary>
        /// Test method to check incorrect header.
        /// </summary>
        [Test]
        public void GivenIncorrectHeaderIndianStatesCensusCSVFile_WhenUnmatch_ThenThrowCustomException()
        {
            var censusResult = Assert.Throws<StateCensusAnalyserException>(() => this.stateCensusAnalyser.loadCSVDataFile(Country.INDIA, this.stateCensusDataCSVIncorrectHeaderFile, this.indianCensusHeader));
            var codeResult = Assert.Throws<StateCensusAnalyserException>(() => this.stateCensusAnalyser.loadCSVDataFile(Country.INDIA, this.stateCodeDataCSVFileIncorrectHeader, this.indianStateCodeHeader));
            Assert.AreEqual(StateCensusAnalyserException.ExceptionType.NO_SUCH_HEADER, censusResult.type);
            Assert.AreEqual(StateCensusAnalyserException.ExceptionType.NO_SUCH_HEADER, codeResult.type);
        }

        /// <summary>
        /// Test method to match number of records of state code.
        /// </summary>
        [Test]
        public void GivenIndianStatesCodeCSVFile_WhenMatchNoOfRecord_ThenReturnTrue()
        {
            this.numberOfRecords = this.stateCensusAnalyser.loadCSVDataFile(Country.INDIA, this.stateCodeDataCSVFilePath, this.indianStateCodeHeader);
            Assert.AreEqual(37, this.numberOfRecords.Count);
        }

        /// <summary>
        /// Test method to check incorrect file path for state code.
        /// </summary>
        [Test]
        public void GivenIncorrectIndianStatesCodeCSVFile_WhenUnmatch_ThenThrowCustomException()
        {
            var result = Assert.Throws<StateCensusAnalyserException>(() => this.stateCensusAnalyser.loadCSVDataFile(Country.INDIA, this.stateCodeDataCSVFileIncorrectPath, this.indianStateCodeHeader));
            Assert.AreEqual(StateCensusAnalyserException.ExceptionType.NO_SUCH_FILE, result.type);
        }

        /// <summary>
        /// Test method to check incorrect file type.
        /// </summary>
        [Test]
        public void GivenIncorrectIndianStatesCodeCSVFileType_WhenUnmatch_ThenThrowCustomException()
        {
            var result = Assert.Throws<StateCensusAnalyserException>(() => this.stateCensusAnalyser.loadCSVDataFile(Country.INDIA, this.stateCodeDataCSVFileIncorrectType, this.indianStateCodeHeader));
            Assert.AreEqual(StateCensusAnalyserException.ExceptionType.NO_SUCH_FILE_TYPE, result.type);
        }

        /// <summary>
        /// Test method to check incorrect delimiter.
        /// </summary>
        [Test]
        public void GivenIncorrectDelimiterIndianStatesCodeCSVFile_WhenUnmatch_ThenThrowCustomException()
        {
            var result = Assert.Throws<StateCensusAnalyserException>(() => this.stateCensusAnalyser.loadCSVDataFile(Country.INDIA, this.stateCodeDataCSVFileIncorrectDelimiter, this.indianStateCodeHeader));
            Assert.AreEqual(StateCensusAnalyserException.ExceptionType.NO_SUCH_DELIMITER, result.type);
        }

        /// <summary>
        /// Test method to check incorrect header.
        /// </summary>
        [Test]
        public void GivenIncorrectHeaderIndianStatesCodeCSVFile_WhenUnmatch_ThenThrowCustomException()
        {
            var result = Assert.Throws<StateCensusAnalyserException>(() => this.stateCensusAnalyser.loadCSVDataFile(Country.INDIA, this.stateCodeDataCSVFileIncorrectHeader, this.indianStateCodeHeader));
            Assert.AreEqual(StateCensusAnalyserException.ExceptionType.NO_SUCH_HEADER, result.type);
        }

        /// <summary>
        /// Test method to sort data by state name in ascending order.
        /// </summary>
        [Test]
        public void GivenIndianCensusData_WhenSortedState_thenReturnSortedStartResult()
        {
            string sortedStateCensusData = this.stateCensusAnalyser.GetSortedStateWiseCensusDataInJsonFormat(Country.INDIA, this.stateCensusDataCSVFilePath, this.indianCensusHeader, "state", "ASC").ToString();
            CSVStateCensus[] sortedData = JsonConvert.DeserializeObject<CSVStateCensus[]>(sortedStateCensusData);
            Assert.AreEqual("Andhra Pradesh", sortedData[0].state);
        }

        /// <summary>
        /// Test method to sort data by state name in descending order.
        /// </summary>
        [Test]
        public void GivenIndianCensusData_WhenSortedState_thenReturnSortedLastResult()
        {
            string sortedStateCensusData = this.stateCensusAnalyser.GetSortedStateWiseCensusDataInJsonFormat(Country.INDIA, this.stateCensusDataCSVFilePath, this.indianCensusHeader, "state",  "DESC").ToString();
            CSVStateCensus[] sortedData = JsonConvert.DeserializeObject<CSVStateCensus[]>(sortedStateCensusData);
            Assert.AreEqual("West Bengal", sortedData[0].state);
        }

        /// <summary>
        /// Test method to sort data by state code in ascending order.
        /// </summary>
        [Test]
        public void GivenStateCodeData_WhenSortedCode_ThenReturnSortedStartResult()
        {
            string sortedStateCodeData = this.stateCensusAnalyser.GetSortedStateWiseCensusDataInJsonFormat(Country.INDIA, this.stateCodeDataCSVFilePath, this.indianStateCodeHeader, "stateCode", "ASC").ToString();
            CSVStateCode[] sortedData = JsonConvert.DeserializeObject<CSVStateCode[]>(sortedStateCodeData);
            Assert.AreEqual("AD", sortedData[0].stateCode);
        }

        /// <summary>
        /// Test method to sort data by state code in descending order.
        /// </summary>
        [Test]
        public void GivenStateCodeData_WhenSortedCode_ThenReturnSortedLastResult()
        {
            string sortedStateCodeData = this.stateCensusAnalyser.GetSortedStateWiseCensusDataInJsonFormat(Country.INDIA, this.stateCodeDataCSVFilePath, this.indianStateCodeHeader, "stateCode", "DESC").ToString();
            CSVStateCode[] sortedData = JsonConvert.DeserializeObject<CSVStateCode[]>(sortedStateCodeData);
            Assert.AreEqual("WB", sortedData[0].stateCode);
        }

        /// <summary>
        /// Test method to get most populated state.
        /// </summary>
        [Test]
        public void GivenStateCensusData_WhenSortedByPopulation_ThenReturnSortedMostPopulatedResult()
        {
            string sortedStateCensusData = this.stateCensusAnalyser.GetSortedStateWiseCensusDataInJsonFormat(Country.INDIA, this.stateCensusDataCSVFilePath, this.indianCensusHeader, "population", "ASC").ToString();
            CSVStateCensus[] sortedData = JsonConvert.DeserializeObject<CSVStateCensus[]>(sortedStateCensusData);
            Assert.AreEqual("Uttar Pradesh", sortedData[^1].state);
        }

        /// <summary>
        /// Test method to get least populated state.
        /// </summary>
        [Test]
        public void GivenStateCensusData_WhenSortedByPopulation_ThenReturnSortedLeastPopulatedResult()
        {
            string sortedStateCensusData = this.stateCensusAnalyser.GetSortedStateWiseCensusDataInJsonFormat(Country.INDIA, this.stateCensusDataCSVFilePath, this.indianCensusHeader, "population", "DESC").ToString();
            CSVStateCensus[] sortedData = JsonConvert.DeserializeObject<CSVStateCensus[]>(sortedStateCensusData);
            Assert.AreEqual("Sikkim", sortedData[^1].state);
        }

        /// <summary>
        /// Test method to get most populated density state.
        /// </summary>
        [Test]
        public void GivenStateCensusData_WhenSortedByPopulationDensity_ThenReturnSortedMostPopulatedDensityResult()
        {
            string sortedStateCensusData = this.stateCensusAnalyser.GetSortedStateWiseCensusDataInJsonFormat(Country.INDIA, this.stateCensusDataCSVFilePath, this.indianCensusHeader, "populationDensity", "ASC").ToString();
            CSVStateCensus[] sortedData = JsonConvert.DeserializeObject<CSVStateCensus[]>(sortedStateCensusData);
            Assert.AreEqual("Bihar", sortedData[^1].state);
        }

        /// <summary>
        /// Test method to get least populated density state.
        /// </summary>
        [Test]
        public void GivenStateCensusData_WhenSortedByPopulationDensity_ThenReturnSortedLeastPopulatedDensityResult()
        {
            string sortedStateCensusData = this.stateCensusAnalyser.GetSortedStateWiseCensusDataInJsonFormat(Country.INDIA, this.stateCensusDataCSVFilePath, this.indianCensusHeader, "populationDensity", "DESC").ToString();
            CSVStateCensus[] sortedData = JsonConvert.DeserializeObject<CSVStateCensus[]>(sortedStateCensusData);
            Assert.AreEqual("Arunachal Pradesh", sortedData[^1].state);
        }

        /// <summary>
        /// Test method to get largest area state.
        /// </summary>
        [Test]
        public void GivenStateCensusData_WhenSortedByArea_ThenReturnSortedMostAreaResult()
        {
            string sortedStateCensusData = this.stateCensusAnalyser.GetSortedStateWiseCensusDataInJsonFormat(Country.INDIA, this.stateCensusDataCSVFilePath, this.indianCensusHeader, "area", "ASC").ToString();
            CSVStateCensus[] sortedData = JsonConvert.DeserializeObject<CSVStateCensus[]>(sortedStateCensusData);
            Assert.AreEqual("Rajasthan", sortedData[^1].state);
        }

        /// <summary>
        /// Test method to get smallest area state.
        /// </summary>
        [Test]
        public void GivenStateCensusData_WhenSortedByArea_ThenReturnSortedLeastAreaResult()
        {
            string sortedStateCensusData = this.stateCensusAnalyser.GetSortedStateWiseCensusDataInJsonFormat(Country.INDIA, this.stateCensusDataCSVFilePath, this.indianCensusHeader, "area", "DESC").ToString();
            CSVStateCensus[] sortedData = JsonConvert.DeserializeObject<CSVStateCensus[]>(sortedStateCensusData);
            Assert.AreEqual("Arunachal Pradesh", sortedData[^1].state);
        }

        /// <summary>
        /// Test method to match records of us census data.
        /// </summary>
        [Test]
        public void GivenUSCensusCSVFile_WhenUnMatchNoOfRecord_ThenReturnFalse()
        {
            this.numberOfRecords = this.stateCensusAnalyser.loadCSVDataFile(Country.US, this.usCensusDataCSVFilePath, this.usCensusHeader);
            Assert.AreNotEqual(51, this.numberOfRecords.Count);
        }

        /// <summary>
        /// Test method to check incorrect file path.
        /// </summary>
        [Test]
        public void GivenIncorrectUSCensusCSVFile_WhenUnmatch_ThenThrowCustomException()
        {
            var result = Assert.Throws<StateCensusAnalyserException>(() => this.stateCensusAnalyser.loadCSVDataFile(Country.US, this.usCensusDataCSVFileIncorrectPath, this.usCensusHeader));
            Assert.AreEqual(StateCensusAnalyserException.ExceptionType.NO_SUCH_FILE, result.type);
        }

        /// <summary>
        /// Test method to check incorrect file type.
        /// </summary>
        [Test]
        public void GivenIncorrectUSCensusCSVFileType_WhenUnmatch_ThenThrowCustomException()
        {
            var result = Assert.Throws<StateCensusAnalyserException>(() => this.stateCensusAnalyser.loadCSVDataFile(Country.US, this.usCensusDataCSVIncorrectFileType, this.usCensusHeader));
            Assert.AreEqual(StateCensusAnalyserException.ExceptionType.NO_SUCH_FILE_TYPE, result.type);
        }

        /// <summary>
        /// Test method to check incorrect delimiter.
        /// </summary>
        [Test]
        public void GivenIncorrectDelimiterUSCensusCSVFile_WhenUnmatch_ThenThrowCustomException()
        {
            var result = Assert.Throws<StateCensusAnalyserException>(() => this.stateCensusAnalyser.loadCSVDataFile(Country.US, this.usCensusDataCSVIncorrectDelimiter, this.usCensusHeader));
            Assert.AreEqual(StateCensusAnalyserException.ExceptionType.NO_SUCH_DELIMITER, result.type);
        }

        /// <summary>
        /// Test method to check incorrect header.
        /// </summary>
        [Test]
        public void GivenIncorrectHeaderUSCensusCSVFile_WhenUnmatch_ThenThrowCustomException()
        {
            var result = Assert.Throws<StateCensusAnalyserException>(() => this.stateCensusAnalyser.loadCSVDataFile(Country.US, this.usCensusDataCSVIncorrectHeader, this.usCensusHeader));
            Assert.AreEqual(StateCensusAnalyserException.ExceptionType.NO_SUCH_HEADER, result.type);
        }

        /// <summary>
        /// Test method to get most populated state.
        /// </summary>
        [Test]
        public void GivenUSCensusData_WhenSortedByPopulation_ThenReturnSortedMostPopulatedResult()
        {
            string sortedStateCensusData = this.stateCensusAnalyser.GetSortedStateWiseCensusDataInJsonFormat(Country.US, this.usCensusDataCSVFilePath, this.usCensusHeader, "population", "ASC").ToString();
            CSVUSCensus[] sortedData = JsonConvert.DeserializeObject<CSVUSCensus[]>(sortedStateCensusData);
            Assert.AreEqual("California", sortedData[^1].stateName);
        }

        /// <summary>
        /// Test method to get least populated state.
        /// </summary>
        [Test]
        public void GivenUSCensusData_WhenSortedByPopulation_ThenReturnSortedLeastPopulatedResult()
        {
            string sortedStateCensusData = this.stateCensusAnalyser.GetSortedStateWiseCensusDataInJsonFormat(Country.US, this.usCensusDataCSVFilePath, this.usCensusHeader, "population", "DESC").ToString();
            CSVUSCensus[] sortedData = JsonConvert.DeserializeObject<CSVUSCensus[]>(sortedStateCensusData);
            Assert.AreEqual("Wyoming", sortedData[^1].stateName);
        }

        /// <summary>
        /// Test method to get most populated density state.
        /// </summary>
        [Test]
        public void GivenUSCensusData_WhenSortedByPopulationDensity_ThenReturnSortedMostDensedResult()
        {
            string sortedStateCensusData = this.stateCensusAnalyser.GetSortedStateWiseCensusDataInJsonFormat(Country.US, this.usCensusDataCSVFilePath, this.usCensusHeader, "usPopulationDensity", "ASC").ToString();
            CSVUSCensus[] sortedData = JsonConvert.DeserializeObject<CSVUSCensus[]>(sortedStateCensusData);
            Assert.AreEqual("District of Columbia", sortedData[^1].stateName);
        }

        /// <summary>
        /// Test method to get least populated density state.
        /// </summary>
        [Test]
        public void GivenUSCensusData_WhenSortedByPopulationDensity_ThenReturnSortedLeastDensedResult()
        {
            string sortedStateCensusData = this.stateCensusAnalyser.GetSortedStateWiseCensusDataInJsonFormat(Country.US, this.usCensusDataCSVFilePath, this.usCensusHeader, "usPopulationDensity", "DESC").ToString();
            CSVUSCensus[] sortedData = JsonConvert.DeserializeObject<CSVUSCensus[]>(sortedStateCensusData);
            Assert.AreEqual("Alaska", sortedData[^1].stateName);
        }

        /// <summary>
        /// Test method to get largest area state.
        /// </summary>
        [Test]
        public void GivenUSCensusData_WhenSortedByPopulationDensity_ThenReturnSortedLargeAreaResult()
        {
            string sortedStateCensusData = this.stateCensusAnalyser.GetSortedStateWiseCensusDataInJsonFormat(Country.US, this.usCensusDataCSVFilePath, this.usCensusHeader, "totalArea", "ASC").ToString();
            CSVUSCensus[] sortedData = JsonConvert.DeserializeObject<CSVUSCensus[]>(sortedStateCensusData);
            Assert.AreEqual("Alaska", sortedData[^1].stateName);
        }

        /// <summary>
        /// Test method to get smallest area state.
        /// </summary>
        [Test]
        public void GivenUSCensusData_WhenSortedByPopulationDensity_ThenReturnSortedSmallAreaResult()
        {
            string sortedStateCensusData = this.stateCensusAnalyser.GetSortedStateWiseCensusDataInJsonFormat(Country.US, this.usCensusDataCSVFilePath, this.usCensusHeader, "totalArea", "DESC").ToString();
            CSVUSCensus[] sortedData = JsonConvert.DeserializeObject<CSVUSCensus[]>(sortedStateCensusData);
            Assert.AreEqual("District of Columbia", sortedData[^1].stateName);
        }

        /// <summary>
        /// Test method to get most populated density state in between indian census and us census.
        /// </summary>
        [Test]
        public void GivenTheUSAndIndiaCensusData_WhenSortedOnPopulation_ShouldReturnMostPopulousStateWithDensity()
        {
            string indianSortedStateCensusData = this.stateCensusAnalyser.GetSortedStateWiseCensusDataInJsonFormat(Country.INDIA, this.stateCensusDataCSVFilePath, this.indianCensusHeader, "populationDensity", "ASC").ToString();
            CSVStateCensus[] indianSortedData = JsonConvert.DeserializeObject<CSVStateCensus[]>(indianSortedStateCensusData);

            string usSortedStateCensusData = this.stateCensusAnalyser.GetSortedStateWiseCensusDataInJsonFormat(Country.US, this.usCensusDataCSVFilePath, this.usCensusHeader, "usPopulationDensity", "ASC").ToString();
            CSVUSCensus[] usSortedData = JsonConvert.DeserializeObject<CSVUSCensus[]>(usSortedStateCensusData);

            Assert.AreEqual(true, indianSortedData[^1].densityPerSqKm.CompareTo((long)usSortedData[^1].populationDensity) < 0);
        }
    }
}