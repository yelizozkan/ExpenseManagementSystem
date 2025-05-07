using ExpenseManagementSystem.Domain.Entities;


namespace ExpenseManagementSystem.Application.Abstractions.Repository
{
    public interface IExpenseRepository : IRepository<Expense>
    {
        Task<Expense> GetByIdWithIncludesAsync(long id, Func<IQueryable<Expense>, IQueryable<Expense>> include = null);
    }
}
