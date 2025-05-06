using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Dtos.User;
using ExpenseManagementSystem.Application.Responses;
using ExpenseManagementSystem.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace ExpenseManagementSystem.Persistence.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public UserRoleService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<ApiResponse> AssignRoleAsync(AssignRoleRequestDto dto)
        {
            var user = await _userManager.FindByIdAsync(dto.UserId.ToString());
            if (user == null)
                return new ApiResponse("Kullanıcı bulunamadı.");

            var roleExists = await _roleManager.RoleExistsAsync(dto.RoleName);
            if (!roleExists)
                return new ApiResponse("Rol bulunamadı.");

            var currentRoles = await _userManager.GetRolesAsync(user);
            if (currentRoles.Contains(dto.RoleName))
                return new ApiResponse("Kullanıcı zaten bu role sahip.");


            await _userManager.RemoveFromRolesAsync(user, currentRoles);

            var result = await _userManager.AddToRoleAsync(user, dto.RoleName);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                return new ApiResponse($"Rol ataması başarısız oldu: {errors}");
            }

            return new ApiResponse("Rol başarıyla atandı.", true);
        }


        public async Task<ApiResponse<List<string>>> GetUserRolesAsync(long userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                return new ApiResponse<List<string>>("Kullanıcı bulunamadı.");

            var roles = await _userManager.GetRolesAsync(user);
            return new ApiResponse<List<string>>(roles.ToList());
        }
    }
}
