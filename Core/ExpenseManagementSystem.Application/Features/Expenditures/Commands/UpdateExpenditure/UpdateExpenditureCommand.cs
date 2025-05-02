using ExpenseManagementSystem.Application.Dtos.Expenditure;
using MediatR;


namespace ExpenseManagementSystem.Application.Features.Expenditures.Commands.UpdateExpenditure
{
    public class UpdateExpenditureCommand : IRequest<ExpenditureResponseDto>
    {
        public long Id { get; set; }
        public ExpenditureRequestDto Model { get; set; }

        public UpdateExpenditureCommand(long id, ExpenditureRequestDto model)
        {
            Id = id;
            Model = model;
        }
    }
}
