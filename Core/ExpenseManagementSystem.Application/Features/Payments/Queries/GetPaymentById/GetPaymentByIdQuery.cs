using ExpenseManagementSystem.Application.Dtos.Payment;
using MediatR;

namespace ExpenseManagementSystem.Application.Features.Payments.Queries.GetPaymentById
{
    public class GetPaymentByIdQuery : IRequest<PaymentResponseDto>
    {
        public long Id { get; set; }

        public GetPaymentByIdQuery(long id)
        {
            Id = id;
        }
    }
}
