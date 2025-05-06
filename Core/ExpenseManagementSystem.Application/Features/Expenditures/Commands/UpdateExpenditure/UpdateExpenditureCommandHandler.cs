using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Dtos.Expenditure;
using MediatR;


namespace ExpenseManagementSystem.Application.Features.Expenditures.Commands.UpdateExpenditure
{
    public class UpdateExpenditureCommandHandler : IRequestHandler<UpdateExpenditureCommand, ExpenditureResponseDto>
    {
        private readonly IExpenditureService _expenditureService;

        public UpdateExpenditureCommandHandler(IExpenditureService expenditureService)
        {
            _expenditureService = expenditureService;
        }

        public async Task<ExpenditureResponseDto> Handle(UpdateExpenditureCommand request, CancellationToken cancellationToken)
        {
            return await _expenditureService.UpdateAsync(request.Id, request.Model);
        }
    }
}
