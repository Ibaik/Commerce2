using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepository
{
   public interface IRepository<TEntity>
    {

        Task<TEntity> FindAsync(object id);

        TEntity Find(object id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        IQueryable<TEntity> GetAllQuerable();

        int Count();

        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);

        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> predicate);

        Task<int> AddAsync(TEntity entity);

        int Add(TEntity entity);

        Task<int> AddAndLogAsync(TEntity entity, string userId);

        Task<int> AddRangeAsync(IEnumerable<TEntity> entities);

        Task<int> AddRangeAndLogAsync(IEnumerable<TEntity> entities, string userId);

        Task<int> UpdateAsync(TEntity entity);

        Task<int> UpdateAndLogAsync(TEntity entity, string userId);

        Task<int> UpdateRangeAsync(IEnumerable<TEntity> entity);

        Task<int> UpdateRangeAndLogAsync(IEnumerable<TEntity> entities, string userId);

        Task<int> RemoveAsync(TEntity entity);

        Task<int> RemoveAndLogAsync(TEntity entity, string userId);

        Task<int> RemoveRangeAsync(IEnumerable<TEntity> entities);

        Task<int> RemoveRangeAndLogAsync(IEnumerable<TEntity> entities, string userId);
    }
}
