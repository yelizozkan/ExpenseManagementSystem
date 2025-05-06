using FluentValidation;


namespace ExpenseManagementSystem.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.Model.Name)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Model.Description)
                .MaximumLength(300);
        }
    }
}
