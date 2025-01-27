using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IService<T> where T : class
    {
        T Add(T entity);
        void Delete(int id);
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Update(T entity);
        bool EntityExists(int id);
    }
}
