using ExpenseManagementSystem.Application.Dtos.Auth;
using ExpenseManagementSystem.Domain.Entities.Identity;

namespace ExpenseManagementSystem.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        Task<TokenDto> CreateAccessTokenAsync(AppUser user);
        string CreateRefreshToken();
    }
}
