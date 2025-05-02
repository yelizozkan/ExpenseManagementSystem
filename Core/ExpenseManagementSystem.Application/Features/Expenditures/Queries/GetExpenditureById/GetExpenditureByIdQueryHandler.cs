using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Dtos.Expenditure;
using MediatR;


namespace ExpenseManagementSystem.Application.Features.Expenditures.Queries.GetExpenditureById
{
    public class GetExpenditureByIdQueryHandler : IRequestHandler<GetExpenditureByIdQuery, ExpenditureResponseDto>
    {
        private readonly IExpenditureQueryService _expenditureQueryService;

        public GetExpenditureByIdQueryHandler(IExpenditureQueryService expenditureQueryService)
        {
            _expenditureQueryService = expenditureQueryService;
        }

        public async Task<ExpenditureResponseDto> Handle(GetExpenditureByIdQuery request, CancellationToken cancellationToken)
        {
            return await _expenditureQueryService.GetByIdAsync(request.Id);
        }
    }
}
