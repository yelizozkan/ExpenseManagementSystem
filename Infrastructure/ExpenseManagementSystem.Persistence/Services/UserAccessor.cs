using ExpenseManagementSystem.Application.Abstractions.Services;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;


namespace ExpenseManagementSystem.Persistence.Services
{
    public class UserAccessor : IUserAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public long GetUserId()
        {
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            return long.Parse(userId ?? throw new UnauthorizedAccessException("Kullanıcı bilgisi alınamadı."));
        }

        public string GetUserRole()
        {
            return _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Role)?.Value
               ?? throw new UnauthorizedAccessException("Rol bilgisi alınamadı.");
        }
    }
}
