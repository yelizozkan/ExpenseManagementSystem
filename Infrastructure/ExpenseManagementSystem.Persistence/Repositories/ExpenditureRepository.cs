using ExpenseManagementSystem.Application.Abstractions.Repository;
using ExpenseManagementSystem.Domain.Entities;
using ExpenseManagementSystem.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManagementSystem.Persistence.Repositories
{
    public class ExpenditureRepository : Repository<Expenditure>, IExpenditureRepository
    {
        private readonly ExpenseManagementSystemDbContext _context;
        public ExpenditureRepository(ExpenseManagementSystemDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Expenditure> GetByIdWithExpenseAndUserAsync(long id)
        {
            return await _context.Expenditures
               .Include(e => e.Status) 
               .Include(e => e.Expense)
               .ThenInclude(e => e.Status)
               .Include(e => e.Expense)
               .ThenInclude(e => e.User)
               .FirstOrDefaultAsync(e => e.Id == id);
        }

    }
}
