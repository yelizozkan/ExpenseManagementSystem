using FluentValidation;

namespace ExpenseManagementSystem.Application.Features.Payments.Commands.DeletePayment
{
    public class DeletePaymentCommandValidator : AbstractValidator<DeletePaymentCommand>
    {
        public DeletePaymentCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
