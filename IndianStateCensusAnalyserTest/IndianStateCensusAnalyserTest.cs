using IndianStateCensusAnalyser;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using static IndianStateCensusAnalyser.StateCensusAnalyser;

namespace IndianStateCensusAnalyserTest
{
    public class Tests
    {
        private string STATE_CENSUS_DATA_CSV_FILE_PATH = "C:/Users/admin/source/repos/IndianStateCensusAnalyser/IndianStateCensusAnalyserTest/resources/StateCensusData.csv";
        private string STATE_CENSUS_DATA_CSV_FILE_INCORRECT_PATH = "C:/Users/admin/source/repos/IndianStateCensusAnalyser/IndianStateCensusAnalyserTest/resources/CensusData.csv";
        private string STATE_CENSUS_DATA_CSV_INCORRECT_FILE_TYPE = "C:/Users/admin/source/repos/IndianStateCensusAnalyser/IndianStateCensusAnalyserTest/resources/StateCensusData.txt";
        private string STATE_CENSUS_ANALYSER_CSV_INCORRECT_DELIMITER_FILE_TYPE = "C:/Users/admin/source/repos/IndianStateCensusAnalyser/IndianStateCensusAnalyserTest/resources/StateCensusDataIncorrectDelimiter.csv";
        private string STATE_CENSUS_DATA_CSV_INCORRECT_HEADER_FILE = "C:/Users/admin/source/repos/IndianStateCensusAnalyser/IndianStateCensusAnalyserTest/resources/StateCensusDataIncorrectHeader.csv";

        private string STATE_CODE_DATA_CSV_FILE_PATH = "C:/Users/admin/source/repos/IndianStateCensusAnalyser/IndianStateCensusAnalyserTest/resources/StateCode.csv";
        private string STATE_CODE_DATA_CSV_FILE_INCORRECT_PATH = "C:/Users/admin/source/repos/IndianStateCensusAnalyser/IndianStateCensusAnalyserTest/resources/StatesCode.csv";
        private string STATE_CODE_DATA_CSV_FILE_INCORRECT_TYPE = "C:/Users/admin/source/repos/IndianStateCensusAnalyser/IndianStateCensusAnalyserTest/resources/StateCode.txt";
        private string STATE_CODE_DATA_CSV_FILE_INCORRECT_DELIMITER = "C:/Users/admin/source/repos/IndianStateCensusAnalyser/IndianStateCensusAnalyserTest/resources/StateCodeIncorrectDelimiter.csv";
        private string STATE_CODE_DATA_CSV_FILE_INCORRECT_HEADER = "C:/Users/admin/source/repos/IndianStateCensusAnalyser/IndianStateCensusAnalyserTest/resources/StateCodeIncorrectHeader.csv";

        private string US_CENSUS_DATA_CSV_FILE_PATH = "C:/Users/admin/source/repos/IndianStateCensusAnalyser/IndianStateCensusAnalyserTest/resources/USCensusData.csv";
        private string US_CENSUS_DATA_CSV_FILE_INCORRECT_PATH = "C:/Users/admin/source/repos/IndianStateCensusAnalyser/IndianStateCensusAnalyserTest/resources/USData.csv";
        private string US_CENSUS_DATA_CSV_INCORRECT_FILE_TYPE = "C:/Users/admin/source/repos/IndianStateCensusAnalyser/IndianStateCensusAnalyserTest/resources/USCensusData.txt";
        private string US_CENSUS_DATA_CSV_INCORRECT_DELIMITER = "C:/Users/admin/source/repos/IndianStateCensusAnalyser/IndianStateCensusAnalyserTest/resources/USCensusDataIncorrectDelimiter.csv";
        private string US_CENSUS_DATA_CSV_INCORRECT_HEADER = "C:/Users/admin/source/repos/IndianStateCensusAnalyser/IndianStateCensusAnalyserTest/resources/USCensusDataIncorrectHeader.csv";

        private string INDIAN_CENSUS_HEADER = "State,Population,AreaInSqKm,DensityPerSqKm";
        private string INDIAN_STATE_CODE_HEADER = "SrNo,StateName,TIN,StateCode";
        private string US_CENSUS_HEADER = "State Id,State,Population,Housing units,Total area,Water area,Land area,Population Density,Housing Density";
        
        CSVBuilderFactory csvFactory = new CSVBuilderFactory();
        Dictionary<string, CensusDTO> numberOfRecords = new Dictionary<string, CensusDTO>();
        Dictionary<string, CensusDTO> totalRecords = new Dictionary<string, CensusDTO>();
        CSVData csvData;

