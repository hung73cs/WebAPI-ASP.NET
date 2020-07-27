using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAngularNETCORE.Models.Repository
{
    public interface IDeleteDataRepository<TEntity>
    {
        TEntity Get(long id);
        void Delete(Employee employee);
    }
}
