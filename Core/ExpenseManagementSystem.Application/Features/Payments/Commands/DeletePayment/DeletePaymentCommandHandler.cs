using ExpenseManagementSystem.Application.Abstractions.Services;
using MediatR;

namespace ExpenseManagementSystem.Application.Features.Payments.Commands.DeletePayment
{
    public class DeletePaymentCommandHandler : IRequestHandler<DeletePaymentCommand, bool>
    {
        private readonly IPaymentService _paymentService;

        public DeletePaymentCommandHandler(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public async Task<bool> Handle(DeletePaymentCommand request, CancellationToken cancellationToken)
        {
            return await _paymentService.DeleteAsync(request.Id);
        }
    }
}
