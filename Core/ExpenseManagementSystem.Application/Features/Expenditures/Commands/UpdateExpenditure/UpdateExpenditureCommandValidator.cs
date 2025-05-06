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

            RuleFor(x => x.Model.Description).MaximumLength(300);

            RuleFor(x => x.Model.Amount)
                .GreaterThan(0);

            RuleFor(x => x.Model.TaxAmount)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.Model.ReceiptFile)
                .NotNull();

            RuleFor(x => x.Model.ReceiptNumber)
                .Matches("^[a-zA-Z0-9-]+$");

            RuleFor(x => x.Model.Date)
                .NotEmpty()
                .LessThanOrEqualTo(DateTime.UtcNow.Date);
        }
    }
}
