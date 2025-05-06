using FluentValidation;

namespace ExpenseManagementSystem.Application.Features.Expenses.Commands.UpdateExpense
{
    public class UpdateExpenseCommandValidator : AbstractValidator<UpdateExpenseCommand>
    {
        public UpdateExpenseCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0);

            RuleFor(x => x.Model.CategoryId)
                .GreaterThan(0);

            RuleFor(x => x.Model.Description)
                .MaximumLength(300);

        }
    }
}
