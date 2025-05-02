using ExpenseManagementSystem.Application.Dtos.Expenditure;
using MediatR;


namespace ExpenseManagementSystem.Application.Features.Expenditures.Queries.GetExpenditureByParameter
{
    public class GetExpenditureByParameterQuery : IRequest<List<ExpenditureResponseDto>>
    {
        public GetExpenditureByParameterRequestDto Model { get; set; }

        public GetExpenditureByParameterQuery(GetExpenditureByParameterRequestDto model)
        {
            Model = model;
        }
    }
}
