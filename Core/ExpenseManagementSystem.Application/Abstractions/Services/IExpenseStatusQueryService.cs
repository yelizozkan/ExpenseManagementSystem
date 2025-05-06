using ExpenseManagementSystem.Application.Dtos.ExpenseStatus;


namespace ExpenseManagementSystem.Application.Abstractions.Services
{
    public interface IExpenseStatusQueryService
    {
        Task<List<ExpenseStatusResponseDto>> GetAllAsync();
        Task<ExpenseStatusResponseDto?> GetByIdAsync(long id);
    }
}
