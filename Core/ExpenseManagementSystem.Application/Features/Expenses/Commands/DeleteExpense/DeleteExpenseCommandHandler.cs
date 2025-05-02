using ExpenseManagementSystem.Application.Abstractions.Services;
using MediatR;


namespace ExpenseManagementSystem.Application.Features.Expenses.Commands.DeleteExpense
{
    public class DeleteExpenseCommandHandler : IRequestHandler<DeleteExpenseCommand, bool>
    {
        private readonly IExpenseService _expenseService;

        public DeleteExpenseCommandHandler(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        public async Task<bool> Handle(DeleteExpenseCommand request, CancellationToken cancellationToken)
        {
            return await _expenseService.DeleteAsync(request.Id);
        }
    }
}
