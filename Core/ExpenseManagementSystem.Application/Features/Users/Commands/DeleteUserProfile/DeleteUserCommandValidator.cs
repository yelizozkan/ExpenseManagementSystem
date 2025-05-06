using FluentValidation;


namespace ExpenseManagementSystem.Application.Features.Users.Commands.DeleteUserProfile
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().GreaterThan(0);
        }
    }
}
