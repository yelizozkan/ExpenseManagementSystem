using ExpenseManagementSystem.Application.Dtos.ExpenseStatus;
using MediatR;

namespace ExpenseManagementSystem.Application.Features.ExpenseStatuses.Commands.UpdateExpenseStatus
{
    public class UpdateExpenseStatusCommand : IRequest<ExpenseStatusResponseDto>
    {
        public long Id { get; set; }
        public ExpenseStatusRequestDto Model { get; set; }

        public UpdateExpenseStatusCommand(long id, ExpenseStatusRequestDto model)
        {
            Id = id;
            Model = model;
        }
    }
}
