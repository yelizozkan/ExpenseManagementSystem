using ExpenseManagementSystem.Application.Features.ExpenseStatuses.Commands.CreateExpenseStatus;
using ExpenseManagementSystem.Application.Features.ExpenseStatuses.Commands.DeleteExpenseStatus;
using ExpenseManagementSystem.Application.Features.ExpenseStatuses.Commands.UpdateExpenseStatus;
using ExpenseManagementSystem.Application.Features.ExpenseStatuses.Queries.GetAllExpenseStatuses;
using ExpenseManagementSystem.Application.Features.ExpenseStatuses.Queries.GetExpenseStatusById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ExpenseStatusController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExpenseStatusController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllExpenseStatusesQuery());
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _mediator.Send(new GetExpenseStatusByIdQuery(id));
            return result == null ? NotFound() : Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateExpenseStatusCommand command)
        {
            var result = await _mediator.Send(command);
            return Created("", result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateExpenseStatusCommand command)
        {
            command.Id = id;
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _mediator.Send(new DeleteExpenseStatusCommand(id));
            return Ok(result);
        }
    }
}
