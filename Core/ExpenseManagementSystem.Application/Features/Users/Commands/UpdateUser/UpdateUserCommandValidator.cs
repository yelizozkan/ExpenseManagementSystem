using FluentValidation;

namespace ExpenseManagementSystem.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0);

            RuleFor(x => x.Dto.Iban)
                .NotEmpty()
                .Length(10, 34);

            RuleFor(x => x.Dto.Position)
                .NotEmpty();

            RuleFor(x => x.Dto.DepartmentName)
                .NotEmpty();
        }
    }
}
