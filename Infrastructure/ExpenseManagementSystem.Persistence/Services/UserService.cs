using AutoMapper;
using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Dtos.User;
using ExpenseManagementSystem.Application.Responses;
using ExpenseManagementSystem.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;


namespace ExpenseManagementSystem.Persistence.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserAccessor _userAccessor;
        private readonly IMapper _mapper;

        public UserService(UserManager<AppUser> userManager, IUserAccessor userAccessor, IMapper mapper)
        {
            _userManager = userManager;
            _userAccessor = userAccessor;
            _mapper = mapper;
        }

        public async Task<ApiResponse<UserProfileResponseDto>> GetProfileAsync()
        {
            var userId = _userAccessor.GetUserId();

            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                return new ApiResponse<UserProfileResponseDto>("Kullanıcı bulunamadı");

            var roles = await _userManager.GetRolesAsync(user);
            var dto = _mapper.Map<UserProfileResponseDto>(user);
            dto.Role = roles.FirstOrDefault() ?? "Unknown";

            return new ApiResponse<UserProfileResponseDto>(dto);
        }

        public async Task<ApiResponse<UserProfileResponseDto>> UpdateMyProfileAsync( UserProfileRequestDto dto)
        {
            var userId = _userAccessor.GetUserId();

            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                return new ApiResponse<UserProfileResponseDto>("Kullanıcı bulunamadı");

            _mapper.Map(dto, user);
            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
                return new ApiResponse<UserProfileResponseDto>("Güncelleme başarısız");

            var roles = await _userManager.GetRolesAsync(user);
            var responseDto = _mapper.Map<UserProfileResponseDto>(user);
            responseDto.Role = roles.FirstOrDefault() ?? "Unknown";

            return new ApiResponse<UserProfileResponseDto>(responseDto);
        }

        public async Task<ApiResponse<List<UserProfileResponseDto>>> GetAllUsersAsync()
        {
            var users = _userManager.Users.ToList();
            var dtoList = _mapper.Map<List<UserProfileResponseDto>>(users);

            foreach (var dto in dtoList)
            {
                var user = await _userManager.FindByIdAsync(dto.Id.ToString());
                var roles = await _userManager.GetRolesAsync(user);
                dto.Role = roles.FirstOrDefault() ?? "Unknown";
            }

            return new ApiResponse<List<UserProfileResponseDto>>(dtoList);
        }

        public async Task<ApiResponse> DeleteUserAsync(long userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                return new ApiResponse("Kullanıcı bulunamadı");

            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded
                ? new ApiResponse() 
                : new ApiResponse("Kullanıcı silinemedi");
        }

        public async Task<ApiResponse<UserProfileResponseDto>> UpdateUserAsync(long userId, UserProfileRequestDto dto)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                return new ApiResponse<UserProfileResponseDto>("Kullanıcı bulunamadı");

            _mapper.Map(dto, user);
            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
                return new ApiResponse<UserProfileResponseDto>("Güncelleme başarısız");

            var roles = await _userManager.GetRolesAsync(user);
            var responseDto = _mapper.Map<UserProfileResponseDto>(user);
            responseDto.Role = roles.FirstOrDefault() ?? "Unknown";

            return new ApiResponse<UserProfileResponseDto>(responseDto);
        }
    }
}
