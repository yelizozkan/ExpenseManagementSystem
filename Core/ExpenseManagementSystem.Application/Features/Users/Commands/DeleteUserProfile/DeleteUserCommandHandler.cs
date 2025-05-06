using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Responses;
using MediatR;


namespace ExpenseManagementSystem.Application.Features.Users.Commands.DeleteUserProfile
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ApiResponse>
    {
        private readonly IUserService _userService;

        public DeleteUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<ApiResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            return await _userService.DeleteUserAsync(request.UserId);
        }
    }

}
