using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnceDev.Training.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly NorthwindDbContext _context;
        public Repository(NorthwindDbContext context)
        {
            _context = context;
        }

        public bool Delete(T entity)
        {
            _context.Remove(entity);
            return _context.SaveChanges() > 0;
        }

        public async Task<T> FindById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public T Find(Func<T, bool> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);         
        }

        public async Task InsertAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> List()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
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
