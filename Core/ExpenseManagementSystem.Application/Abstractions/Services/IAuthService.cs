using ExpenseManagementSystem.Application.Dtos;
using ExpenseManagementSystem.Application.Dtos.Auth;

namespace ExpenseManagementSystem.Application.Abstractions.Services
{
    public interface IAuthService
    {
        Task<TokenDto> LoginAsync(string email, string password);
        Task<TokenDto> RegisterAsync(RegisterRequestDto model);
        Task<TokenDto> RefreshTokenLoginAsync(string refreshToken);

    }
}
