using ExpenseManagementSystem.Application.Dtos.Expenditure;
using MediatR;

namespace ExpenseManagementSystem.Application.Features.Expenditures.Queries.GetExpenditureById
{
    public class GetExpenditureByIdQuery : IRequest<ExpenditureResponseDto>
    {
        public long Id { get; set; }

        public GetExpenditureByIdQuery(long id)
        {
            Id = id;
        }
    }
}
