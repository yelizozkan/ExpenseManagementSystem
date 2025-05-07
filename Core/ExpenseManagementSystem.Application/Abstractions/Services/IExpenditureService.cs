using ExpenseManagementSystem.Application.Dtos.Expenditure;


namespace ExpenseManagementSystem.Application.Abstractions.Services
{
    public interface IExpenditureService
    {
        Task<ExpenditureResponseDto> CreateAsync(ExpenditureRequestDto model);
        Task<ExpenditureResponseDto> UpdateAsync(long id, ExpenditureRequestDto model);
        Task<bool> SoftDeleteAsync(long id);
        Task<ExpenditureResponseDto> ApproveExpenditureAsync(long id, string? note);
        Task<ExpenditureResponseDto> RejectExpenditureAsync(long id, string? note);

    }
}
