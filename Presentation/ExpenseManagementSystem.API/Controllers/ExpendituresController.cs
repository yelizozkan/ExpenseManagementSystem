using ExpenseManagementSystem.Application.Dtos.Expenditure;
using ExpenseManagementSystem.Application.Features.Expenditures.Commands.CreateExpenditure;
using ExpenseManagementSystem.Application.Features.Expenditures.Commands.DeleteExpenditure;
using ExpenseManagementSystem.Application.Features.Expenditures.Commands.UpdateExpenditure;
using ExpenseManagementSystem.Application.Features.Expenditures.Queries.GetAllExpenditures;
using ExpenseManagementSystem.Application.Features.Expenditures.Queries.GetExpenditureById;
using ExpenseManagementSystem.Application.Features.Expenditures.Queries.GetExpenditureByParameter;
using ExpenseManagementSystem.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpendituresController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExpendituresController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("GetAll")]
        //[Authorize(Roles = "admin,user")]
        public async Task<ApiResponse<List<ExpenditureResponseDto>>> GetAll()
        {
            var query = new GetAllExpendituresQuery();
            var result = await _mediator.Send(query);
            return new ApiResponse<List<ExpenditureResponseDto>>(result);
        }


        [HttpGet("GetById/{id}")]
        //[Authorize(Roles = "admin,user")]
        public async Task<ApiResponse<ExpenditureResponseDto>> GetById([FromRoute] long id)
        {
            var query = new GetExpenditureByIdQuery(id);
            var result = await _mediator.Send(query);
            return new ApiResponse<ExpenditureResponseDto>(result);
        }


        [HttpGet("ByParameters")]
        ////[Authorize(Roles = "admin,user")]
        public async Task<ApiResponse<List<ExpenditureResponseDto>>> GetByParameters(
            [FromQuery] long? expenseId, [FromQuery] long? categoryId, [FromQuery] DateTime? date)
        {
           var model = new GetExpenditureByParameterRequestDto
            {
                ExpenseId = expenseId,
                CategoryId = categoryId,
                Date = date
            };

            var query = new GetExpenditureByParameterQuery(model);
            var result = await _mediator.Send(query);
            return new ApiResponse<List<ExpenditureResponseDto>>(result);
        }


        [HttpPost]
        //[Authorize(Roles = "admin,user")]
        public async Task<ApiResponse<ExpenditureResponseDto>> Post(
            [FromForm] ExpenditureRequestDto model)
        {
           
            var command = new CreateExpenditureCommand(model);
            var result = await _mediator.Send(command);
            return new ApiResponse<ExpenditureResponseDto>(result);
        }


        [HttpPut("{id}")]
        //[Authorize(Roles = "admin,user")]
        public async Task<ApiResponse<ExpenditureResponseDto>> Put([FromRoute] long id, [FromBody] ExpenditureRequestDto model)
        {
            var command = new UpdateExpenditureCommand(id, model);
            var result = await _mediator.Send(command);
            return new ApiResponse<ExpenditureResponseDto>(result);
        }


        [HttpDelete("{id}")]
        ////[Authorize(Roles = "admin")]
        public async Task<ApiResponse> Delete([FromRoute] long id)
        {
           var command = new DeleteExpenditureCommand(id);
            var result = await _mediator.Send(command);
           return result
                ? new ApiResponse("Harcama kaydı silindi", true)
                : new ApiResponse("Harcama kaydı bulunamadı veya zaten silinmiş", false);
        }
    }
}
