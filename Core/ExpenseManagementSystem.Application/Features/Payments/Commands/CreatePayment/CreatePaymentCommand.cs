using ExpenseManagementSystem.Application.Dtos.Payment;
using MediatR;

namespace ExpenseManagementSystem.Application.Features.Payments.Commands.CreatePayment
{
    public class CreatePaymentCommand : IRequest<PaymentResponseDto>
    {
        public PaymentRequestDto Model { get; set; }

        public CreatePaymentCommand(PaymentRequestDto model)
        {
            Model = model;
        }
    }
}
