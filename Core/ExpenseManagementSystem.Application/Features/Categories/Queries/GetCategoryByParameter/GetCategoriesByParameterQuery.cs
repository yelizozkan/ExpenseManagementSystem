using ExpenseManagementSystem.Application.Dtos.Category;
using MediatR;


namespace ExpenseManagementSystem.Application.Features.Categories.Queries.GetCategoryByParameter
{
    public class GetCategoriesByParameterQuery : IRequest<List<CategoryResponseDto>>
    {
        public GetCategoriesByParameterRequestDto Model { get; set; }

        public GetCategoriesByParameterQuery(GetCategoriesByParameterRequestDto model)
        {
            Model = model;
        }
    }
}
