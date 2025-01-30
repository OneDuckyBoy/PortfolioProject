﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Models.Models;

namespace Core.Repositories
{
    public interface IRoleRepository<T> where T : IdentityRole<int>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Add(T entity);
        T Update(T entity);
        void Delete(int id);
        bool EntityExists(int id);
    }
}
