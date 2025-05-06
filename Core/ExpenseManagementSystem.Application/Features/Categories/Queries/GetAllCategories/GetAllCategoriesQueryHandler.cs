using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Dtos.Category;
using MediatR;

namespace ExpenseManagementSystem.Application.Features.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryResponseDto>>
    {
        private readonly ICategoryQueryService _categoryQueryService;

        public GetAllCategoriesQueryHandler(ICategoryQueryService categoryQueryService)
        {
            _categoryQueryService = categoryQueryService;
        }

        public async Task<List<CategoryResponseDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _categoryQueryService.GetAllAsync();
        }
    }
}
