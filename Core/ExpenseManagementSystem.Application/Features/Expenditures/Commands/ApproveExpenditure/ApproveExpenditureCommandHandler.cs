using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Dtos.Expenditure;
using MediatR;


namespace ExpenseManagementSystem.Application.Features.Expenditures.Commands.ApproveExpenditure
{
    public class ApproveExpenditureCommandHandler : IRequestHandler<ApproveExpenditureCommand, ExpenditureResponseDto>
    {
        private readonly IExpenditureService _expenditureService;

        public ApproveExpenditureCommandHandler(IExpenditureService expenditureService)
        {
            _expenditureService = expenditureService;
        }

        public async Task<ExpenditureResponseDto> Handle(ApproveExpenditureCommand request, CancellationToken cancellationToken)
        {
            return await _expenditureService.ApproveExpenditureAsync(request.Id, request.ApprovalNote);
        }
    }
}
