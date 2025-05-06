using ExpenseManagementSystem.Domain.Entities;


namespace ExpenseManagementSystem.Application.Abstractions.Repository
{
    public interface IExpenditureRepository : IRepository<Expenditure>
    {
        Task<Expenditure?> GetByIdWithExpenseAndUserAsync(long id);
    }
}
