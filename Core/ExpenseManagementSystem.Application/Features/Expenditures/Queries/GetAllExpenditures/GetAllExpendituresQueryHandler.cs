using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Dtos.Expenditure;
using MediatR;


namespace ExpenseManagementSystem.Application.Features.Expenditures.Queries.GetAllExpenditures
{
    public class GetAllExpendituresQueryHandler : IRequestHandler<GetAllExpendituresQuery, List<ExpenditureResponseDto>>
    {
        private readonly IExpenditureQueryService _expenditureQueryService;

        public GetAllExpendituresQueryHandler(IExpenditureQueryService expenditureQueryService)
        {
            _expenditureQueryService = expenditureQueryService;
        }

        public async Task<List<ExpenditureResponseDto>> Handle(GetAllExpendituresQuery request, CancellationToken cancellationToken)
        {
            return await _expenditureQueryService.GetAllAsync();
        }
    }
}
