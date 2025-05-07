using ExpenseManagementSystem.Application.Abstractions.Repository;
using ExpenseManagementSystem.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ExpenseManagementSystem.Persistence.Contexts;
using Microsoft.EntityFrameworkCore.Query;

namespace ExpenseManagementSystem.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ExpenseManagementSystemDbContext _context;

        public DbSet<TEntity> Table => _context.Set<TEntity>();

        public Repository(ExpenseManagementSystemDbContext context)
        {
            _context = context;
        }

        public async Task<TEntity> GetByIdAsync(long id, bool tracking = true)
        {
            var query = Table.AsQueryable();

            if (!tracking)
                query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync(data => data.Id == id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            return await query.ToListAsync();
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate, bool tracking = true)
        {
            var query = Table.AsQueryable();

            if (!tracking)
                query = query.AsNoTracking();

            return query.Where(predicate);
        }

        public async Task AddAsync(TEntity entity)
        {
            await Table.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await Table.AddRangeAsync(entities);
        }

        public void Update(TEntity entity)
        {
            Table.Update(entity);
        }

        public void Remove(TEntity entity)
        {
            Table.Remove(entity);
        }

        public async Task<bool> DeleteByIdAsync(long id)
        {
            var entity = await Table.FindAsync(id);

            if (entity == null)
            {
                return false;
            }

            Table.Remove(entity);
            return true;
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Table.AnyAsync(predicate);
        }


        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity,
            bool>> predicate,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool tracking = true)
        {
            IQueryable<TEntity> query = Table.AsQueryable();

            if (!tracking)
                query = query.AsNoTracking();

            if (include != null)
                query = include(query);

            return await query.FirstOrDefaultAsync(predicate);
        }
    }
}
