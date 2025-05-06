using FluentValidation;

namespace ExpenseManagementSystem.Application.Features.Expenses.Commands.ApproveExpense
{
    public class ApproveExpenseCommandValidator : AbstractValidator<ApproveExpenseCommand>
    {
        public ApproveExpenseCommandValidator()
        {
            RuleFor(x => x.ExpenseId)
               .GreaterThan(0);

            RuleFor(x => x.Note)
                .MaximumLength(300)
                .When(x => !string.IsNullOrWhiteSpace(x.Note));

        }
    }
}
