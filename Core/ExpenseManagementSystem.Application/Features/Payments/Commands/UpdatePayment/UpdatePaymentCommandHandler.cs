using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Dtos.Payment;
using MediatR;

namespace ExpenseManagementSystem.Application.Features.Payments.Commands.UpdatePayment
{
    public class UpdatePaymentCommandHandler : IRequestHandler<UpdatePaymentCommand, PaymentResponseDto>
    {
        private readonly IPaymentService _paymentService;


        public UpdatePaymentCommandHandler(IPaymentService paymentService)
        {
            _paymentService = paymentService;

        }

        public async Task<PaymentResponseDto> Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
        {
            return await _paymentService.UpdateAsync(request.Id, request.Model);
        }
    }
}