        [Test]
        public void GivenIndianStatesCensusCSVFile_WhenMatchNoOfRecord_ThenReturnTrue()
        {
            StateCensusAnalyser stateCensusAnalyser = (StateCensusAnalyser)csvFactory.createCSVBuilder();
            csvData = new CSVData(stateCensusAnalyser.loadCSVDataFile);
            numberOfRecords = (Dictionary<string, CensusDTO>)csvData(STATE_CENSUS_DATA_CSV_FILE_PATH, INDIAN_CENSUS_HEADER);
            totalRecords = (Dictionary<string, CensusDTO>)csvData(STATE_CODE_DATA_CSV_FILE_PATH, INDIAN_STATE_CODE_HEADER);
            Assert.AreEqual(29, numberOfRecords.Count);
            Assert.AreEqual(37, totalRecords.Count);
        }

        [Test]
        public void GivenIndianStatesCensusCSVFile_WhenUnMatchNoOfRecord_ThenReturnFalse()
        {
            StateCensusAnalyser stateCensusAnalyser = (StateCensusAnalyser)csvFactory.createCSVBuilder();
            csvData = new CSVData(stateCensusAnalyser.loadCSVDataFile);
            numberOfRecords = (Dictionary<string, CensusDTO>)csvData(STATE_CENSUS_DATA_CSV_FILE_PATH, INDIAN_CENSUS_HEADER);
            Assert.AreNotEqual(30, numberOfRecords.Count);
        }

        [Test]
        public void GivenIncorrectIndianStatesCensusCSVFile_WhenUnmatch_ThenThrowCustomException()
        {
            StateCensusAnalyser stateCensusAnalyser = (StateCensusAnalyser)csvFactory.createCSVBuilder();
            csvData = new CSVData(stateCensusAnalyser.loadCSVDataFile);
            var result = Assert.Throws<StateCensusAnalyserException>(() => csvData(STATE_CENSUS_DATA_CSV_FILE_INCORRECT_PATH, INDIAN_CENSUS_HEADER));
            Assert.AreEqual(StateCensusAnalyserException.ExceptionType.NO_SUCH_FILE, result.type);
        }

        [Test]
        public void GivenIncorrectIndianStatesCensusCSVFileType_WhenUnmatch_ThenThrowCustomException()
        {
            StateCensusAnalyser stateCensusAnalyser = (StateCensusAnalyser)csvFactory.createCSVBuilder();
            csvData = new CSVData(stateCensusAnalyser.loadCSVDataFile);
            var result = Assert.Throws<StateCensusAnalyserException>(() => csvData(STATE_CENSUS_DATA_CSV_INCORRECT_FILE_TYPE, INDIAN_CENSUS_HEADER));
            Assert.AreEqual(StateCensusAnalyserException.ExceptionType.NO_SUCH_FILE_TYPE, result.type);
        }

        [Test]
        public void GivenIncorrectDelimiterIndianStatesCensusCSVFile_WhenUnmatch_ThenThrowCustomException()
        {
            StateCensusAnalyser stateCensusAnalyser = (StateCensusAnalyser)csvFactory.createCSVBuilder();
            csvData = new CSVData(stateCensusAnalyser.loadCSVDataFile);
            var result = Assert.Throws<StateCensusAnalyserException>(() => csvData(STATE_CENSUS_ANALYSER_CSV_INCORRECT_DELIMITER_FILE_TYPE, INDIAN_CENSUS_HEADER));
            Assert.AreEqual(StateCensusAnalyserException.ExceptionType.NO_SUCH_DELIMITER, result.type);
        }

        [Test]
        public void GivenIncorrectHeaderIndianStatesCensusCSVFile_WhenUnmatch_ThenThrowCustomException()
        {
            StateCensusAnalyser stateCensusAnalyser = (StateCensusAnalyser)csvFactory.createCSVBuilder();
            csvData = new CSVData(stateCensusAnalyser.loadCSVDataFile);
            var result = Assert.Throws<StateCensusAnalyserException>(() => csvData(STATE_CENSUS_DATA_CSV_INCORRECT_HEADER_FILE, INDIAN_CENSUS_HEADER));
            Assert.AreEqual(StateCensusAnalyserException.ExceptionType.NO_SUCH_HEADER, result.type);
        }

