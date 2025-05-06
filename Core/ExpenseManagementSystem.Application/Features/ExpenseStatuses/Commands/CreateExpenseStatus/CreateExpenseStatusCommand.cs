using ExpenseManagementSystem.Application.Dtos.ExpenseStatus;
using MediatR;

namespace ExpenseManagementSystem.Application.Features.ExpenseStatuses.Commands.CreateExpenseStatus
{
    public class CreateExpenseStatusCommand : IRequest<ExpenseStatusResponseDto>
    {
        public ExpenseStatusRequestDto Model { get; set; }

        public CreateExpenseStatusCommand(ExpenseStatusRequestDto model)
        {
            Model = model;
        }
    }
}
