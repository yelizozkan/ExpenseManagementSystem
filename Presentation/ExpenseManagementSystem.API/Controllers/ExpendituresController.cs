using ExpenseManagementSystem.Application.Dtos.Expenditure;
using ExpenseManagementSystem.Application.Features.Expenditures.Commands.ApproveExpenditure;
using ExpenseManagementSystem.Application.Features.Expenditures.Commands.CreateExpenditure;
using ExpenseManagementSystem.Application.Features.Expenditures.Commands.DeleteExpenditure;
using ExpenseManagementSystem.Application.Features.Expenditures.Commands.RejectExpenditure;
using ExpenseManagementSystem.Application.Features.Expenditures.Commands.UpdateExpenditure;
using ExpenseManagementSystem.Application.Features.Expenditures.Queries.GetAllExpenditures;
using ExpenseManagementSystem.Application.Features.Expenditures.Queries.GetExpenditureById;
using ExpenseManagementSystem.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ExpendituresController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExpendituresController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("GetAll")]
        [Authorize(Roles = "Admin,Personnel")]
        public async Task<ApiResponse<List<ExpenditureResponseDto>>> GetAll()
        {
            var query = new GetAllExpendituresQuery();
            var result = await _mediator.Send(query);
            return new ApiResponse<List<ExpenditureResponseDto>>(result);
        }


        [HttpGet("GetById/{id}")]
        [Authorize(Roles = "Admin,Personnel")]
        public async Task<ApiResponse<ExpenditureResponseDto>> GetById([FromRoute] long id)
        {
            var query = new GetExpenditureByIdQuery(id);
            var result = await _mediator.Send(query);
            return new ApiResponse<ExpenditureResponseDto>(result);
        }


        [HttpPost]
        [Authorize(Roles = "Admin,Personnel")]
        public async Task<ApiResponse<ExpenditureResponseDto>> Post([FromForm] ExpenditureRequestDto model)
        {
            var command = new CreateExpenditureCommand(model);
            var result = await _mediator.Send(command);
            return new ApiResponse<ExpenditureResponseDto>(result);
        }


        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Personnel")]
        public async Task<ApiResponse<ExpenditureResponseDto>> Put([FromRoute] long id, [FromBody] ExpenditureRequestDto model)
        {
            var command = new UpdateExpenditureCommand(id, model);
            var result = await _mediator.Send(command);
            return new ApiResponse<ExpenditureResponseDto>(result);
        }


        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Personnel")]
        public async Task<ApiResponse> Delete([FromRoute] long id)
        {
           var command = new DeleteExpenditureCommand(id);
            var result = await _mediator.Send(command);
           return result
                ? new ApiResponse("Harcama kaydı silindi", true)
                : new ApiResponse("Harcama kaydı bulunamadı veya zaten silinmiş", false);
        }

        
        [HttpPost("{id}/approve")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Approve(long id, [FromBody] ApproveExpenditureCommand command)
        {
            if (id <= 0)
                return BadRequest("Geçersiz ID");

            command.Id = id;

            var result = await _mediator.Send(command);
            return Ok(new ApiResponse<ExpenditureResponseDto>(result));
        }


        [HttpPost("{id}/reject")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Reject(long id, [FromBody] RejectExpenditureCommand command)
        {
            if (id <= 0)
                return BadRequest("Geçersiz ID");

            command.Id = id;

            var result = await _mediator.Send(command);
            return Ok(new ApiResponse<ExpenditureResponseDto>(result));
        }

    }
}
