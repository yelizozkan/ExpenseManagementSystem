using AutoMapper;
using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Dtos.Category;
using MediatR;

namespace ExpenseManagementSystem.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CategoryResponseDto>
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<CategoryResponseDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var updatedCategory = await _categoryService.UpdateAsync(request.Id, request.Model);
            return _mapper.Map<CategoryResponseDto>(updatedCategory);
        }
    }
}
