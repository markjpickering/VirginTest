using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virgin.Techtest.Data.Interfaces;
using Virgin.Techtest.Data.RepositoryReaders;
using Virgin.Techtest.Domain.Model;

namespace Virgin.Techtest.Data.UnitTests.RepositoryReaders.ScenarioRepositoryReaderTests
{
    public class ReadAll
    {
        private ScenarioRepositoryXmlFileReader _sut;
        private MockFileSystem _fileSystem;

        [SetUp]
        public void Setup()
        {
            _fileSystem = new MockFileSystem(new Dictionary<string, MockFileData>());
            _sut = new ScenarioRepositoryXmlFileReader(_fileSystem);
        }

        ///TODO Add tests for edge conditions such as missing or invalid Xml file

        [Test]
        public void WhenFileHasOneRecord_ReturnOneRecord()
        {
            // Arrange
            _sut.FullFilePathAndName = @"c:\testdata.xml";

            _fileSystem.AddFile(@"c:\testdata.xml", new MockFileData(
             @"<?xml version=""1.0"" encoding=""utf - 8""?>
                <Data>
                    <Scenario>
                        <ScenarioID>4</ScenarioID>
                      <Name>Scenario</Name>
                      <Surname>BALDWIN</Surname>
                      <Forename>EDWARD</Forename>
                      <UserID>6F55DFD1-A235-4BAE-B958-C1A0AB4D5236</UserID>
                      <SampleDate>2013-02-01T06:02:00</SampleDate>
                      <CreationDate>2013-02-01T13:00:00</CreationDate>
                      <NumMonths>12</NumMonths>
                      <MarketID>2</MarketID>
                      <NetworkLayerID>1</NetworkLayerID>
                    </Scenario>
                </Data>
            "));

            // Act
            var results = _sut.ReadAll()?.ToList();

            // Assert
            results.Should().NotBeNull();
            results.Should().HaveCount(1);

            var rec = results.First();

            rec.ScenarioID.Should().Be(4);
            rec.Name.Should().Be("Scenario");
            rec.Surname.Should().Be("BALDWIN");
            rec.Forename.Should().Be("EDWARD");
            rec.UserID.Should().Be(new Guid("6F55DFD1-A235-4BAE-B958-C1A0AB4D5236"));
            rec.SampleDate.Should().Be(DateTime.Parse("2013-02-01T06:02:00"));
            rec.CreationDate.Should().Be(DateTime.Parse("2013-02-01T13:00:00")); ;
            rec.NumMonths.Should().Be(12);
            rec.MarketID.Should().Be(2);
            rec.NetworkLayerID.Should().Be(1);
        }

        [Test]
        public void WhenFileHasTwoRecords_ReturnsTwoRecords()
        {
            // Arrange
            _sut.FullFilePathAndName = @"c:\testdata.xml";

            _fileSystem.AddFile(@"c:\testdata.xml", new MockFileData(
             @" <Data>
                    <Scenario>
                       <ScenarioID>4</ScenarioID>
                      <Name>Scenario4</Name>
                      <Surname>BALDWIN</Surname>
                      <Forename>EDWARD</Forename>
                      <UserID>6F55DFD1-A235-4BAE-B958-C1A0AB4D5236</UserID>
                      <SampleDate>2013-02-01T06:02:00</SampleDate>
                      <CreationDate>2013-02-01T13:00:00</CreationDate>
                      <NumMonths>12</NumMonths>
                      <MarketID>2</MarketID>
                      <NetworkLayerID>1</NetworkLayerID>
                    </Scenario>
                    <Scenario>
                        <ScenarioID>8</ScenarioID>
                        <Name>Scenario8</Name>
                        <Surname>BALDWIN</Surname>
                        <Forename>EDWARD</Forename>
                        <UserID>6F55DFD1-A235-4BAE-B958-C1A0AB4D5236</UserID>
                        <SampleDate>2013-02-01T06:02:00</SampleDate>
                        <CreationDate>2013-02-01T13:00:00</CreationDate>
                        <NumMonths>12</NumMonths>
                        <MarketID>2</MarketID>
                        <NetworkLayerID>1</NetworkLayerID>
                    </Scenario>
                </Data>
            "));

            // Act
            var results = _sut.ReadAll()?.ToList();

            // Assert
            results.Should().NotBeNull();
            results.Should().HaveCount(2);

            results.Should().BeEquivalentTo(
                new List<Scenario>()
                {
                    new Scenario()
                    {
                        ScenarioID = 4,
                        Name = "Scenario4",
                        Forename = "EDWARD",
                        Surname = "BALDWIN",
                        UserID = new Guid("6F55DFD1-A235-4BAE-B958-C1A0AB4D5236"),
                        SampleDate = DateTime.Parse("2013-02-01T06:02:00"),
                        CreationDate = DateTime.Parse("2013-02-01T13:00:00"),
                        NumMonths = 12,
                        MarketID = 2,
                        NetworkLayerID = 1
                    },
                    new Scenario()
                    {
                        ScenarioID = 8,
                        Name = "Scenario8",
                        Forename = "EDWARD",
                        Surname = "BALDWIN",
                        UserID = new Guid("6F55DFD1-A235-4BAE-B958-C1A0AB4D5236"),
                        SampleDate = DateTime.Parse("2013-02-01T06:02:00"),
                        CreationDate = DateTime.Parse("2013-02-01T13:00:00"),
                        NumMonths = 12,
                        MarketID = 2,
                        NetworkLayerID = 1
                    }
                });         
        }
    }
}
