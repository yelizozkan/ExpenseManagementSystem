using ExpenseManagementSystem.Application.Dtos.User;
using ExpenseManagementSystem.Application.Responses;
using MediatR;


namespace ExpenseManagementSystem.Application.Features.Users.Commands.AssignRole
{
    public class AssignRoleCommand : IRequest<ApiResponse>
    {
        public AssignRoleRequestDto Model { get; }

        public AssignRoleCommand(AssignRoleRequestDto model)
        {
            Model = model;
        }
    }
}
