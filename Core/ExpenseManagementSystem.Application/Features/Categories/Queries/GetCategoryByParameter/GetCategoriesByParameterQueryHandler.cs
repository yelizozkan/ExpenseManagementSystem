using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Dtos.Category;
using MediatR;


namespace ExpenseManagementSystem.Application.Features.Categories.Queries.GetCategoryByParameter
{
    public class GetCategoriesByParameterQueryHandler : IRequestHandler<GetCategoriesByParameterQuery, List<CategoryResponseDto>>
    {
        private readonly ICategoryQueryService _categoryQueryService;

        public GetCategoriesByParameterQueryHandler(ICategoryQueryService categoryQueryService)
        {
            _categoryQueryService = categoryQueryService;
        }

        public async Task<List<CategoryResponseDto>> Handle(GetCategoriesByParameterQuery request, CancellationToken cancellationToken)
        {
            return await _categoryQueryService.GetByParameterAsync(request.Model.Name, request.Model.IsActive);
        }
    }
}
