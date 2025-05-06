using ExpenseManagementSystem.Application.Dtos.Category;
using MediatR;


namespace ExpenseManagementSystem.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<CategoryResponseDto>
    {
        public long Id { get; set; } 
        public CategoryRequestDto Model { get; set; }

        public UpdateCategoryCommand(long id, CategoryRequestDto model)
        {
            Id = id;
            Model = model;
        }
    }
}
