using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Responses;
using MediatR;

namespace ExpenseManagementSystem.Application.Features.Expenditures.Commands.RejectExpenditure
{
    public class RejectExpenditureCommandHandler : IRequestHandler<RejectExpenditureCommand, ApiResponse>
    {
        private readonly IExpenditureService _expenditureService;

        public RejectExpenditureCommandHandler(IExpenditureService expenditureService)
        {
            _expenditureService = expenditureService;
        }

        public async Task<ApiResponse> Handle(RejectExpenditureCommand request, CancellationToken cancellationToken)
        {
            return await _expenditureService.RejectForPaymentAsync(request.Id);
        }
    }
}
