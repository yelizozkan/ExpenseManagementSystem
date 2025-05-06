using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Dtos.Expense;
using MediatR;


namespace ExpenseManagementSystem.Application.Features.Expenses.Commands.RejectExpense
{
    public class RejectExpenseCommandHandler : IRequestHandler<RejectExpenseCommand, ExpenseResponseDto>
    {
        private readonly IExpenseService _expenseService;

        public RejectExpenseCommandHandler(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        public async Task<ExpenseResponseDto> Handle(RejectExpenseCommand request, CancellationToken cancellationToken)
        {
            return await _expenseService.RejectAsync(request.ExpenseId, request.RejectionNote);
        }
    }
}
