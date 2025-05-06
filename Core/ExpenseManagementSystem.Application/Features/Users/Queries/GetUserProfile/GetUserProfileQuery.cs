using ExpenseManagementSystem.Application.Dtos.User;
using ExpenseManagementSystem.Application.Responses;
using MediatR;

namespace ExpenseManagementSystem.Application.Features.Users.Queries.GetUserProfile
{
    public class GetUserProfileQuery : IRequest<ApiResponse<UserProfileResponseDto>>
    {
        public long UserId { get; }

        public GetUserProfileQuery(long userId)
        {
            UserId = userId;
        }
    }

}
