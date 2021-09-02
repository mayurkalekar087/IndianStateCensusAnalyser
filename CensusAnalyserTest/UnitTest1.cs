using NUnit.Framework;
using IndianStateCensusAnalyser;
using IndianStateCensusAnalyser.POCO;
using Newtonsoft.Json;
//using static IndianStateCensusAnalyser.CensusAnalyser;
using System.Collections.Generic;

namespace CensusAnalyserTest
{
    public class Tests
    {
        static string indianStateCensusHeaders = "state,population,area,density";
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        //CorrectFilePaths
        static string indianStateCensusFilePath = @"C:\Users\ASUS\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CSVFiles\IndiaStateCensusData.csv";
        static string indianStateCodeFilePath = @"C:\Users\ASUS\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CSVFiles\IndiaStateCode.csv";
        //WrongFilePaths
        static string wrongIndianStateCodeFilePath = "";
        static string wrongIndianStateCensusFilePath = "";
        //WrongFiles
        static string wrongHeaderIndianStateCodeFile = @"C:\Users\ASUS\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CSVFiles\WrongIndiaStateCode.csv";
        static string wrongHeaderIndianStateCensusFile = @"C:\Users\ASUS\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CSVFiles\WrongIndiaStateCensusData.csv";
        static string wrongIndianStateCodeFileType = @"C:\Users\ASUS\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CSVFiles\IndianStateCode.txt";
        static string wrongIndianStateCensusFileType = @"C:\Users\ASUS\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CSVFiles\IndiaStateCensusData.txt";
        //WrongDelimiter
        static string wrongDelimiterIndianCensusFilePath = @"C:\Users\ASUS\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CSVFiles\DelimiterIndiaStateCensusData.csv";
        static string wrongDelimiterIndianStateCodeFilePath = @"C:\Users\ASUS\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CSVFiles\DelimiterIndiaStateCode.csv";

         IndianStateCensusAnalyser.CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new IndianStateCensusAnalyser.CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }
        //count
        //TC 1.1
        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData( CensusAnalyser.Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            Assert.AreEqual(9, totalRecord.Count);
        }
        //Wrong File Path
        //Tc 1.2
        [Test]
        public void GivenWrongIndianCensusCodeFilePath_WhenRead_ShouldReturn_FILE_NOT_FOUND()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
        }
        //WrongFileType
        //TC 1.3
        [Test]
        public void GivenWrongIndianStateCensusFileType_WhenReaded_ShouldReturnINVALID_FILE_TYPE()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFileType, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }
        //FileWithWrongDelimeter
        //TC 1.4
        [Test]
        public void GivenWrongIndianCensusDelimiter_WhenReaded_ShouldReturnINCORRECT_DELIMITER()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongDelimiterIndianCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
        }
        //WrongHeader
        //TC 1.5
        [Test]
        public void GivenWrongIndianCensusDataFilePath_WhenReaded_ShouldReturnINCORRECT_HEADER()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongHeaderIndianStateCensusFile, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
        }
    }
}