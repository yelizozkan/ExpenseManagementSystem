using ExpenseManagementSystem.Application.Dtos.Auth;
using ExpenseManagementSystem.Application.Responses;

namespace ExpenseManagementSystem.Application.Abstractions.Services
{
    public interface IAuthService
    {
        Task<ApiResponse<TokenDto>> LoginAsync(LoginRequestDto model);
        Task<ApiResponse<TokenDto>> RegisterAsync(RegisterRequestDto model);
        Task<ApiResponse<TokenDto>> RefreshTokenLoginAsync(RefreshTokenRequestDto  model);

    }
}
