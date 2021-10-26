using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virgin.Techtest.Core.Interfaces;
using Virgin.Techtest.Data.Interfaces;
using Virgin.Techtest.Domain.Model;

namespace Virgin.Techtest.Data.Repositories
{
    // The datalayer should not be referencing domain entity classes, so some refactoring is needed!!
    public class ScenarioXmlRepository : RepositoryFromXmlFileBase<Scenario, ScenarioEntity>,  IScenarioRepository
    {
        public ScenarioXmlRepository(IRepositoryXmlFileReader<Scenario> reader, IMap<Scenario, ScenarioEntity> mapper)
            : base(reader, mapper)        
        {             
        }
    }
}
