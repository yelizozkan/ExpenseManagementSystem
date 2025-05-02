using FluentValidation;


namespace ExpenseManagementSystem.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Geçersiz kategori ID.");
        }
    }
}