        [Test]
        public void GivenIndianStatesCodeCSVFile_WhenMatchNoOfRecord_ThenReturnTrue()
        {
            StateCensusAnalyser stateCensusAnalyser = (StateCensusAnalyser)csvFactory.createCSVBuilder();
            csvData = new CSVData(stateCensusAnalyser.loadCSVDataFile);
            numberOfRecords = (Dictionary<string, CensusDTO>)csvData(STATE_CODE_DATA_CSV_FILE_PATH, INDIAN_STATE_CODE_HEADER);
            Assert.AreEqual(37, numberOfRecords.Count);
        }

        [Test]
        public void GivenIndianStatesCodeCSVFile_WhenUnMatchNoOfRecord_ThenReturnTrue()
        {
            StateCensusAnalyser stateCensusAnalyser = (StateCensusAnalyser)csvFactory.createCSVBuilder();
            csvData = new CSVData(stateCensusAnalyser.loadCSVDataFile);
            numberOfRecords = (Dictionary<string, CensusDTO>)csvData(STATE_CODE_DATA_CSV_FILE_PATH, INDIAN_STATE_CODE_HEADER);
            Assert.AreNotEqual(30, numberOfRecords.Count);
        }

        [Test]
        public void GivenIncorrectIndianStatesCodeCSVFile_WhenUnmatch_ThenThrowCustomException()
        {
            StateCensusAnalyser stateCensusAnalyser = (StateCensusAnalyser)csvFactory.createCSVBuilder();
            csvData = new CSVData(stateCensusAnalyser.loadCSVDataFile);
            var result = Assert.Throws<StateCensusAnalyserException>(() => csvData(STATE_CODE_DATA_CSV_FILE_INCORRECT_PATH, INDIAN_STATE_CODE_HEADER));
            Assert.AreEqual(StateCensusAnalyserException.ExceptionType.NO_SUCH_FILE, result.type);
        }

        [Test]
        public void GivenIncorrectIndianStatesCodeCSVFileType_WhenUnmatch_ThenThrowCustomException()
        {
            StateCensusAnalyser stateCensusAnalyser = (StateCensusAnalyser)csvFactory.createCSVBuilder();
            csvData = new CSVData(stateCensusAnalyser.loadCSVDataFile);
            var result = Assert.Throws<StateCensusAnalyserException>(() => csvData(STATE_CODE_DATA_CSV_FILE_INCORRECT_TYPE, INDIAN_STATE_CODE_HEADER));
            Assert.AreEqual(StateCensusAnalyserException.ExceptionType.NO_SUCH_FILE_TYPE, result.type);
        }

        [Test]
        public void GivenIncorrectDelimiterIndianStatesCodeCSVFile_WhenUnmatch_ThenThrowCustomException()
        {
            StateCensusAnalyser stateCensusAnalyser = (StateCensusAnalyser)csvFactory.createCSVBuilder();
            csvData = new CSVData(stateCensusAnalyser.loadCSVDataFile);
            var result = Assert.Throws<StateCensusAnalyserException>(() => csvData(STATE_CODE_DATA_CSV_FILE_INCORRECT_DELIMITER, INDIAN_STATE_CODE_HEADER));
            Assert.AreEqual(StateCensusAnalyserException.ExceptionType.NO_SUCH_DELIMITER, result.type);
        }

        [Test]
        public void GivenIncorrectHeaderIndianStatesCodeCSVFile_WhenUnmatch_ThenThrowCustomException()
        {
            StateCensusAnalyser stateCensusAnalyser = (StateCensusAnalyser)csvFactory.createCSVBuilder();
            csvData = new CSVData(stateCensusAnalyser.loadCSVDataFile);
            var result = Assert.Throws<StateCensusAnalyserException>(() => csvData(STATE_CODE_DATA_CSV_FILE_INCORRECT_HEADER, INDIAN_STATE_CODE_HEADER));
            Assert.AreEqual(StateCensusAnalyserException.ExceptionType.NO_SUCH_HEADER, result.type);
        }

        [Test]
        public void GivenIndianCensusData_WhenSortedState_thenReturnSortedStartResult()
        {
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser();
           
            string sortedStateCensusData = stateCensusAnalyser.GetSortedStateWiseCensusDataInJsonFormat(STATE_CENSUS_DATA_CSV_FILE_PATH, INDIAN_CENSUS_HEADER, "state", "ASC").ToString();
            CSVStateCensus[] sortedData = JsonConvert.DeserializeObject<CSVStateCensus[]>(sortedStateCensusData);
            Assert.AreEqual("Andhra Pradesh", sortedData[0].state);
        }

