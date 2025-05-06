using FluentValidation;


namespace ExpenseManagementSystem.Application.Features.Expenditures.Commands.RejectExpenditure
{
    public class RejectExpenditureCommandValidator : AbstractValidator<RejectExpenditureCommand>
    {
        public RejectExpenditureCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
