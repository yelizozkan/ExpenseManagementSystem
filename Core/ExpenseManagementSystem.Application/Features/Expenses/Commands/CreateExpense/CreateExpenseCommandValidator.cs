using FluentValidation;


namespace ExpenseManagementSystem.Application.Features.Expenses.Commands.CreateExpense
{
    public class CreateExpenseCommandValidator : AbstractValidator<CreateExpenseCommand>
    {
        public CreateExpenseCommandValidator()
        {
            RuleFor(x => x.Model.Description).MaximumLength(500);

            RuleFor(x => x.Model.Total).GreaterThan(0);
        }
    }
}
