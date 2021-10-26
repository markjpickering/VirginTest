using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Virgin.Techtest.Domain.Model
{
    [XmlRoot(ElementName="Data" )]
    public class ScenarioDataFile
    {
        public ScenarioDataFile()
        {
        }

        [XmlElement(typeof(Scenario), ElementName= "Scenario")]
        public Scenario[] Scenario { get; set; }
    };
}
