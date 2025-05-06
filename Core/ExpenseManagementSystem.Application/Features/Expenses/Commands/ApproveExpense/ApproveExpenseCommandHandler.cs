using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Dtos.Expense;
using MediatR;


namespace ExpenseManagementSystem.Application.Features.Expenses.Commands.ApproveExpense
{
    public class ApproveExpenseCommandHandler : IRequestHandler<ApproveExpenseCommand, ExpenseResponseDto>
    {
        private readonly IExpenseService _expenseService;

        public ApproveExpenseCommandHandler(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        public async Task<ExpenseResponseDto> Handle(ApproveExpenseCommand request, CancellationToken cancellationToken)
        {
            return await _expenseService.ApproveAsync(request.ExpenseId, request.Note);
        }
    }
}
