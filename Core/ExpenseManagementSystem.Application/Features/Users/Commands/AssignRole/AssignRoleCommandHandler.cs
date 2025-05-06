using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Responses;
using MediatR;

namespace ExpenseManagementSystem.Application.Features.Users.Commands.AssignRole
{
    public class AssignRoleCommandHandler : IRequestHandler<AssignRoleCommand, ApiResponse>
    {
        private readonly IUserRoleService _userRoleService;

        public AssignRoleCommandHandler(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        public async Task<ApiResponse> Handle(AssignRoleCommand request, CancellationToken cancellationToken)
        {
            return await _userRoleService.AssignRoleAsync(request.Model);
        }
    }
}
