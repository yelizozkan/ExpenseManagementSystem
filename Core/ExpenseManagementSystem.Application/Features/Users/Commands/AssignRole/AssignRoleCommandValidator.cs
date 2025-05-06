using FluentValidation;

namespace ExpenseManagementSystem.Application.Features.Users.Commands.AssignRole
{
    public class AssignRoleCommandValidator : AbstractValidator<AssignRoleCommand>
    {
        public AssignRoleCommandValidator()
        {

            RuleFor(x => x.Model.UserId).GreaterThan(0);

            RuleFor(x => x.Model.RoleName).NotEmpty();
        }
    }
}
