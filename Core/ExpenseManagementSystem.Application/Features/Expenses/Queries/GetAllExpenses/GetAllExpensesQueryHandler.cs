using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Dtos.Expense;
using MediatR;


namespace ExpenseManagementSystem.Application.Features.Expenses.Queries.GetAllExpenses
{
    public class GetAllExpensesQueryHandler : IRequestHandler<GetAllExpensesQuery, List<ExpenseResponseDto>>
    {
        private readonly IExpenseQueryService _expenseQueryService;

        public GetAllExpensesQueryHandler(IExpenseQueryService expenseQueryService)
        {
            _expenseQueryService = expenseQueryService;
        }

        public async Task<List<ExpenseResponseDto>> Handle(GetAllExpensesQuery request, CancellationToken cancellationToken)
        {
            return await _expenseQueryService.GetAllAsync();
        }
    }
}
