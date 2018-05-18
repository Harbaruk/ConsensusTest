using System;

namespace ConsensusTester.DataAccess.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>()
            where T : class;

        void SaveChanges();
    }
}