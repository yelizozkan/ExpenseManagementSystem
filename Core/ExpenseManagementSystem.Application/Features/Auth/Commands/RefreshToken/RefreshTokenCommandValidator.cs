using FluentValidation;

namespace ExpenseManagementSystem.Application.Features.Auth.Commands.RefreshToken
{
    public class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommand>
    {
        public RefreshTokenCommandValidator()
        {
            RuleFor(x => x.Model.RefreshToken)
                .NotEmpty();
        }
    }
}
