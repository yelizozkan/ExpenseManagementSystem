using ExpenseManagementSystem.Application.Dtos.Expense;
using MediatR;


namespace ExpenseManagementSystem.Application.Features.Expenses.Commands.ApproveExpense
{
    public class ApproveExpenseCommand : IRequest<ExpenseResponseDto>
    {
        public long ExpenseId { get; set; }
        public string? Note { get; set; }

        public ApproveExpenseCommand() { }

        public ApproveExpenseCommand(long expenseId, string? note)
        {
            ExpenseId = expenseId;
            Note = note;
        }
    }
}
