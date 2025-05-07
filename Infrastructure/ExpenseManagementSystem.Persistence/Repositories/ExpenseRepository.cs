using ExpenseManagementSystem.Application.Abstractions.Repository;
using ExpenseManagementSystem.Domain.Entities;
using ExpenseManagementSystem.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;


namespace ExpenseManagementSystem.Persistence.Repositories
{
    public class ExpenseRepository : Repository<Expense>, IExpenseRepository
    {
        private readonly ExpenseManagementSystemDbContext _context;

        public ExpenseRepository(ExpenseManagementSystemDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Expense> GetByIdWithIncludesAsync(long id, Func<IQueryable<Expense>, IQueryable<Expense>> include = null)
        {
            IQueryable<Expense> query = _context.Expenses;

            if (include != null)
                query = include(query);

            return await query.FirstOrDefaultAsync(x => x.Id == id && x.IsActive);
        }
    }
}
