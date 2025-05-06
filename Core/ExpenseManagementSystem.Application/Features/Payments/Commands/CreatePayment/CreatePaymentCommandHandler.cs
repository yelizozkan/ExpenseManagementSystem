using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Dtos.Payment;
using MediatR;

namespace ExpenseManagementSystem.Application.Features.Payments.Commands.CreatePayment
{
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, PaymentResponseDto>
    {
        private readonly IPaymentService _paymentService;

        public CreatePaymentCommandHandler(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public async Task<PaymentResponseDto> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            return await _paymentService.CreateAsync(request.Model);
        }
    }
}
