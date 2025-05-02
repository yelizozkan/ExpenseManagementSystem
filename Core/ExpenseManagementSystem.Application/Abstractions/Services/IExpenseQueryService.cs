using ExpenseManagementSystem.Application.Dtos.Expense;


namespace ExpenseManagementSystem.Application.Abstractions.Services
{
    public interface IExpenseQueryService
    {
        Task<List<ExpenseResponseDto>> GetAllAsync();
        Task<ExpenseResponseDto?> GetByIdAsync(long id);
    }
}
