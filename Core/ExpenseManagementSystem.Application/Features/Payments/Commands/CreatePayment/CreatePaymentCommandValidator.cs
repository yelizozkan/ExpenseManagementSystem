using FluentValidation;

namespace ExpenseManagementSystem.Application.Features.Payments.Commands.CreatePayment
{
    public class CreatePaymentCommandValidator : AbstractValidator<CreatePaymentCommand>
    {
        public CreatePaymentCommandValidator()
        {
            RuleFor(x => x.Model.ExpenditureId).GreaterThan(0);
        }
    }
}
