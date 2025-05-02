using ExpenseManagementSystem.Application.Dtos.Expenditure;
using MediatR;


namespace ExpenseManagementSystem.Application.Features.Expenditures.Queries.GetAllExpenditures
{
    public class GetAllExpendituresQuery : IRequest<List<ExpenditureResponseDto>> 
    {
    }
}
