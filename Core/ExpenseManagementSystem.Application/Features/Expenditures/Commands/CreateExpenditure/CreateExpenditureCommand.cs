using ExpenseManagementSystem.Application.Dtos.Expenditure;
using MediatR;


namespace ExpenseManagementSystem.Application.Features.Expenditures.Commands.CreateExpenditure
{
    public class CreateExpenditureCommand : IRequest<ExpenditureResponseDto>
    {
        public ExpenditureRequestDto Model { get; set; }

        public CreateExpenditureCommand(ExpenditureRequestDto model)
        {
            Model = model;
        }
    }
}
