using IndianStateCensusAnalyser;
using NUnit.Framework;
using System.Collections.Generic;
using static IndianStateCensusAnalyser.StateCensusAnalyser;

namespace IndianStateCensusAnalyserTest
{
    public class Tests
    {
        private string CSV_FILE_PATH = "C:/Users/admin/source/repos/IndianStateCensusAnalyser/IndianStateCensusAnalyserTest/resources/StateCensusData.csv";
        private string STATE_CENSUS_DATA_CSV_FILE_INCORRECT_PATH = "C:/Users/admin/source/repos/IndianStateCensusAnalyser/IndianStateCensusAnalyserTest/resources/CensusData.csv";
        private string STATE_CENSUS_DATA_CSV_INCORRECT_FILE_TYPE = "C:/Users/admin/source/repos/IndianStateCensusAnalyser/IndianStateCensusAnalyserTest/resources/StateCensusData.txt";
        private string STATE_CENSUS_ANALYSER_CSV_INCORRECT_DELIMITER_FILE_TYPE = "C:/Users/admin/source/repos/IndianStateCensusAnalyser/IndianStateCensusAnalyserTest/resources/StateCensusDataIncorrectDelimiter.csv";
        private string STATE_CENSUS_DATA_CSV_INCORRECT_HEADER_FILE = "C:/Users/admin/source/repos/IndianStateCensusAnalyser/IndianStateCensusAnalyserTest/resources/StateCensusDataIncorrectHeader.csv";

        private string STATE_CODE_DATA_CSV_FILE_PATH = "C:/Users/admin/source/repos/IndianStateCensusAnalyser/IndianStateCensusAnalyserTest/resources/StateCode.csv";
        private string STATE_CODE_DATA_CSV_FILE_INCORRECT_PATH = "C:/Users/admin/source/repos/IndianStateCensusAnalyser/IndianStateCensusAnalyserTest/resources/StatesCode.csv";
        private string STATE_CODE_DATA_CSV_FILE_INCORRECT_TYPE = "C:/Users/admin/source/repos/IndianStateCensusAnalyser/IndianStateCensusAnalyserTest/resources/StateCode.txt";
        private string STATE_CODE_DATA_CSV_FILE_INCORRECT_DELIMITER = "C:/Users/admin/source/repos/IndianStateCensusAnalyser/IndianStateCensusAnalyserTest/resources/StateCodeIncorrectDelimiter.csv";
        private string STATE_CODE_DATA_CSV_FILE_INCORRECT_HEADER = "C:/Users/admin/source/repos/IndianStateCensusAnalyser/IndianStateCensusAnalyserTest/resources/StateCodeIncorrectHeader.csv";

        private string INDIAN_CENSUS_HEADER = "State,Population,AreaInSqKm,DensityPerSqKm";
        private string INDIAN_STATE_CODE_HEADER = "SrNo,StateName,TIN,StateCode";

        CSVBuilderFactory csvFactory = new CSVBuilderFactory();
        List<string> numberOfRecords = new List<string>();
        CSVData csvData;

        [Test]
        public void givenIndianStatesCensusCSVFile_WhenMatchNoOfRecord_ThenReturnTrue()
        {
            StateCensusAnalyser stateCensusAnalyser = (StateCensusAnalyser)csvFactory.createCSVBuilder();
            csvData = new CSVData(stateCensusAnalyser.loadCSVDataFile);
            numberOfRecords = (List<string>)csvData(CSV_FILE_PATH, INDIAN_CENSUS_HEADER);
            Assert.AreEqual(29, numberOfRecords.Count);
        }

        [Test]
        public void givenIndianStatesCensusCSVFile_WhenUnMatchNoOfRecord_ThenReturnFalse()
        {
            StateCensusAnalyser stateCensusAnalyser = (StateCensusAnalyser)csvFactory.createCSVBuilder();
            csvData = new CSVData(stateCensusAnalyser.loadCSVDataFile);
            numberOfRecords = (List<string>)csvData(CSV_FILE_PATH, INDIAN_CENSUS_HEADER);
            Assert.AreNotEqual(30, numberOfRecords.Count);
        }

        [Test]
        public void givenIncorrectIndianStatesCensusCSVFile_WhenUnmatch_ThenThrowCustomException()
        {
            StateCensusAnalyser stateCensusAnalyser = (StateCensusAnalyser)csvFactory.createCSVBuilder();
            csvData = new CSVData(stateCensusAnalyser.loadCSVDataFile);
            var result = Assert.Throws<StateCensusAnalyserException>(() => csvData(STATE_CENSUS_DATA_CSV_FILE_INCORRECT_PATH, INDIAN_CENSUS_HEADER));
            Assert.AreEqual(StateCensusAnalyserException.ExceptionType.NO_SUCH_FILE, result.type);
        }

        [Test]
        public void givenIncorrectIndianStatesCensusCSVFileType_WhenUnmatch_ThenThrowCustomException()
        {
            StateCensusAnalyser stateCensusAnalyser = (StateCensusAnalyser)csvFactory.createCSVBuilder();
            csvData = new CSVData(stateCensusAnalyser.loadCSVDataFile);
            var result = Assert.Throws<StateCensusAnalyserException>(() => csvData(STATE_CENSUS_DATA_CSV_INCORRECT_FILE_TYPE, INDIAN_CENSUS_HEADER));
            Assert.AreEqual(StateCensusAnalyserException.ExceptionType.NO_SUCH_FILE_TYPE, result.type);
        }

