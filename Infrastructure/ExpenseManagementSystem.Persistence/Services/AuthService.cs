using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Abstractions.Token;
using ExpenseManagementSystem.Application.Dtos.Auth;
using ExpenseManagementSystem.Application.Responses;
using ExpenseManagementSystem.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace ExpenseManagementSystem.Persistence.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenHandler _tokenHandler;

        public AuthService(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
        }

        public async Task<ApiResponse<TokenDto>> LoginAsync(LoginRequestDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return new ApiResponse<TokenDto>("Kullanıcı bulunamadı");

            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (!result.Succeeded)
                return new ApiResponse<TokenDto>("Şifre hatalı");

            var token = await GenerateAndAssignTokenAsync(user);
            return new ApiResponse<TokenDto>(token);
        }

        public async Task<ApiResponse<TokenDto>> RegisterAsync(RegisterRequestDto dto)
        {
            var user = new AppUser
            {
                UserName = Guid.NewGuid().ToString(), 
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                var errorMessage = string.Join(", ", result.Errors.Select(e => e.Description));
                return new ApiResponse<TokenDto>(errorMessage);
            }

            await _userManager.AddToRoleAsync(user, "Personnel");

            var token = await GenerateAndAssignTokenAsync(user);
            return new ApiResponse<TokenDto>(token);
        }

        public async Task<ApiResponse<TokenDto>> RefreshTokenLoginAsync(RefreshTokenRequestDto model)
        {
            var user = await _userManager.Users
                .FirstOrDefaultAsync(u => u.RefreshToken == model.RefreshToken);

            if (user == null || user.RefreshTokenEndDate <= DateTime.UtcNow)
                return new ApiResponse<TokenDto>("Refresh token geçersiz veya süresi dolmuş.");

            var token = await GenerateAndAssignTokenAsync(user);
            return new ApiResponse<TokenDto>(token);
        }

        private async Task<TokenDto> GenerateAndAssignTokenAsync(AppUser user)
        {
            var token = await _tokenHandler.CreateAccessTokenAsync(user);
            await UpdateRefreshTokenAsync(user, token);
            return token;
        }

        private async Task UpdateRefreshTokenAsync(AppUser user, TokenDto token)
        {
            user.RefreshToken = token.RefreshToken;
            user.RefreshTokenEndDate = token.Expiration.AddDays(7);
            await _userManager.UpdateAsync(user);
        }
    }
}
