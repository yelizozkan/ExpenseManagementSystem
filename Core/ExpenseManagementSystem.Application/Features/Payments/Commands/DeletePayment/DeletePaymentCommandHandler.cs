using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Responses;
using MediatR;

namespace ExpenseManagementSystem.Application.Features.Payments.Commands.DeletePayment
{
    public class DeletePaymentCommandHandler : IRequestHandler<DeletePaymentCommand, ApiResponse<string>>
    {
        private readonly IPaymentService _paymentService;

        public DeletePaymentCommandHandler(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public async Task<ApiResponse<string>> Handle(DeletePaymentCommand request, CancellationToken cancellationToken)
        {
            return await _paymentService.DeleteAsync(request.Id);
        }
    }
}
