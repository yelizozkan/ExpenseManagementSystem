using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Dtos.ExpenseStatus;
using MediatR;


namespace ExpenseManagementSystem.Application.Features.ExpenseStatuses.Queries.GetExpenseStatusById
{
    public class GetExpenseStatusByIdQueryHandler : IRequestHandler<GetExpenseStatusByIdQuery, ExpenseStatusResponseDto?>
    {
        private readonly IExpenseStatusQueryService _expenseStatusQueryService;

        public GetExpenseStatusByIdQueryHandler(IExpenseStatusQueryService expenseStatusQueryService)
        {
            _expenseStatusQueryService = expenseStatusQueryService;
        }

        public async Task<ExpenseStatusResponseDto?> Handle(GetExpenseStatusByIdQuery request, CancellationToken cancellationToken)
        {
            return await _expenseStatusQueryService.GetByIdAsync(request.Id);
        }
    }
}
