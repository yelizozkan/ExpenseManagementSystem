using ExpenseManagementSystem.Application.Dtos.Category;


namespace ExpenseManagementSystem.Application.Abstractions.Services
{
    public interface ICategoryService
    {
        Task<CategoryResponseDto> CreateAsync(CategoryRequestDto category );
        Task<CategoryResponseDto> UpdateAsync(long id, CategoryRequestDto category);
        Task<bool> SoftDeleteAsync(long id);
        Task<bool> IsNameTakenAsync(string name);
    }
}
