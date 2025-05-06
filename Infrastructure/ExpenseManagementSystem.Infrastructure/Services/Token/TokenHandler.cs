using ExpenseManagementSystem.Application.Abstractions.Token;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity;
using ExpenseManagementSystem.Domain.Entities.Identity;
using ExpenseManagementSystem.Application.Dtos.Auth;


namespace ExpenseManagementSystem.Infrastructure.Services.Token
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<AppUser> _userManager;

        public TokenHandler(IConfiguration configuration, UserManager<AppUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        public async Task<TokenDto> CreateAccessTokenAsync(AppUser user)
        {
            var expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["JwtConfig:AccessTokenExpiration"]));
            var claims = await GenerateClaims(user);
            var creds = GenerateSigningCredentials();

            var jwt = new JwtSecurityToken(
                issuer: _configuration["JwtConfig:Issuer"],
                audience: _configuration["JwtConfig:Audience"],
                expires: expires,
                notBefore: DateTime.UtcNow,
                signingCredentials: creds,
                claims: claims
            );

            return new TokenDto
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(jwt),
                Expiration = expires,
                RefreshToken = CreateRefreshToken()
            };
        }

        private async Task<IEnumerable<Claim>> GenerateClaims(AppUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}")
            };

            var roles = await _userManager.GetRolesAsync(user);
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            return claims;
        }


        private SigningCredentials GenerateSigningCredentials()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtConfig:SecurityKey"]!));
            return new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        }



        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using RandomNumberGenerator random = RandomNumberGenerator.Create();
            random.GetBytes(number);
            return Convert.ToBase64String(number);
        }
        
    }
}
