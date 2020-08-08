using IndianStateCensusAnalyser;
using NUnit.Framework;

namespace IndianStateCensusAnalyserTest
{
    public class Tests
    {
        private string CSV_FILE_PATH = "C:/Users/admin/source/repos/IndianStateCensusAnalyser/IndiaStateCensusData.csv";

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
    }
}