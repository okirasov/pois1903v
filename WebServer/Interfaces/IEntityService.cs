using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServer.Interfaces
{
    public interface IEntityService<T>
    {
        List<T> Get();
        T Get(int id);
        bool Delete(int id);
        bool Create(T entity);
        bool Update(int id, T entity);
    }
}
