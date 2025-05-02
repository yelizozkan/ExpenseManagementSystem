using FluentValidation;


namespace ExpenseManagementSystem.Application.Features.Expenditures.Commands.CreateExpenditure
{
    public class CreateExpenditureCommandValidator : AbstractValidator<CreateExpenditureCommand>
    {
        public CreateExpenditureCommandValidator()
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
