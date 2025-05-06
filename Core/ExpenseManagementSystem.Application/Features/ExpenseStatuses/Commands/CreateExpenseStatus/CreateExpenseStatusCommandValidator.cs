using FluentValidation;


namespace ExpenseManagementSystem.Application.Features.ExpenseStatuses.Commands.CreateExpenseStatus
{
    public class CreateExpenseStatusCommandValidator : AbstractValidator<CreateExpenseStatusCommand>
    {
        public CreateExpenseStatusCommandValidator()
        {
            RuleFor(x => x.Model.Name).NotEmpty().MaximumLength(100);

            RuleFor(x => x.Model.Description).MaximumLength(300);     
        }
    }
}
