using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Dtos.User;
using ExpenseManagementSystem.Application.Responses;
using MediatR;

namespace ExpenseManagementSystem.Application.Features.Users.Queries.GetUserProfile
{
    public class GetUserProfileQueryHandler : IRequestHandler<GetUserProfileQuery, ApiResponse<UserProfileResponseDto>>
    {
        private readonly IUserService _userService;

        public GetUserProfileQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<ApiResponse<UserProfileResponseDto>> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetProfileAsync();
        }
    }

}
