using FluentValidation;

namespace ExpenseManagementSystem.Application.Features.Auth.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.Model.FirstName)
                .NotEmpty();

            RuleFor(x => x.Model.LastName)
                .NotEmpty();

            RuleFor(x => x.Model.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Model.Password)
                .NotEmpty()
                .MinimumLength(6);

        }
    }
}
