using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Dtos.Expense;
using MediatR;


namespace ExpenseManagementSystem.Application.Features.Expenses.Commands.UpdateExpense
{
    public class UpdateExpenseCommandHandler : IRequestHandler<UpdateExpenseCommand, ExpenseResponseDto>
    {
        private readonly IExpenseService _expenseService;

        public UpdateExpenseCommandHandler(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        public async Task<ExpenseResponseDto> Handle(UpdateExpenseCommand request, CancellationToken cancellationToken)
        {
            return await _expenseService.UpdateAsync(request.Id, request.Model);
        }
    }
}
