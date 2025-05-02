using ExpenseManagementSystem.Application.Dtos.Auth;
using ExpenseManagementSystem.Application.Dtos;
using MediatR;


namespace ExpenseManagementSystem.Application.Features.Auth.Commands.Register
{
    public class RegisterCommand : IRequest<TokenDto>
    {
        public RegisterRequestDto Model { get; }

        public RegisterCommand(RegisterRequestDto model)
        {
            Model = model;
        }
    }
}
