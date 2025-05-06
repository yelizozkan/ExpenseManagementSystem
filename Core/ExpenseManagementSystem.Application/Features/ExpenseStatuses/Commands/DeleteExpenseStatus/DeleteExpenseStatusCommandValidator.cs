using FluentValidation;


namespace ExpenseManagementSystem.Application.Features.ExpenseStatuses.Commands.DeleteExpenseStatus
{
    public class DeleteExpenseStatusCommandValidator : AbstractValidator<DeleteExpenseStatusCommand>
    {
        public DeleteExpenseStatusCommandValidator()
        {

            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
                
        }
    }
}
