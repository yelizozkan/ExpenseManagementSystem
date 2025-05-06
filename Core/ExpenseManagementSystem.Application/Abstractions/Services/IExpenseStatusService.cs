using ExpenseManagementSystem.Application.Dtos.ExpenseStatus;

namespace ExpenseManagementSystem.Application.Abstractions.Services
{
    public interface IExpenseStatusService
    {
        Task<ExpenseStatusResponseDto> CreateAsync(ExpenseStatusRequestDto dto);
        Task<ExpenseStatusResponseDto> UpdateAsync(long id, ExpenseStatusRequestDto dto);
        Task<bool> SoftDeleteAsync(long id);
    }
}
