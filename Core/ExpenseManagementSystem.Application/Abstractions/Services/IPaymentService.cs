using ExpenseManagementSystem.Application.Dtos.Payment;

namespace ExpenseManagementSystem.Application.Abstractions.Services
{
    public interface IPaymentService
    {
        Task<PaymentResponseDto> CreateAsync(PaymentRequestDto model);
        Task<PaymentResponseDto> UpdateAsync(long id, PaymentRequestDto model);
        Task<bool> DeleteAsync(long id);
    }
}
