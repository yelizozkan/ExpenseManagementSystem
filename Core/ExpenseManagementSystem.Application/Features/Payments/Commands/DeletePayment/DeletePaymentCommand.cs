using ExpenseManagementSystem.Application.Responses;
using MediatR;


namespace ExpenseManagementSystem.Application.Features.Payments.Commands.DeletePayment
{
    public class DeletePaymentCommand : IRequest<ApiResponse<string>>
    {
        public long Id { get; set; }

        public DeletePaymentCommand(long id)
        {
            Id = id;
        }
    }
}
