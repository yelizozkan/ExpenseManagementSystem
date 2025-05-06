using FluentValidation;

namespace ExpenseManagementSystem.Application.Features.Expenses.Commands.RejectExpense
{
    public class RejectExpenseCommandValidator : AbstractValidator<RejectExpenseCommand>
    {
        public RejectExpenseCommandValidator()
        {
            RuleFor(x => x.ExpenseId).GreaterThan(0);

            RuleFor(x => x.RejectionNote)
                .MaximumLength(300)
                .When(x => !string.IsNullOrWhiteSpace(x.RejectionNote));
        }
    }
}
