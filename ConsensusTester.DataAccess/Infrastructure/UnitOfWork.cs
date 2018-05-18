using System;
using System.Collections.Generic;

namespace ConsensusTester.DataAccess.Infrastructure
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly ConsensusContext _dbContext;
        private bool _disposed;
        private Dictionary<string, object> _repositories;

        public UnitOfWork(ConsensusContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepository<T> Repository<T>()
            where T : class
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<string, object>();
            }

            var type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _dbContext);
                _repositories.Add(type, repositoryInstance);
            }
            return (Repository<T>)_repositories[type];
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }
    }
}