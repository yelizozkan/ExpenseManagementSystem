using ExpenseManagementSystem.Application.Dtos.Auth;
using ExpenseManagementSystem.Application.Features.Auth.Commands.Login;
using ExpenseManagementSystem.Application.Features.Auth.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ExpenseManagementSystem.Application.Features.Auth.Commands.RefreshToken;

namespace ExpenseManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
        {
            var result = await _mediator.Send(new LoginCommand(model));
            return Ok(result);
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto model)
        {
            var result = await _mediator.Send(new RegisterCommand(model));
            return Created("", result);
        }


        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequestDto model)
        {
            var result = await _mediator.Send(new RefreshTokenCommand(model));
            return Ok(result);
        }
    }
}
