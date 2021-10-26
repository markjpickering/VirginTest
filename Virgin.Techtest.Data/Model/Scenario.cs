using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virgin.Techtest.Domain.Model
{
    public class Scenario
    {
        public Scenario()
        {
        }

        public long ScenarioID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }        
        public string Forename { get; set; }
        
        public Guid UserID { get; set; }
        public DateTime SampleDate { get; set; }
        public DateTime CreationDate { get; set; }
        public int NumMonths { get; set; }
        public int MarketID { get; set; }
        public int NetworkLayerID { get; set; }
    };
}
