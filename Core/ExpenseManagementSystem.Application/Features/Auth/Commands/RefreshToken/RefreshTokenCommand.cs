using ExpenseManagementSystem.Application.Dtos.Auth;
using ExpenseManagementSystem.Application.Responses;
using MediatR;

namespace ExpenseManagementSystem.Application.Features.Auth.Commands.RefreshToken
{
    public class RefreshTokenCommand : IRequest<ApiResponse<TokenDto>>
    {
        public RefreshTokenRequestDto Model { get; }

        public RefreshTokenCommand(RefreshTokenRequestDto model)
        {
            Model = model;
        }
    }
}
