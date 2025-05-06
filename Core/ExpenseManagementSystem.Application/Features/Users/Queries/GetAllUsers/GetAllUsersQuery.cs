using ExpenseManagementSystem.Application.Dtos.User;
using ExpenseManagementSystem.Application.Responses;
using MediatR;


namespace ExpenseManagementSystem.Application.Features.Users.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<ApiResponse<List<UserProfileResponseDto>>>
    {
    }

}
