using ExpenseManagementSystem.Application.Dtos.User;
using ExpenseManagementSystem.Application.Responses;

namespace ExpenseManagementSystem.Application.Abstractions.Services
{
    public interface IUserRoleService
    {
        Task<ApiResponse> AssignRoleAsync(AssignRoleRequestDto dto);
        Task<ApiResponse<List<string>>> GetUserRolesAsync(long userId);
    }
}
