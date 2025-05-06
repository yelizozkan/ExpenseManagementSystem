using ExpenseManagementSystem.Application.Dtos.Auth;
using ExpenseManagementSystem.Application.Responses;
using MediatR;

namespace ExpenseManagementSystem.Application.Features.Auth.Commands.Login
{
    public class LoginCommand : IRequest<ApiResponse<TokenDto>>
    {
        public LoginRequestDto Model { get; set; }

        public LoginCommand(LoginRequestDto model)
        {
            Model = model;
        }
    }
}
