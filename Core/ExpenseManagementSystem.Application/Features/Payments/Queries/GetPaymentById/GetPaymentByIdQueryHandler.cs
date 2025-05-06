using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Dtos.Payment;
using MediatR;

namespace ExpenseManagementSystem.Application.Features.Payments.Queries.GetPaymentById
{
    public class GetPaymentByIdQueryHandler : IRequestHandler<GetPaymentByIdQuery, PaymentResponseDto>
    {
        private readonly IPaymentQueryService _paymentQueryService;

        public GetPaymentByIdQueryHandler(IPaymentQueryService paymentQueryService)
        {
            _paymentQueryService = paymentQueryService;
        }

        public async Task<PaymentResponseDto> Handle(GetPaymentByIdQuery request, CancellationToken cancellationToken)
        {
            return await _paymentQueryService.GetByIdAsync(request.Id);
        }
    }
}
