using ExpenseManagementSystem.Application.Responses;
using MediatR;

namespace ExpenseManagementSystem.Application.Features.Users.Commands.DeleteUserProfile
{
    public class DeleteUserCommand : IRequest<ApiResponse>
    {
        public long UserId { get; }

        public DeleteUserCommand(long userId)
        {
            UserId = userId;
        }
    }

}
