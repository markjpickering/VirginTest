using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virgin.Techtest.Core.Interfaces;
using Virgin.Techtest.Data.Interfaces;
using Virgin.Techtest.Data.Repositories;
using Virgin.Techtest.Domain.Model;

namespace Virgin.Techtest.Data.UnitTests.Repositories.ScenarioXmlRepositoryTests
{
    public class GetAll
    {
        private IScenarioRepository _sut;
        private Mock<IRepositoryXmlFileReader<Scenario>> _reader;
        private Mock<IMap<Scenario, ScenarioEntity>> _mapper;

        [SetUp]
        public void Setup()
        {
            _reader = new Mock<IRepositoryXmlFileReader<Scenario>>();
            _mapper = new Mock<IMap<Scenario, ScenarioEntity>>();
            _mapper.Setup(o => o.Map(It.IsAny<Scenario>())).Returns((Scenario scenario) => GetEntityRecord((short)scenario?.ScenarioID));
 
            _sut = new ScenarioXmlRepository(_reader.Object, _mapper.Object);
        }

        private ScenarioEntity GetEntityRecord(short id) =>
            new ScenarioEntity(            
               id,
               $"{id}_Name",
               $"{id}_Surname",
               $"{id}_Forename",
               new Guid(id, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
               DateTime.MinValue.AddDays(id),
               DateTime.MaxValue.AddDays(0 - id),
               id + 1000,
               id + 2000,
               id + 3000
           );

        private Scenario GetDataRecord(short id) =>
           new Scenario()
           {
               ScenarioID = id,
               Name = $"{id}_Name",
               Surname = $"{id}_Surname",
               Forename = $"{id}_Forename",
               UserID = new Guid(id, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
               SampleDate = DateTime.MinValue.AddDays(id),
               CreationDate = DateTime.MaxValue.AddDays(0 - id),
               NumMonths = id + 1000,
               MarketID = id + 2000,
               NetworkLayerID = id + 3000
           };

        [Test]
        public void WhenRepositoryEmpty_ReturnEmptyList()
        {
            // Arrange
            _reader.Setup(o => o.ReadAll()).Returns(new List<Scenario> { });
            _mapper.Setup(o => o.Map(It.IsAny<Scenario>())).Returns(GetEntityRecord(1));

            // Act
            var results = _sut.GetAll();

            // Assert
            results.Should().NotBeNull();
            results.Should().BeEmpty();
        }

        [Test]
        public void WhenRepositoryContainsOneEntry_ReturnOneEntry()
        {
            // Arrange
            _reader.Setup(o => o.ReadAll()).Returns(new List<Scenario> { GetDataRecord(5) });

            // Act
            var results = _sut.GetAll();

            // Assert
            results.Should().NotBeNull();
            results.Should().HaveCount(1);
            results.First().ScenarioID.Should().Be(5);
        }

        [Test]
        public void WhenRepositoryContainsOneEntry_ReturnTwoEntries()
        {
            // Arrange
            _reader.Setup(o => o.ReadAll()).Returns(
                new List<Scenario> { GetDataRecord(5), GetDataRecord(10) });

            // Act
            var results = _sut.GetAll();

            // Assert
            results.Should().NotBeNull();
            results.Should().HaveCount(2);
            results.Where(x => x.ScenarioID == 5).Should().HaveCount(1);
            results.Where(x => x.ScenarioID == 10).Should().HaveCount(1);
        }
    }
}
