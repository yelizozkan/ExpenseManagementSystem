using ExpenseManagementSystem.Application.Abstractions.Repository;
using ExpenseManagementSystem.Domain.Entities;
using ExpenseManagementSystem.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManagementSystem.Persistence.Repositories
{
    public class ExpenseStatusRepository : Repository<ExpenseStatus>, IExpenseStatusRepository
    {
        public ExpenseStatusRepository(ExpenseManagementSystemDbContext context) : base(context)
        {
        }

        public async Task<ExpenseStatus> GetByNameAsync(string name)
        {
            return await Table.FirstOrDefaultAsync(x => x.Name == name && x.IsActive);
        }
    }
}
