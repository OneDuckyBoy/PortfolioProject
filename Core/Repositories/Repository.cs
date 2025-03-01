using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Models.Models;
using Portfolio.Data;
using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }
        public T Add(T entity)
        {
            T t = _context.Set<T>().Add(entity).Entity;
            _context.SaveChanges();
            return t;
        }

        public void Delete(int id)
        {
            T entity = GetById(id);
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);

        }

        public T Update( T entity)
        {
            T entity1 = _context.Set<T>().Update(entity).Entity;
            _context.SaveChanges();
            return entity1;
        }
        public bool EntityExists(int id)
        {
            return _context.Set<T>().Find(id) != null;
        }
        public void Detach(T entity)
        {
            var entry = _context.Entry(entity);
            if (entry != null)
            {
                entry.State = EntityState.Detached;
            }
        }
        public void DeleteFromLikedComments(int commentId, int userId)
        {
            var commentsQuery = _context.LikedComments.Where(c => c.CommentId == commentId && c.UserId == userId);
            if (!commentsQuery.ToList().IsNullOrEmpty())
            {
                var comment = commentsQuery.ToList()[0];

                _context.LikedComments.Remove(comment);
                _context.SaveChanges();
            }
            
        }
    }
}
