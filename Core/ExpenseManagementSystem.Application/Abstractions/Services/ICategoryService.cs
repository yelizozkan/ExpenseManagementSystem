using ExpenseManagementSystem.Application.Dtos.Category;
using ExpenseManagementSystem.Domain.Entities;


namespace ExpenseManagementSystem.Application.Abstractions.Services
{
    public interface ICategoryService
    {
        Task<Category> CreateAsync(CategoryRequestDto category );
        Task<Category> UpdateAsync(long id, CategoryRequestDto category);
        Task<bool> SoftDeleteAsync(long id);
        Task<bool> IsNameTakenAsync(string name);
    }
}
