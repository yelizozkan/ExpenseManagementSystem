using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Dtos.ExpenseStatus;
using MediatR;

namespace ExpenseManagementSystem.Application.Features.ExpenseStatuses.Commands.CreateExpenseStatus
{
    public class CreateExpenseStatusCommandHandler : IRequestHandler<CreateExpenseStatusCommand, ExpenseStatusResponseDto>
    {
        private readonly IExpenseStatusService _expenseStatusService;

        public CreateExpenseStatusCommandHandler(IExpenseStatusService expenseStatusService)
        {
            _expenseStatusService = expenseStatusService;
        }

        public async Task<ExpenseStatusResponseDto> Handle(CreateExpenseStatusCommand request, CancellationToken cancellationToken)
        {
            return await _expenseStatusService.CreateAsync(request.Model);
        }
    }
}
