using ExpenseManagementSystem.Application.Dtos.Payment;
using MediatR;

namespace ExpenseManagementSystem.Application.Features.Payments.Queries.GetAllPayments
{
    public class GetAllPaymentsQuery : IRequest<List<PaymentResponseDto>>
    {
    }
}
