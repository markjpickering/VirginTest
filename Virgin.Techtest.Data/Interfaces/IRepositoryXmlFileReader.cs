using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virgin.Techtest.Data.Interfaces
{
    public interface IRepositoryXmlFileReader<TDataEntity> : IRepositoryReader<TDataEntity>
        where TDataEntity : class
    {
        string FullFilePathAndName { get; set; }
    }
}
