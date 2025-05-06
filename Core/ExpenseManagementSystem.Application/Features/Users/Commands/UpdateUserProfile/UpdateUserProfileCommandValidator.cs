using FluentValidation;


namespace ExpenseManagementSystem.Application.Features.Users.Commands.UpdateUserProfile
{
    public class UpdateUserProfileCommandValidator : AbstractValidator<UpdateUserProfileCommand>
    {
        public UpdateUserProfileCommandValidator()
        {
            RuleFor(x => x.Model.Iban)
                .NotEmpty()
                .Length(10, 34);

            RuleFor(x => x.Model.Position)
                .NotEmpty();

            RuleFor(x => x.Model.DepartmentName)
                .NotEmpty();

        }
    }
}
