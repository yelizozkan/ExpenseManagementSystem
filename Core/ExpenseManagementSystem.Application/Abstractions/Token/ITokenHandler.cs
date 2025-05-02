using ExpenseManagementSystem.Application.Dtos;
using ExpenseManagementSystem.Domain.Identity;


namespace ExpenseManagementSystem.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        Task<TokenDto> CreateAccessTokenAsync(AppUser user);
        string CreateRefreshToken();
    }
}
