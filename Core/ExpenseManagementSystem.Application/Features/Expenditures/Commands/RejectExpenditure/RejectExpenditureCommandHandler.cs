using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Dtos.Expenditure;
using MediatR;

namespace ExpenseManagementSystem.Application.Features.Expenditures.Commands.RejectExpenditure
{
    public class RejectExpenditureCommandHandler : IRequestHandler<RejectExpenditureCommand, ExpenditureResponseDto>
    {
        private readonly IExpenditureService _expenditureService;

        public RejectExpenditureCommandHandler(IExpenditureService expenditureService)
        {
            _expenditureService = expenditureService;
        }

        public async Task<ExpenditureResponseDto> Handle(RejectExpenditureCommand request, CancellationToken cancellationToken)
        {
            return await _expenditureService.RejectExpenditureAsync(request.Id, request.ApprovalNote);
        }
    }
}
