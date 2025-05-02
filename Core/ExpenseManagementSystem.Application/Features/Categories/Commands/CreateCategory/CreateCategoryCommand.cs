using ExpenseManagementSystem.Application.Dtos.Category;
using MediatR;


namespace ExpenseManagementSystem.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<CategoryResponseDto>
    {
        public CategoryRequestDto Model { get; set; }
        public CreateCategoryCommand(CategoryRequestDto model)
        {
            Model = model;
        }

    }
}
