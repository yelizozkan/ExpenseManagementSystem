using ExpenseManagementSystem.Application.Responses;
using MediatR;

namespace ExpenseManagementSystem.Application.Features.Expenditures.Commands.RejectExpenditure
{
    public class RejectExpenditureCommand : IRequest<ApiResponse>
    {
        public long Id { get; set; }

        public RejectExpenditureCommand(long id)
        {
            Id = id;
        }
    }
}
