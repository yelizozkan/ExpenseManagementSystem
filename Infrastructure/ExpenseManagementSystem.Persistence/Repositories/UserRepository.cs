using ExpenseManagementSystem.Application.Abstractions.Repository;
using ExpenseManagementSystem.Domain.Entities.Identity;
using ExpenseManagementSystem.Persistence.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace ExpenseManagementSystem.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ExpenseManagementSystemDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public UserRepository(ExpenseManagementSystemDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<AppUser> GetByIdAsync(string id)
        {
            return await _userManager.Users.FirstOrDefaultAsync(u => u.Id.ToString() == id)
                   ?? throw new Exception("Kullanıcı bulunamadı.");
        }

        public async Task<AppUser> GetByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email)
                   ?? throw new Exception("Email ile kullanıcı bulunamadı.");
        }

        public async Task<List<AppUser>> GetAllAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task UpdateAsync(AppUser user)
        {
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
                throw new Exception("Kullanıcı güncellenemedi.");
        }
    }
}
