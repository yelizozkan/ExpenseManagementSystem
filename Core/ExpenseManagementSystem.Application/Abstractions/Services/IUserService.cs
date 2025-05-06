using ExpenseManagementSystem.Application.Dtos.User;
using ExpenseManagementSystem.Application.Responses;


namespace ExpenseManagementSystem.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<ApiResponse<UserProfileResponseDto>> GetProfileAsync();
        Task<ApiResponse<UserProfileResponseDto>> UpdateMyProfileAsync(UserProfileRequestDto dto);
        Task<ApiResponse<List<UserProfileResponseDto>>> GetAllUsersAsync();
        Task<ApiResponse> DeleteUserAsync(long userId); 
        Task<ApiResponse<UserProfileResponseDto>> UpdateUserAsync(long userId, UserProfileRequestDto dto);

    }
}
