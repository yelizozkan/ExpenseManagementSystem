using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Dtos.User;
using ExpenseManagementSystem.Application.Responses;
using MediatR;

namespace ExpenseManagementSystem.Application.Features.Users.Commands.UpdateUserProfile
{
    public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand, ApiResponse<UserProfileResponseDto>>
    {
        private readonly IUserService _userService;

        public UpdateUserProfileCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<ApiResponse<UserProfileResponseDto>> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
        {
            return await _userService.UpdateMyProfileAsync(request.Model);
        }
    }

}
