using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virgin.Techtest.Data.Interfaces
{
    public interface IRepositoryReader<TEntity>
        where TEntity : class
    {
        public IReadOnlyList<TEntity> ReadAll();
    }
}
