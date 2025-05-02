using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Abstractions.Token;
using ExpenseManagementSystem.Application.Dtos;
using ExpenseManagementSystem.Application.Dtos.Auth;
using ExpenseManagementSystem.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;



namespace ExpenseManagementSystem.Persistence.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenHandler _tokenHandler;

        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
        }

        public async Task<TokenDto> LoginAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email)
                       ?? throw new UnauthorizedAccessException("Kullanıcı bulunamadı");

            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (!result.Succeeded)
                throw new UnauthorizedAccessException("Şifre hatalı");

            var token = await _tokenHandler.CreateAccessTokenAsync(user);
            await UpdateRefreshTokenAsync(user, token);

            return token;
        }

        public async Task<TokenDto> RegisterAsync(RegisterRequestDto model)
        {
            var user = await CreateAndValidateUser(model);
            await AssignRoleIfGiven(user, model.Role);

            var token = await _tokenHandler.CreateAccessTokenAsync(user);
            await UpdateRefreshTokenAsync(user, token);

            return token;
        }

        private async Task<AppUser> CreateAndValidateUser(RegisterRequestDto model)
        {
            var user = new AppUser
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception($"Kullanıcı oluşturulamadı: {errors}");
            }

            return user;
        }

        private async Task AssignRoleIfGiven(AppUser user, string role)
        {
            if (!string.IsNullOrWhiteSpace(role))
            {
                var roleExists = await _userManager.IsInRoleAsync(user, role);
                if (!roleExists)
                    await _userManager.AddToRoleAsync(user, role);
            }
        }


        private async Task UpdateRefreshTokenAsync(AppUser user, TokenDto token)
        {
            user.RefreshToken = token.RefreshToken;
            user.RefreshTokenEndDate = token.Expiration.AddDays(7); 
            await _userManager.UpdateAsync(user);
        }

        public async Task<TokenDto> RefreshTokenLoginAsync(string refreshToken)
        {
            var user = await _userManager.Users
                .FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);

            if (user == null || user.RefreshTokenEndDate <= DateTime.UtcNow)
                throw new UnauthorizedAccessException("Geçersiz veya süresi dolmuş refresh token.");

            var token = await _tokenHandler.CreateAccessTokenAsync(user);
            await UpdateRefreshTokenAsync(user, token); 

            return token;
        }


    }
}
