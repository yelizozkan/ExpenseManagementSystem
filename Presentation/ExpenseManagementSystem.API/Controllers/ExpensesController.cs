using ExpenseManagementSystem.Application.Dtos.Expense;
using ExpenseManagementSystem.Application.Features.Expenses.Commands.CreateExpense;
using ExpenseManagementSystem.Application.Features.Expenses.Commands.DeleteExpense;
using ExpenseManagementSystem.Application.Features.Expenses.Commands.UpdateExpense;
using ExpenseManagementSystem.Application.Features.Expenses.Queries.GetAllExpenses;
using ExpenseManagementSystem.Application.Features.Expenses.Queries.GetExpenseById;
using ExpenseManagementSystem.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExpensesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExpensesController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllExpensesQuery());
            return Ok(new ApiResponse<List<ExpenseResponseDto>>(result));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _mediator.Send(new GetExpenseByIdQuery(id));
            if (result == null)
                return NotFound(new ApiResponse("Masraf bulunamadı."));

            return Ok(new ApiResponse<ExpenseResponseDto>(result));
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ExpenseRequestDto model)
        {
            var command = new CreateExpenseCommand(model);
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, new ApiResponse<ExpenseResponseDto>(result));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] ExpenseRequestDto model)
        {
            var command = new UpdateExpenseCommand(id, model);
            var result = await _mediator.Send(command);
            return Ok(new ApiResponse<ExpenseResponseDto>(result));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _mediator.Send(new DeleteExpenseCommand(id));
            return result
                ? Ok(new ApiResponse<string>("Masraf başarıyla silindi.", true))
                : NotFound(new ApiResponse<string>("Silinecek masraf bulunamadı.", false));

        }

    }
}
