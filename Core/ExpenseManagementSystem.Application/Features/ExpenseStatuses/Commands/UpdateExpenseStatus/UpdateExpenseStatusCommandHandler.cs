using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Dtos.ExpenseStatus;
using MediatR;

namespace ExpenseManagementSystem.Application.Features.ExpenseStatuses.Commands.UpdateExpenseStatus
{
    public class UpdateExpenseStatusCommandHandler : IRequestHandler<UpdateExpenseStatusCommand, ExpenseStatusResponseDto>
    {
        private readonly IExpenseStatusService _expenseStatusService;


        public UpdateExpenseStatusCommandHandler(IExpenseStatusService expenseStatusService)
        {
            _expenseStatusService = expenseStatusService;
        }

        public async Task<ExpenseStatusResponseDto> Handle(UpdateExpenseStatusCommand request, CancellationToken cancellationToken)
        {
            return await _expenseStatusService.UpdateAsync(request.Id, request.Model);
        }
    }
}
