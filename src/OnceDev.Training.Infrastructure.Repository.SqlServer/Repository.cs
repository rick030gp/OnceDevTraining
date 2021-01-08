using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnceDev.Training.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly NorthwindDbContext _context;
        public Repository(NorthwindDbContext context)
        {
            _context = context;
        }

        public bool Delete(T entity)
        {
            _context.Remove(entity);
            return _context.SaveChanges() > 0;
        }

        public T Find(Func<T, bool> predicate)
        {
            return _context.Set<T>().AsNoTracking().FirstOrDefault(predicate);
        }

        public void Insert(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();            
        }

        public IEnumerable<T> List()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public IEnumerable<T> List(Func<T, bool> predicate)
        {
            return _context.Set<T>().AsNoTracking().Where(predicate);
        }

        public bool Update(T entity)
        {
            _context.Update(entity);
            return _context.SaveChanges() > 0;
        }
    }
}
