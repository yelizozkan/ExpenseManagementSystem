using ExpenseManagementSystem.Application.Dtos.Expense;
using MediatR;


namespace ExpenseManagementSystem.Application.Features.Expenses.Queries.GetExpenseById
{
    public class GetExpenseByIdQuery : IRequest<ExpenseResponseDto>
    {
        public long Id { get; set; }

        public GetExpenseByIdQuery(long id)
        {
            Id = id;
        }
    }
}
