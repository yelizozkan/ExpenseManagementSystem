using ExpenseManagementSystem.Application.Dtos.Payment;
using ExpenseManagementSystem.Application.Responses;

namespace ExpenseManagementSystem.Application.Abstractions.Services
{
    public interface IPaymentService
    {
        Task<PaymentResponseDto> CreateAsync(PaymentRequestDto model);
        Task<PaymentResponseDto> UpdateAsync(long id, PaymentRequestDto model);
        Task<ApiResponse<string>> DeleteAsync(long id);
    }
}
