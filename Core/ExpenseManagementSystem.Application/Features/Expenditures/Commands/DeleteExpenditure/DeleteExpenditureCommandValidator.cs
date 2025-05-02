using FluentValidation;


namespace ExpenseManagementSystem.Application.Features.Expenditures.Commands.DeleteExpenditure
{
    public class DeleteExpenditureCommandValidator : AbstractValidator<DeleteExpenditureCommand>
    {
        public DeleteExpenditureCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
