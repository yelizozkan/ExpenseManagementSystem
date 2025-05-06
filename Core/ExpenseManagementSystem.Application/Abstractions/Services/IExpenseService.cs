using ExpenseManagementSystem.Application.Dtos.Expense;
using ExpenseManagementSystem.Domain.Entities;


namespace ExpenseManagementSystem.Application.Abstractions.Services
{
    public interface IExpenseService
    {
        Task<ExpenseResponseDto> CreateAsync(ExpenseRequestDto model);
        Task<ExpenseResponseDto> UpdateAsync(long id, ExpenseRequestDto model);
        Task<bool> SoftDeleteAsync(long id);
        Task<ExpenseResponseDto> ApproveAsync(long expenseId, string? note);
        Task<ExpenseResponseDto> RejectAsync(long expenseId, string? rejectionNote);
    }
}
