using AutoMapper;
using ExpenseManagementSystem.Application.Abstractions.Repository;
using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Abstractions.UnitOfWork;
using ExpenseManagementSystem.Application.Dtos.Category;
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
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null) return null;
            return _mapper.Map<CategoryResponseDto>(category);
        }

        public async Task<List<CategoryResponseDto>> GetByParameterAsync(string? name, bool? isActive)
        {
            var query = _categoryRepository.Where(x => true, tracking: false);

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(x => x.Name.Contains(name));

            if (isActive.HasValue)
                query = query.Where(x => x.IsActive == isActive);

            var result = await query.ToListAsync();
            return _mapper.Map<List<CategoryResponseDto>>(result);
        }
    }
}
