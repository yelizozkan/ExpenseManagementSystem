using MediatR;

namespace ExpenseManagementSystem.Application.Features.ExpenseStatuses.Commands.DeleteExpenseStatus
{
    public class DeleteExpenseStatusCommand : IRequest<bool>
    {
        public long Id { get; set; }

        public DeleteExpenseStatusCommand(long id)
        {
            Id = id;
        }
    }
}
