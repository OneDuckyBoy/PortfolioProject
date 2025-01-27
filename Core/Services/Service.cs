using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IRepository<T> _repository;
        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }
        public T Add(T entity)
        {
            return _repository.Add(entity);
        }

        public bool EntityExists(int id)
        {
            return _repository.EntityExists(id);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<T> GetAll()
        {
            var all = _repository.GetAll();

            return all;
        }

        public T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public T Update(T entity)
        {
            return _repository.Update(entity);
        }
    }
}
