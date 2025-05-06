using ExpenseManagementSystem.Application.Dtos.User;
using ExpenseManagementSystem.Application.Responses;
using MediatR;

namespace ExpenseManagementSystem.Application.Features.Users.Commands.UpdateUserProfile
{
    public class UpdateUserProfileCommand : IRequest<ApiResponse<UserProfileResponseDto>>
    {
        public long UserId { get; }
        public UserProfileRequestDto Model { get; }

        public UpdateUserProfileCommand(long userId, UserProfileRequestDto model)
        {
            UserId = userId;
            Model = model;
        }
    }

}
