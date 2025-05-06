using ExpenseManagementSystem.Application.Responses;
using MediatR;

namespace ExpenseManagementSystem.Application.Features.Expenditures.Commands.ApproveExpenditure
{
    public class ApproveExpenditureCommand : IRequest<ApiResponse>
    {
        public long Id { get; set; }

        public ApproveExpenditureCommand(long id)
        {
            Id = id;
        }
    }
}
