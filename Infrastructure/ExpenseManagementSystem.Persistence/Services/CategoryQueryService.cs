using AutoMapper;
using ExpenseManagementSystem.Application.Abstractions.Repository;
using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Dtos.Category;
using ExpenseManagementSystem.Application.Exceptions;
using Microsoft.EntityFrameworkCore;


namespace ExpenseManagementSystem.Persistence.Services
{
    public class CategoryQueryService : ICategoryQueryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryQueryService(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;

        }

        public async Task<List<CategoryResponseDto>> GetAllAsync()
        {
            var categories = await _categoryRepository
                .Where(c => c.IsActive, tracking: false)
                .ToListAsync();

            return _mapper.Map<List<CategoryResponseDto>>(categories);
        }

        public async Task<CategoryResponseDto?> GetByIdAsync(long id)
        {
            var category = await _categoryRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Category not found.");

            return _mapper.Map<CategoryResponseDto>(category);
        }
    }
}
