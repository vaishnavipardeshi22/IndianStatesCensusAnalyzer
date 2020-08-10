using IndianStateCensusAnalyser;
using NUnit.Framework;

namespace IndianStateCensusAnalyserTest
{
    public class Tests
    {
        private string CSV_FILE_PATH = "C:/Users/admin/source/repos/IndianStateCensusAnalyser/IndianStateCensusAnalyserTest/resources/StateCensusData.csv";
        private string STATE_CENSUS_DATA_CSV_FILE_INCORRECT_PATH = "C:/Users/admin/source/repos/IndianStateCensusAnalyser/IndianStateCensusAnalyserTest/resources/CensusData.csv";
        private string STATE_CENSUS_DATA_CSV_INCORRECT_FILE_TYPE = "C:/Users/admin/source/repos/IndianStateCensusAnalyser/IndianStateCensusAnalyserTest/resources/StateCensusData.pdf";
        private string STATE_CENSUS_ANALYSER_CSV_INCORRECT_DELIMITER_FILE_TYPE = "C:/Users/admin/source/repos/IndianStateCensusAnalyser/IndianStateCensusAnalyserTest/resources/StateCensusDataIncorrectDelimiter.csv";
        private string STATE_CENSUS_DATA_CSV_INCORRECT_HEADER_FILE = "C:/Users/admin/source/repos/IndianStateCensusAnalyser/IndianStateCensusAnalyserTest/resources/StateCensusDataIncorrectHeader.csv";

        StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser();

        [Test]
        public void givenIndianStatesCensusCSVFile_WhenMatchNoOfRecord_ThenReturnTrue()
        {
            int numberOfRecords = stateCensusAnalyser.loadCSVCensusDataFile(CSV_FILE_PATH);
            Assert.AreEqual(29, numberOfRecords);
        }

        [Test]
        public void givenIndianStatesCensusCSVFile_WhenUnMatchNoOfRecord_ThenReturnFalse()
        {
            int numberOfRecords = stateCensusAnalyser.loadCSVCensusDataFile(CSV_FILE_PATH);
            Assert.AreNotEqual(30, numberOfRecords);
        }

        [Test]
        public void givenIncorrectIndianStatesCensusCSVFile_WhenUnmatch_ThenThrowCustomException()
        {
            try
            {
                stateCensusAnalyser.loadCSVCensusDataFile(STATE_CENSUS_DATA_CSV_FILE_INCORRECT_PATH);
            }
            catch (StateCensusAnalyserException e)
            {
                Assert.AreEqual(StateCensusAnalyserException.ExceptionType.NO_SUCH_FILE, e.type);
            }
        }

        [Test]
        public void givenIncorrectIndianStatesCensusCSVFileType_WhenUnmatch_ThenThrowCustomException()
        {
            try
            {
                stateCensusAnalyser.loadCSVCensusDataFile(STATE_CENSUS_DATA_CSV_INCORRECT_FILE_TYPE);
            }
            catch (StateCensusAnalyserException e)
            {
                Assert.AreEqual(StateCensusAnalyserException.ExceptionType.NO_SUCH_FILE_TYPE, e.type);
            }
        }

        [Test]
        public void givenIncorrectDelimiterIndianStatesCensusCSVFile_WhenUnmatch_ThenThrowCustomException()
        {
            try
            {
                stateCensusAnalyser.loadCSVCensusDataFile(STATE_CENSUS_ANALYSER_CSV_INCORRECT_DELIMITER_FILE_TYPE);
            }
            catch (StateCensusAnalyserException e)
            {
                Assert.AreEqual(StateCensusAnalyserException.ExceptionType.NO_SUCH_DELIMITER, e.type);
            }
        }

        [Test]
        public void givenIncorrectHeaderIndianStatesCensusCSVFile_WhenUnmatch_ThenThrowCustomException()
        {
            try
            {
                stateCensusAnalyser.loadCSVCensusDataFile(STATE_CENSUS_DATA_CSV_INCORRECT_HEADER_FILE);
            }
            catch (StateCensusAnalyserException e)
            {
                Assert.AreEqual(StateCensusAnalyserException.ExceptionType.NO_SUCH_HEADER, e.type);
            }
        }

    }
}