        [Test]
        public void givenIncorrectDelimiterIndianStatesCensusCSVFile_WhenUnmatch_ThenThrowCustomException()
        {
            StateCensusAnalyser stateCensusAnalyser = (StateCensusAnalyser)csvFactory.createCSVBuilder();
            csvData = new CSVData(stateCensusAnalyser.loadCSVDataFile);
            var result = Assert.Throws<StateCensusAnalyserException>(() => csvData(STATE_CENSUS_ANALYSER_CSV_INCORRECT_DELIMITER_FILE_TYPE, INDIAN_CENSUS_HEADER));
            Assert.AreEqual(StateCensusAnalyserException.ExceptionType.NO_SUCH_DELIMITER, result.type);
        }

        [Test]
        public void givenIncorrectHeaderIndianStatesCensusCSVFile_WhenUnmatch_ThenThrowCustomException()
        {
            StateCensusAnalyser stateCensusAnalyser = (StateCensusAnalyser)csvFactory.createCSVBuilder();
            csvData = new CSVData(stateCensusAnalyser.loadCSVDataFile);
            var result = Assert.Throws<StateCensusAnalyserException>(() => csvData(STATE_CENSUS_DATA_CSV_INCORRECT_HEADER_FILE, INDIAN_CENSUS_HEADER));
            Assert.AreEqual(StateCensusAnalyserException.ExceptionType.NO_SUCH_HEADER, result.type);
        }

        [Test]
        public void givenIndianStatesCodeCSVFile_WhenMatchNoOfRecord_ThenReturnTrue()
        {
            StateCensusAnalyser stateCensusAnalyser = (StateCensusAnalyser)csvFactory.createCSVBuilder();
            csvData = new CSVData(stateCensusAnalyser.loadCSVDataFile);
            numberOfRecords = (List<string>)csvData(STATE_CODE_DATA_CSV_FILE_PATH, INDIAN_STATE_CODE_HEADER);
            Assert.AreEqual(37, numberOfRecords.Count);
        }

        [Test]
        public void givenIndianStatesCodeCSVFile_WhenUnMatchNoOfRecord_ThenReturnTrue()
        {
            StateCensusAnalyser stateCensusAnalyser = (StateCensusAnalyser)csvFactory.createCSVBuilder();
            csvData = new CSVData(stateCensusAnalyser.loadCSVDataFile);
            numberOfRecords = (List<string>)csvData(STATE_CODE_DATA_CSV_FILE_PATH, INDIAN_STATE_CODE_HEADER);
            Assert.AreNotEqual(30, numberOfRecords.Count);
        }

        [Test]
        public void givenIncorrectIndianStatesCodeCSVFile_WhenUnmatch_ThenThrowCustomException()
        {
            StateCensusAnalyser stateCensusAnalyser = (StateCensusAnalyser)csvFactory.createCSVBuilder();
            csvData = new CSVData(stateCensusAnalyser.loadCSVDataFile);
            var result = Assert.Throws<StateCensusAnalyserException>(() => csvData(STATE_CODE_DATA_CSV_FILE_INCORRECT_PATH, INDIAN_STATE_CODE_HEADER));
            Assert.AreEqual(StateCensusAnalyserException.ExceptionType.NO_SUCH_FILE, result.type);
        }

        [Test]
        public void givenIncorrectIndianStatesCodeCSVFileType_WhenUnmatch_ThenThrowCustomException()
        {
            StateCensusAnalyser stateCensusAnalyser = (StateCensusAnalyser)csvFactory.createCSVBuilder();
            csvData = new CSVData(stateCensusAnalyser.loadCSVDataFile);
            var result = Assert.Throws<StateCensusAnalyserException>(() => csvData(STATE_CODE_DATA_CSV_FILE_INCORRECT_TYPE, INDIAN_STATE_CODE_HEADER));
            Assert.AreEqual(StateCensusAnalyserException.ExceptionType.NO_SUCH_FILE_TYPE, result.type);
        }

        [Test]
        public void givenIncorrectDelimiterIndianStatesCodeCSVFile_WhenUnmatch_ThenThrowCustomException()
        {
            StateCensusAnalyser stateCensusAnalyser = (StateCensusAnalyser)csvFactory.createCSVBuilder();
            csvData = new CSVData(stateCensusAnalyser.loadCSVDataFile);
            var result = Assert.Throws<StateCensusAnalyserException>(() => csvData(STATE_CODE_DATA_CSV_FILE_INCORRECT_DELIMITER, INDIAN_STATE_CODE_HEADER));
            Assert.AreEqual(StateCensusAnalyserException.ExceptionType.NO_SUCH_DELIMITER, result.type);
        }

        [Test]
        public void givenIncorrectHeaderIndianStatesCodeCSVFile_WhenUnmatch_ThenThrowCustomException()
        {
            StateCensusAnalyser stateCensusAnalyser = (StateCensusAnalyser)csvFactory.createCSVBuilder();
            csvData = new CSVData(stateCensusAnalyser.loadCSVDataFile);
            var result = Assert.Throws<StateCensusAnalyserException>(() => csvData(STATE_CODE_DATA_CSV_FILE_INCORRECT_HEADER, INDIAN_STATE_CODE_HEADER));
            Assert.AreEqual(StateCensusAnalyserException.ExceptionType.NO_SUCH_HEADER, result.type);
        }
    }
}