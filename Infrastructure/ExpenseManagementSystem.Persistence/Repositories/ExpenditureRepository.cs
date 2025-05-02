using ExpenseManagementSystem.Application.Abstractions.Repository;
using ExpenseManagementSystem.Domain.Entities;
using ExpenseManagementSystem.Persistence.Contexts;

namespace ExpenseManagementSystem.Persistence.Repositories
{
    public class ExpenditureRepository : Repository<Expenditure>, IExpenditureRepository
    {
        public ExpenditureRepository(ExpenseManagementSystemDbContext context) : base(context)
        {
        }
    }
}