        [Test]
        public void GivenIndianCensusData_WhenSortedState_thenReturnSortedLastResult()
        {
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser();
            string sortedStateCensusData = stateCensusAnalyser.GetSortedStateWiseCensusDataInJsonFormat(STATE_CENSUS_DATA_CSV_FILE_PATH, INDIAN_CENSUS_HEADER, "state",  "DESC").ToString();
            CSVStateCensus[] sortedData = JsonConvert.DeserializeObject<CSVStateCensus[]>(sortedStateCensusData);
            Assert.AreEqual("West Bengal", sortedData[^1].state);
        }

        [Test]
        public void GivenStateCodeData_WhenSortedCode_ThenReturnSortedStartResult()
        {
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser();
            string sortedStateCodeData = stateCensusAnalyser.GetSortedStateWiseCensusDataInJsonFormat(STATE_CODE_DATA_CSV_FILE_PATH, INDIAN_STATE_CODE_HEADER, "stateCode", "ASC").ToString();
            CSVStateCode[] sortedData = JsonConvert.DeserializeObject<CSVStateCode[]>(sortedStateCodeData);
            Assert.AreEqual("AD", sortedData[0].stateCode);
        }

        [Test]
        public void GivenStateCodeData_WhenSortedCode_ThenReturnSortedLastResult()
        {
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser();
            string sortedStateCodeData = stateCensusAnalyser.GetSortedStateWiseCensusDataInJsonFormat(STATE_CODE_DATA_CSV_FILE_PATH, INDIAN_STATE_CODE_HEADER, "stateCode", "DESC").ToString();
            CSVStateCode[] sortedData = JsonConvert.DeserializeObject<CSVStateCode[]>(sortedStateCodeData);
            Assert.AreEqual("WB", sortedData[^1].stateCode);
        }

        [Test]
        public void GivenStateCensusData_WhenSortedByPopulation_ThenReturnSortedMostPopulatedResult()
        {
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser();
            string sortedStateCensusData = stateCensusAnalyser.GetSortedStateWiseCensusDataInJsonFormat(STATE_CENSUS_DATA_CSV_FILE_PATH, INDIAN_CENSUS_HEADER, "population", "ASC").ToString();
            CSVStateCensus[] sortedData = JsonConvert.DeserializeObject<CSVStateCensus[]>(sortedStateCensusData);
            Assert.AreEqual("Uttar Pradesh", sortedData[0].state);
        }

        [Test]
        public void GivenStateCensusData_WhenSortedByPopulation_ThenReturnSortedLeastPopulatedResult()
        {
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser();
            string sortedStateCensusData = stateCensusAnalyser.GetSortedStateWiseCensusDataInJsonFormat(STATE_CENSUS_DATA_CSV_FILE_PATH, INDIAN_CENSUS_HEADER, "population", "DESC").ToString();
            CSVStateCensus[] sortedData = JsonConvert.DeserializeObject<CSVStateCensus[]>(sortedStateCensusData);
            Assert.AreEqual("Sikkim", sortedData[^1].state);
        }

        [Test]
        public void GivenStateCensusData_WhenSortedByPopulationDensity_ThenReturnSortedMostPopulatedDensityResult()
        {
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser();
            string sortedStateCensusData = stateCensusAnalyser.GetSortedStateWiseCensusDataInJsonFormat(STATE_CENSUS_DATA_CSV_FILE_PATH, INDIAN_CENSUS_HEADER, "populationDensity", "ASC").ToString();
            CSVStateCensus[] sortedData = JsonConvert.DeserializeObject<CSVStateCensus[]>(sortedStateCensusData);
            Assert.AreEqual("Bihar", sortedData[0].state);
        }

        [Test]
        public void GivenStateCensusData_WhenSortedByPopulationDensity_ThenReturnSortedLeastPopulatedDensityResult()
        {
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser();
            string sortedStateCensusData = stateCensusAnalyser.GetSortedStateWiseCensusDataInJsonFormat(STATE_CENSUS_DATA_CSV_FILE_PATH, INDIAN_CENSUS_HEADER, "populationDensity", "DESC").ToString();
            CSVStateCensus[] sortedData = JsonConvert.DeserializeObject<CSVStateCensus[]>(sortedStateCensusData);
            Assert.AreEqual("Mizoram", sortedData[^1].state);
        }

