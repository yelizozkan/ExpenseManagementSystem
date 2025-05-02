using FluentValidation;


namespace ExpenseManagementSystem.Application.Features.Expenses.Commands.DeleteExpense
{
    public class DeleteExpenseCommandValidator : AbstractValidator<DeleteExpenseCommand>
    {
        public DeleteExpenseCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
