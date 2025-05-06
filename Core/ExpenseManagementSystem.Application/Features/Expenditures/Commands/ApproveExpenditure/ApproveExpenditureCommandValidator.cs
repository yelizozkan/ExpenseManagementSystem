using FluentValidation;


namespace ExpenseManagementSystem.Application.Features.Expenditures.Commands.ApproveExpenditure
{
    public class ApproveExpenditureCommandValidator : AbstractValidator<ApproveExpenditureCommand>
    {
        public ApproveExpenditureCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
