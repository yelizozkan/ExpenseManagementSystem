﻿using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Dtos.Auth;
using ExpenseManagementSystem.Application.Responses;
using MediatR;

namespace ExpenseManagementSystem.Application.Features.Auth.Commands.RefreshToken
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, ApiResponse<TokenDto>>
    {
        private readonly IAuthService _authService;

        public RefreshTokenCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<ApiResponse<TokenDto>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            return await _authService.RefreshTokenLoginAsync(request.Model);
        }
    }
}
