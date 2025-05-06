using ExpenseManagementSystem.Application.Dtos.User;
using ExpenseManagementSystem.Application.Responses;
using MediatR;

namespace ExpenseManagementSystem.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<ApiResponse<UserProfileResponseDto>>
    {
        public long UserId { get; }
        public UserProfileRequestDto Dto { get; }

        public UpdateUserCommand(long userId, UserProfileRequestDto dto)
        {
            UserId = userId;
            Dto = dto;
        }
    }
}
