using ExpenseManagementSystem.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;


namespace ExpenseManagementSystem.Application.Abstractions.Repository
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        DbSet<TEntity> Table { get; }

        Task<TEntity> GetByIdAsync(long id, bool tracking = true);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);

        Task<IEnumerable<TEntity>> GetAllAsync(bool tracking = true);

        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate, bool tracking = true);

        Task<bool> AddAsync(TEntity entity);

        Task AddRangeAsync(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void Remove(TEntity entity);

        Task<bool> DeleteByIdAsync(long id);

        Task<TEntity> GetSingleAsync(
        Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
        bool tracking = true);
    }
}
