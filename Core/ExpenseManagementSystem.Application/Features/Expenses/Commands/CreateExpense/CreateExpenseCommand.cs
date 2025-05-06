using ExpenseManagementSystem.Application.Dtos.Expense;
using MediatR;


namespace ExpenseManagementSystem.Application.Features.Expenses.Commands.CreateExpense
{
    public class CreateExpenseCommand : IRequest<ExpenseResponseDto>
    {
        public ExpenseRequestDto Model { get; set; }

        public CreateExpenseCommand(ExpenseRequestDto model)
        {
            Model = model;
        }
    }
}
