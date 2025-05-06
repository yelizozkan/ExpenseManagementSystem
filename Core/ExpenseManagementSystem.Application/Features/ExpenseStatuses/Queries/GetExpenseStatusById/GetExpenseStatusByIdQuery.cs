using ExpenseManagementSystem.Application.Dtos.ExpenseStatus;
using MediatR;


namespace ExpenseManagementSystem.Application.Features.ExpenseStatuses.Queries.GetExpenseStatusById
{
    public class GetExpenseStatusByIdQuery : IRequest<ExpenseStatusResponseDto?>
    {
        public long Id { get; set; }

        public GetExpenseStatusByIdQuery(long id)
        {
            Id = id;
        }
    }
}
