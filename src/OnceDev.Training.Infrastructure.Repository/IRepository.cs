using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnceDev.Training.Infrastructure.Repository
{
    public interface IRepository<T>
    {
        void Insert(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        T Find(Func<T, bool> predicate);
        Task<IEnumerable<T>> List();
        IEnumerable<T> List(Func<T, bool> predicate);
    }
}
