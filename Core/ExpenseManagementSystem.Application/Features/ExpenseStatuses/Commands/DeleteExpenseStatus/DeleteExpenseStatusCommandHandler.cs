using ExpenseManagementSystem.Application.Abstractions.Services;
using MediatR;

namespace ExpenseManagementSystem.Application.Features.ExpenseStatuses.Commands.DeleteExpenseStatus
{
    public class DeleteExpenseStatusCommandHandler : IRequestHandler<DeleteExpenseStatusCommand, bool>
    {
        private readonly IExpenseStatusService _expenseStatusService;

        public DeleteExpenseStatusCommandHandler(IExpenseStatusService expenseStatusService)
        {
            _expenseStatusService = expenseStatusService;
        }

        public async Task<bool> Handle(DeleteExpenseStatusCommand request, CancellationToken cancellationToken)
        {
            return await _expenseStatusService.SoftDeleteAsync(request.Id);
        }
    }
}
