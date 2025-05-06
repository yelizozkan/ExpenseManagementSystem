using FluentValidation;


namespace ExpenseManagementSystem.Application.Features.Payments.Commands.UpdatePayment
{
    public class UpdatePaymentCommandValidator : AbstractValidator<UpdatePaymentCommand>
    {
        public UpdatePaymentCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);

            RuleFor(x => x.Model.ExpenditureId).GreaterThan(0);
        }
    }
}
