using ExpenseManagementSystem.Application.Dtos.Expense;
using ExpenseManagementSystem.Domain.Entities;


namespace ExpenseManagementSystem.Application.Abstractions.Services
{
    public interface IExpenseService
    {
        Task<Expense> CreateAsync(ExpenseRequestDto model);
        Task<Expense> UpdateAsync(long id, ExpenseRequestDto model);
        Task<bool> DeleteAsync(long id);

    }
}
