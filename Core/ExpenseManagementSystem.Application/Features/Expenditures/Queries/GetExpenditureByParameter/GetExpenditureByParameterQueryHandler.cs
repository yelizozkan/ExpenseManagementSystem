using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Dtos.Expenditure;
using MediatR;


namespace ExpenseManagementSystem.Application.Features.Expenditures.Queries.GetExpenditureByParameter
{
    public class GetExpenditureByParameterQueryHandler : IRequestHandler<GetExpenditureByParameterQuery, List<ExpenditureResponseDto>>
    {
        private readonly IExpenditureQueryService _expenditureQueryService;

        public GetExpenditureByParameterQueryHandler(IExpenditureQueryService expenditureQueryService)
        {
            _expenditureQueryService = expenditureQueryService;
        }

        public async Task<List<ExpenditureResponseDto>> Handle(GetExpenditureByParameterQuery request, CancellationToken cancellationToken)
        {
            var model = request.Model;

            return await _expenditureQueryService.GetByParameterAsync(
                model.ExpenseId,
                model.CategoryId,
                model.Date
            );
        }
    }
}
