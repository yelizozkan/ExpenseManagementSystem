using ExpenseManagementSystem.Application.Dtos.Category;
using MediatR;


namespace ExpenseManagementSystem.Application.Features.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdQuery : IRequest<CategoryResponseDto>
    {
        public long Id { get; set; }

        public GetCategoryByIdQuery(long id)
        {
            Id = id;
        }
    }
}
