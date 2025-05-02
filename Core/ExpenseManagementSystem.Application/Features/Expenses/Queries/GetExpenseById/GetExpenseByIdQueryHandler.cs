using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Dtos.Expense;
using MediatR;


namespace ExpenseManagementSystem.Application.Features.Expenses.Queries.GetExpenseById
{
    public class GetExpenseByIdQueryHandler : IRequestHandler<GetExpenseByIdQuery, ExpenseResponseDto>
    {
        private readonly IExpenseQueryService _expenseQueryService;

        public GetExpenseByIdQueryHandler(IExpenseQueryService expenseQueryService)
        {
            _expenseQueryService = expenseQueryService;
        }

        public async Task<ExpenseResponseDto> Handle(GetExpenseByIdQuery request, CancellationToken cancellationToken)
        {
            return await _expenseQueryService.GetByIdAsync(request.Id);
        }
    }
}
