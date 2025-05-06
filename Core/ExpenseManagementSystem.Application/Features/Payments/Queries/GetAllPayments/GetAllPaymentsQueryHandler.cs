using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Dtos.Payment;
using MediatR;


namespace ExpenseManagementSystem.Application.Features.Payments.Queries.GetAllPayments
{
    public class GetAllPaymentsQueryHandler : IRequestHandler<GetAllPaymentsQuery, List<PaymentResponseDto>>
    {
        private readonly IPaymentQueryService _paymentQueryService;

        public GetAllPaymentsQueryHandler(IPaymentQueryService paymentQueryService)
        {
            _paymentQueryService = paymentQueryService;
        }

        public async Task<List<PaymentResponseDto>> Handle(GetAllPaymentsQuery request, CancellationToken cancellationToken)
        {
            return await _paymentQueryService.GetAllAsync();
        }
    }
}
