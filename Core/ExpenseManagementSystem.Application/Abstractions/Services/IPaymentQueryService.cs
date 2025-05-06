using ExpenseManagementSystem.Application.Dtos.Payment;

namespace ExpenseManagementSystem.Application.Abstractions.Services
{
    public interface IPaymentQueryService
    {
        Task<List<PaymentResponseDto>> GetAllAsync();
        Task<PaymentResponseDto> GetByIdAsync(long id);
    }
}
