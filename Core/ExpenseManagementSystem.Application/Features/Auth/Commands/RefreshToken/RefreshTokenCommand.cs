using ExpenseManagementSystem.Application.Dtos;
using MediatR;

namespace ExpenseManagementSystem.Application.Features.Auth.Commands.RefreshToken
{
    public class RefreshTokenCommand : IRequest<TokenDto>
    {
        public RefreshTokenRequestDto Model { get; }

        public RefreshTokenCommand(RefreshTokenRequestDto model)
        {
            Model = model;
        }
    }
}
