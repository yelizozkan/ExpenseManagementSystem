using FluentValidation;


namespace ExpenseManagementSystem.Application.Features.Expenditures.Commands.UpdateExpenditure
{
    public class UpdateExpenditureCommandValidator : AbstractValidator<UpdateExpenditureCommand>
    {
        public UpdateExpenditureCommandValidator()
        {

            RuleFor(x => x.Model.ExpenseId)
                .GreaterThan(0);

            RuleFor(x => x.Model.CategoryId)
                .GreaterThan(0);

            RuleFor(x => x.Model.Amount)
                .GreaterThan(0);

            RuleFor(x => x.Model.TaxAmount)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.Model.ReceiptNumber)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Model.Date)
                .NotEmpty()
                .LessThanOrEqualTo(DateTime.UtcNow.Date);
        }
    }
}
