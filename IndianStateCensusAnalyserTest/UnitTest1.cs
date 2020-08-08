using IndianStateCensusAnalyser;
using NUnit.Framework;

namespace IndianStateCensusAnalyserTest
{
    public class Tests
    {
        private string CSV_FILE_PATH = "C:/Users/admin/source/repos/IndianStateCensusAnalyser/IndianStateCensusAnalyserTest/resources/StateCensusData.csv";
        private string STATE_CENSUS_DATA_CSV_FILE_INCORRECT_PATH = "C:/Users/admin/source/repos/IndianStateCensusAnalyser/IndianStateCensusAnalyserTest/resources/CensusData.csv";

        StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser();

        [Test]
        public void givenIndianStatesCensusCSVFile_WhenMatchNoOfRecord_ThenReturnTrue()
        {
            int numberOfRecords = stateCensusAnalyser.loadCSVDataFile(CSV_FILE_PATH);
            Assert.AreEqual(29, numberOfRecords);
        }

        [Test]
        public void givenIndianStatesCensusCSVFile_WhenUnMatchNoOfRecord_ThenReturnFalse()
        {
            int numberOfRecords = stateCensusAnalyser.loadCSVDataFile(CSV_FILE_PATH);
            Assert.AreNotEqual(30, numberOfRecords);
        }

        [Test]
        public void givenIncorrectIndianStatesCensusCSVFile_WhenUnmatch_ThenThrowCustomException()
        {
            try
            {
                stateCensusAnalyser.loadCSVDataFile(STATE_CENSUS_DATA_CSV_FILE_INCORRECT_PATH);
            }
            catch (StateCensusAnalyserException e)
            {
                Assert.AreEqual(StateCensusAnalyserException.ExceptionType.NO_SUCH_FILE, e.type);
            }
        }
    }
}