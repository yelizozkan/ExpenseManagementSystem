using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Dtos.Category;
using MediatR;


namespace ExpenseManagementSystem.Application.Features.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryResponseDto>
    {
        private readonly ICategoryQueryService _categoryQueryService;

        public GetCategoryByIdQueryHandler(ICategoryQueryService categoryQueryService)
        {
            _categoryQueryService = categoryQueryService;
        }

        public async Task<CategoryResponseDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            return await _categoryQueryService.GetByIdAsync(request.Id);
        }
    }
}
