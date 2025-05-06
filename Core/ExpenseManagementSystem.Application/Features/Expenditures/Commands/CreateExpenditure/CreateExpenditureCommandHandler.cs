using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Dtos.Expenditure;
using MediatR;


namespace ExpenseManagementSystem.Application.Features.Expenditures.Commands.CreateExpenditure
{
    public class CreateExpenditureCommandHandler : IRequestHandler<CreateExpenditureCommand, ExpenditureResponseDto>
    {
        private readonly IExpenditureService _expenditureService;

        public CreateExpenditureCommandHandler(IExpenditureService expenditureService)
        {
            _expenditureService = expenditureService;
        }

        public async Task<ExpenditureResponseDto> Handle(CreateExpenditureCommand request, CancellationToken cancellationToken)
        {
            return await _expenditureService.CreateAsync(request.Model);
        }
    }
}
