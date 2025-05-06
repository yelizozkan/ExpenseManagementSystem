using ExpenseManagementSystem.Application.Dtos.Payment;
using MediatR;

namespace ExpenseManagementSystem.Application.Features.Payments.Commands.UpdatePayment
{
    public class UpdatePaymentCommand : IRequest<PaymentResponseDto>
    {
        public long Id { get; set; }
        public PaymentRequestDto Model { get; set; }
    }
}
