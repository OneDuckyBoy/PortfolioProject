using Core.Repositories;
using Microsoft.AspNetCore.Identity;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class RoleService<T> : IRoleService<T> where T :IdentityRole<int>
    {
        private readonly IRoleRepository<T> _repository;
        public RoleService(IRoleRepository<T> repository)
        {
            _repository = repository;
        }
        public T Add(T entity)
        {
            return _repository.Add(entity);
        }

        public bool EntityExists(int id)
        {
            bool boo = _repository.EntityExists(id);
            return boo;
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
