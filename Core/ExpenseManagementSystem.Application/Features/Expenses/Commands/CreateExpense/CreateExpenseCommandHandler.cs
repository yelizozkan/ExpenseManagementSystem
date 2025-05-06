using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Dtos.Expense;
using MediatR;


namespace ExpenseManagementSystem.Application.Features.Expenses.Commands.CreateExpense
{
    public class CreateExpenseCommandHandler : IRequestHandler<CreateExpenseCommand, ExpenseResponseDto>
    {
        private readonly IExpenseService _expenseService;

        public CreateExpenseCommandHandler(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        public async Task<ExpenseResponseDto> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
        {
            return await _expenseService.CreateAsync(request.Model);
        }
    }
}
