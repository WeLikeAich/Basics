using one.Domain;
using one.Infrastructure.Repositories;
using System;
using System.Threading.Tasks;

namespace one.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : Entity<TKey>;

        bool RemoveRepository<TEntity, TKey>() where TEntity : Entity<TKey>;

        void Save();

        Task SaveAsync();
    }
}