        [Test]
        public void GivenStateCensusData_WhenSortedByArea_ThenReturnSortedMostAreaResult()
        {
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser();
            string sortedStateCensusData = stateCensusAnalyser.GetSortedStateWiseCensusDataInJsonFormat(STATE_CENSUS_DATA_CSV_FILE_PATH, INDIAN_CENSUS_HEADER, "area", "ASC").ToString();
            CSVStateCensus[] sortedData = JsonConvert.DeserializeObject<CSVStateCensus[]>(sortedStateCensusData);
            Assert.AreEqual("Rajasthan", sortedData[0].state);
        }
        
        [Test]
        public void GivenStateCensusData_WhenSortedByArea_ThenReturnSortedLeastAreaResult()
        {
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser();
            string sortedStateCensusData = stateCensusAnalyser.GetSortedStateWiseCensusDataInJsonFormat(STATE_CENSUS_DATA_CSV_FILE_PATH, INDIAN_CENSUS_HEADER, "area", "DESC").ToString();
            CSVStateCensus[] sortedData = JsonConvert.DeserializeObject<CSVStateCensus[]>(sortedStateCensusData);
            Assert.AreEqual("Arunachal Pradesh", sortedData[^1].state);
        }

        [Test]
        public void GivenUSCensusCSVFile_WhenUnMatchNoOfRecord_ThenReturnFalse()
        {
            StateCensusAnalyser stateCensusAnalyser = (StateCensusAnalyser)csvFactory.createCSVBuilder();
            csvData = new CSVData(stateCensusAnalyser.LoadUSCSVDataFile);
            numberOfRecords = (Dictionary<string, CensusDTO>)csvData(US_CENSUS_DATA_CSV_FILE_PATH, US_CENSUS_HEADER);
            Assert.AreNotEqual(51, numberOfRecords.Count);
        }

        [Test]
        public void GivenIncorrectUSCensusCSVFile_WhenUnmatch_ThenThrowCustomException()
        {
            StateCensusAnalyser stateCensusAnalyser = (StateCensusAnalyser)csvFactory.createCSVBuilder();
            csvData = new CSVData(stateCensusAnalyser.LoadUSCSVDataFile);
            var result = Assert.Throws<StateCensusAnalyserException>(() => csvData(US_CENSUS_DATA_CSV_FILE_INCORRECT_PATH, US_CENSUS_HEADER));
            Assert.AreEqual(StateCensusAnalyserException.ExceptionType.NO_SUCH_FILE, result.type);
        }

        [Test]
        public void GivenIncorrectUSCensusCSVFileType_WhenUnmatch_ThenThrowCustomException()
        {
            StateCensusAnalyser stateCensusAnalyser = (StateCensusAnalyser)csvFactory.createCSVBuilder();
            csvData = new CSVData(stateCensusAnalyser.LoadUSCSVDataFile);
            var result = Assert.Throws<StateCensusAnalyserException>(() => csvData(US_CENSUS_DATA_CSV_INCORRECT_FILE_TYPE, US_CENSUS_HEADER));
            Assert.AreEqual(StateCensusAnalyserException.ExceptionType.NO_SUCH_FILE_TYPE, result.type);
        }
        
        [Test]
        public void GivenIncorrectDelimiterUSCensusCSVFile_WhenUnmatch_ThenThrowCustomException()
        {
            StateCensusAnalyser stateCensusAnalyser = (StateCensusAnalyser)csvFactory.createCSVBuilder();
            csvData = new CSVData(stateCensusAnalyser.LoadUSCSVDataFile);
            var result = Assert.Throws<StateCensusAnalyserException>(() => csvData(US_CENSUS_DATA_CSV_INCORRECT_DELIMITER, US_CENSUS_HEADER));
            Assert.AreEqual(StateCensusAnalyserException.ExceptionType.NO_SUCH_DELIMITER, result.type);
        }

        [Test]
        public void GivenIncorrectHeaderUSCensusCSVFile_WhenUnmatch_ThenThrowCustomException()
        {
            StateCensusAnalyser stateCensusAnalyser = (StateCensusAnalyser)csvFactory.createCSVBuilder();
            csvData = new CSVData(stateCensusAnalyser.LoadUSCSVDataFile);
            var result = Assert.Throws<StateCensusAnalyserException>(() => csvData(US_CENSUS_DATA_CSV_INCORRECT_HEADER, US_CENSUS_HEADER));
            Assert.AreEqual(StateCensusAnalyserException.ExceptionType.NO_SUCH_HEADER, result.type);
        }
    }
}