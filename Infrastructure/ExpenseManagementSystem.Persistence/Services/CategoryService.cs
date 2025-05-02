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
        private readonly IExpenditureRepository _expenditureRepository;


        public CategoryService(IUnitOfWork unitOfWork, ICategoryRepository categoryRepository, IExpenditureRepository expenditureRepository)
        {
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
            _expenditureRepository = expenditureRepository;
        }

        public async Task<Category> CreateAsync(CategoryRequestDto category)
        {
            if(await IsNameTakenAsync(category.Name))
                throw new ConflictException("Bu kategori adı zaten kullanılıyor.");

            var categoryObject = new Category
            {
                Name = category.Name,
                Description = category.Description,
                IsActive = true
            };

            await _categoryRepository.AddAsync(categoryObject);
            await _unitOfWork.SaveChangesAsync();
            return categoryObject;
        }


        public async Task<bool> IsNameTakenAsync(string name)
        {
            return await _categoryRepository.AnyAsync(c => c.Name == name && c.IsActive);
        }

        public async Task<bool> SoftDeleteAsync(long id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
                throw new KeyNotFoundException("Kategori bulunamadı.");

            var hasActiveExpenditure = await _expenditureRepository.AnyAsync(e => e.CategoryId == id && e.Expense.IsActive);
            if (hasActiveExpenditure)
                throw new ConflictException("Bu kategoriye ait aktif harcama bulunduğu için silinemez.");

            category.IsActive = false;
            _categoryRepository.Update(category);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<Category> UpdateAsync(long id, CategoryRequestDto category)
        {
            var categoryObject = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
                throw new Exception("Kategori bulunamadı.");

            categoryObject.Name = category.Name;
            categoryObject.Description = category.Description;

            _categoryRepository.Update(categoryObject);
            await _unitOfWork.SaveChangesAsync();
            return categoryObject;
        }
    }

}
