using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virgin.Techtest.Domain.Model
{
    public record ScenarioEntity(
        long ScenarioID,
        string Name,
        string Surname,
        string Forename,
        Guid UserID,
        DateTime SampleDate,
        DateTime CreationDate,
        int NumMonths, 
        int MarketID,
        int NetworkLayerID
    );
}
