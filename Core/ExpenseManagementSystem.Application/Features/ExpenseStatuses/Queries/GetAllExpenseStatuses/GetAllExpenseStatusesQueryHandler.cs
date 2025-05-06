using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Dtos.ExpenseStatus;
using MediatR;


namespace ExpenseManagementSystem.Application.Features.ExpenseStatuses.Queries.GetAllExpenseStatuses
{
    public class GetAllExpenseStatusesQueryHandler : IRequestHandler<GetAllExpenseStatusesQuery, List<ExpenseStatusResponseDto>>
    {
        private readonly IExpenseStatusQueryService _expenseStatusQueryService;

        public GetAllExpenseStatusesQueryHandler(IExpenseStatusQueryService expenseStatusQueryService)
        {
            _expenseStatusQueryService = expenseStatusQueryService;
        }

        public async Task<List<ExpenseStatusResponseDto>> Handle(GetAllExpenseStatusesQuery request, CancellationToken cancellationToken)
        {
            return await _expenseStatusQueryService.GetAllAsync();
        }
    }
}
