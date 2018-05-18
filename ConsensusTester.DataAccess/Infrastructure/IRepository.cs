using System;
using System.Linq;
using System.Linq.Expressions;

namespace ConsensusTester.DataAccess.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Set { get; }

        T Insert(T entity);

        T Update(T entity);

        void Delete(T entity);

        IQueryable<T> Include(params Expression<Func<T, object>>[] include);
    }
}