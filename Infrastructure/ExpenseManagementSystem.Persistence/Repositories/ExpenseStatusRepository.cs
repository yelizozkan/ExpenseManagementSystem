using ExpenseManagementSystem.Application.Abstractions.Repository;
using ExpenseManagementSystem.Domain.Entities;
using ExpenseManagementSystem.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManagementSystem.Persistence.Repositories
{
    public class ExpenseStatusRepository : Repository<ExpenseStatus>, IExpenseStatusRepository
    {
        private readonly ExpenseManagementSystemDbContext _context;

        public ExpenseStatusRepository(ExpenseManagementSystemDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<long> GetStatusIdByNameAsync(string name)
        {
            return await _context.ExpenseStatuses
                .Where(x => x.Name == name)
                .Select(x => x.Id)
                .FirstOrDefaultAsync();
        }
    }
}
