using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Responses;
using MediatR;


namespace ExpenseManagementSystem.Application.Features.Expenditures.Commands.ApproveExpenditure
{
    public class ApproveExpenditureCommandHandler : IRequestHandler<ApproveExpenditureCommand, ApiResponse>
    {
        private readonly IExpenditureService _expenditureService;

        public ApproveExpenditureCommandHandler(IExpenditureService expenditureService)
        {
            _expenditureService = expenditureService;
        }

        public async Task<ApiResponse> Handle(ApproveExpenditureCommand request, CancellationToken cancellationToken)
        {
            return await _expenditureService.ApproveForPaymentAsync(request.Id);
        }
    }
}
