using ExpenseManagementSystem.Application.Dtos.User;
using ExpenseManagementSystem.Application.Features.Users.Commands.AssignRole;
using ExpenseManagementSystem.Application.Features.Users.Commands.DeleteUserProfile;
using ExpenseManagementSystem.Application.Features.Users.Commands.UpdateUser;
using ExpenseManagementSystem.Application.Features.Users.Commands.UpdateUserProfile;
using ExpenseManagementSystem.Application.Features.Users.Queries.GetAllUsers;
using ExpenseManagementSystem.Application.Features.Users.Queries.GetUserProfile;
using ExpenseManagementSystem.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ExpenseManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] 
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _mediator.Send(new GetAllUsersQuery());
            return Ok(result);
        }


        [HttpGet("profile")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
                return Unauthorized(new ApiResponse("Kullanıcı kimliği alınamadı."));

            var result = await _mediator.Send(new GetUserProfileQuery(long.Parse(userId)));
            return Ok(result);
        }


        [HttpPut("profile")]
        public async Task<IActionResult> UpdateUserProfile([FromBody] UserProfileRequestDto model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
                return Unauthorized(new ApiResponse("Kullanıcı kimliği alınamadı."));

            var result = await _mediator.Send(new UpdateUserProfileCommand(long.Parse(userId), model));
            return Ok(result);
        }


        [HttpPut("{id:long}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateUser(long id, [FromBody] UserProfileRequestDto dto)
        {
            var result = await _mediator.Send(new UpdateUserCommand(id, dto));
            return Ok(result);
        }


        [HttpDelete("{id:long}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            var result = await _mediator.Send(new DeleteUserCommand(id));
            return Ok(result);
        }


        [HttpPost("assign-role")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AssignRole([FromBody] AssignRoleRequestDto dto)
        {
            var result = await _mediator.Send(new AssignRoleCommand(dto));
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
