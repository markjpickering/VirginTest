using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virgin.Techtest.Data.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
         IReadOnlyList<TEntity> GetAll();
    }
}
