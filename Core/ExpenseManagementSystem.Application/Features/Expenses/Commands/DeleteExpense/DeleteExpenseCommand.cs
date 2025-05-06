using MediatR;

namespace ExpenseManagementSystem.Application.Features.Expenses.Commands.DeleteExpense
{
    public class DeleteExpenseCommand : IRequest<bool>
    {
        public long Id { get; set; }

        public DeleteExpenseCommand(long id)
        {
            Id = id;
        }
    }
}
