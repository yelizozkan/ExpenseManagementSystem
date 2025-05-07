using ExpenseManagementSystem.Domain.Entities;


namespace ExpenseManagementSystem.Application.Abstractions.Repository
{
    public interface IExpenseStatusRepository : IRepository<ExpenseStatus>
    {
        Task<long> GetStatusIdByNameAsync(string name);
    }

}
