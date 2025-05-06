using AutoMapper;
using ExpenseManagementSystem.Application.Abstractions.Repository;
using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Abstractions.UnitOfWork;
using ExpenseManagementSystem.Application.Dtos.Category;
using ExpenseManagementSystem.Application.Exceptions;
using ExpenseManagementSystem.Domain.Entities;


namespace ExpenseManagementSystem.Persistence.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IExpenseRepository _expenseRepository;
        private readonly IExpenditureRepository _expenditureRepository;
        private readonly IMapper _mapper;

        public CategoryService(
            IUnitOfWork unitOfWork,
            ICategoryRepository categoryRepository,
            IExpenseRepository expenseRepository,
            IExpenditureRepository expenditureRepository,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
            _expenseRepository = expenseRepository;
            _expenditureRepository = expenditureRepository;
            _mapper = mapper;
        }

        public async Task<CategoryResponseDto> CreateAsync(CategoryRequestDto category)
        {
            if (await IsNameTakenAsync(category.Name))
                throw new ConflictException("Bu kategori adı zaten kullanılıyor.");

            var entity = _mapper.Map<Category>(category);
            entity.IsActive = true;

            await _categoryRepository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<CategoryResponseDto>(entity);
        }


        public async Task<CategoryResponseDto> UpdateAsync(long id, CategoryRequestDto category)
        {
            var entity = await _categoryRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Kategori bulunamadı.");

            entity.Name = category.Name;
            entity.Description = category.Description;

            _categoryRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<CategoryResponseDto>(entity);
        }


        public async Task<bool> SoftDeleteAsync(long id)
        {
            var category = await _categoryRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Kategori bulunamadı.");

            var isUsedInExpenses = await _expenseRepository.AnyAsync(e => e.CategoryId == id && e.IsActive);
            var isUsedInExpenditures = await _expenditureRepository.AnyAsync(e => e.CategoryId == id && e.IsActive);

            if (isUsedInExpenses || isUsedInExpenditures)
                throw new ConflictException("Bu kategoriye ait aktif harcama veya harcama kalemi bulunduğu için silinemez.");

            category.IsActive = false;
            _categoryRepository.Update(category);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> IsNameTakenAsync(string name)
        {
            return await _categoryRepository.AnyAsync(x => x.Name == name && x.IsActive);
        }
    }
}
