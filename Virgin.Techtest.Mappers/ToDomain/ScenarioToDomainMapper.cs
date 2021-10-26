using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virgin.Techtest.Core.Interfaces;
using Virgin.Techtest.Domain.Model;

namespace Virgin.Techtest.Domain.Mappers
{
    // We could have course have used automapper and still could to implement this class
    // Since mappers are very simple, I've made the deliberate decision not to write a
    // a tests for them in this instance
    public class ScenarioToDomainMapper : IMap<Scenario, ScenarioEntity>
    {
        public ScenarioEntity Map(Scenario source) =>
            new ScenarioEntity(
                source.ScenarioID,
                source.Name,
                source.Surname,
                source.Forename,
                source.UserID,
                source.SampleDate,
                source.CreationDate,
                source.NumMonths,
                source.MarketID,
                source.NetworkLayerID);
    }
}
