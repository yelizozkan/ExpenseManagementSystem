using ExpenseManagementSystem.Application.Dtos.Expense;
using MediatR;

namespace ExpenseManagementSystem.Application.Features.Expenses.Commands.RejectExpense
{
    public class RejectExpenseCommand : IRequest<ExpenseResponseDto>
    {
        public long ExpenseId { get; set; }
        public string? RejectionNote { get; set; }

        public RejectExpenseCommand(long expenseId, string? rejectionNote)
        {
            ExpenseId = expenseId;
            RejectionNote = rejectionNote;
        }
    }
}
