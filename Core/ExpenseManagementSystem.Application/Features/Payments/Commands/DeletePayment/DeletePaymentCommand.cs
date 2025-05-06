using MediatR;


namespace ExpenseManagementSystem.Application.Features.Payments.Commands.DeletePayment
{
    public class DeletePaymentCommand : IRequest<bool>
    {
        public long Id { get; set; }

        public DeletePaymentCommand(long id)
        {
            Id = id;
        }
    }
}
