using FluentValidation;

namespace ExpenseManagementSystem.Application.Features.ExpenseStatuses.Commands.UpdateExpenseStatus
{
    public class UpdateExpenseStatusCommandValidator : AbstractValidator<UpdateExpenseStatusCommand>
    {
        public UpdateExpenseStatusCommandValidator()
        {

            RuleFor(x => x.Model.Name).NotEmpty().MaximumLength(100);

            RuleFor(x => x.Model.Description).MaximumLength(300);
                
        }
    }
}
