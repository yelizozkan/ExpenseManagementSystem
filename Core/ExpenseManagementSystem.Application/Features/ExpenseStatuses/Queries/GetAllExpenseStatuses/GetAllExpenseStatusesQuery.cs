using ExpenseManagementSystem.Application.Dtos.ExpenseStatus;
using MediatR;


namespace ExpenseManagementSystem.Application.Features.ExpenseStatuses.Queries.GetAllExpenseStatuses
{
    public class GetAllExpenseStatusesQuery : IRequest<List<ExpenseStatusResponseDto>>
    {
    }
}
