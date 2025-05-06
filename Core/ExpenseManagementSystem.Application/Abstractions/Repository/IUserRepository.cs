using ExpenseManagementSystem.Domain.Entities.Identity;


namespace ExpenseManagementSystem.Application.Abstractions.Repository
{
    public interface IUserRepository 
    {
        Task<AppUser> GetByIdAsync(string id);
        Task<AppUser> GetByEmailAsync(string email);
        Task<List<AppUser>> GetAllAsync();
        Task UpdateAsync(AppUser user);
    }
}
