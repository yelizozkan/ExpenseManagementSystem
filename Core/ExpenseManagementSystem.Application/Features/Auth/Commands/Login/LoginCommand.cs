using ExpenseManagementSystem.Application.Dtos.Auth;
using ExpenseManagementSystem.Application.Dtos;
using MediatR;


namespace ExpenseManagementSystem.Application.Features.Auth.Commands.Login
{
    public class LoginCommand : IRequest<TokenDto>
    {
        public LoginRequestDto Model { get; set; }

        public LoginCommand(LoginRequestDto model)
        {
            Model = model;
        }
    }
}
