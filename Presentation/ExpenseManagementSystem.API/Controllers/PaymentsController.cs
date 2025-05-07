using ExpenseManagementSystem.Application.Features.Payments.Commands.CreatePayment;
using ExpenseManagementSystem.Application.Features.Payments.Commands.DeletePayment;
using ExpenseManagementSystem.Application.Features.Payments.Commands.UpdatePayment;
using ExpenseManagementSystem.Application.Features.Payments.Queries.GetAllPayments;
using ExpenseManagementSystem.Application.Features.Payments.Queries.GetPaymentById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        [Authorize(Roles = "Admin,Personnel")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllPaymentsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Personnel")]
        public async Task<IActionResult> GetById(long id)
        {
            var query = new GetPaymentByIdQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] CreatePaymentCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(long id, [FromBody] UpdatePaymentCommand command)
        {
            command.Id = id;
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(long id)
        {
            var command = new DeletePaymentCommand(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}
