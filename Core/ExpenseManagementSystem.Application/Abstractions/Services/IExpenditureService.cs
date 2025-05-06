using ExpenseManagementSystem.Application.Dtos.Expenditure;
using ExpenseManagementSystem.Application.Responses;


namespace ExpenseManagementSystem.Application.Abstractions.Services
{
    public interface IExpenditureService
    {
        Task<ExpenditureResponseDto> CreateAsync(ExpenditureRequestDto model);
        Task<ExpenditureResponseDto> UpdateAsync(long id, ExpenditureRequestDto model);
        Task<bool> SoftDeleteAsync(long id);
        Task<ApiResponse> ApproveForPaymentAsync(long id);
        Task<ApiResponse> RejectForPaymentAsync(long id);

    }
}
