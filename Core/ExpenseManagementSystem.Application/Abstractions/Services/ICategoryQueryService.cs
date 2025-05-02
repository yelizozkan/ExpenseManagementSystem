using ExpenseManagementSystem.Application.Dtos.Category;


namespace ExpenseManagementSystem.Application.Abstractions.Services
{
    public interface ICategoryQueryService
    {
        Task<List<CategoryResponseDto>> GetAllAsync();
        Task<CategoryResponseDto?> GetByIdAsync(long id);
        Task<List<CategoryResponseDto>> GetByParameterAsync(string? name, bool? isActive);
    }
}
