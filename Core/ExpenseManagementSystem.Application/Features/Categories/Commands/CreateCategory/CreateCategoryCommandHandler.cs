using AutoMapper;
using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Dtos.Category;
using MediatR;


namespace ExpenseManagementSystem.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryResponseDto>
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<CategoryResponseDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _categoryService.CreateAsync(request.Model);
            return _mapper.Map<CategoryResponseDto>(entity);
        }
    }
}
