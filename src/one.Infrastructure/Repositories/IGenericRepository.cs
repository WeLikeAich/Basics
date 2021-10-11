using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace one.Infrastructure.Repositories
{
    public interface IGenericRepository<TEntity, TKey>
    {
        Task<TEntity> GetByIdAsync(TKey id);

        Task InsertAsync(TEntity entity);

        Task InsertManyAsync(IEnumerable<TEntity> entities);

        Task DeleteByIdAsync(TKey id);

        void Delete(TEntity entityToDelete);

        void Update(TEntity entityToUpdate);
    }
}