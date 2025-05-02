using ExpenseManagementSystem.Application.Abstractions.Services;
using MediatR;

namespace ExpenseManagementSystem.Application.Features.Expenditures.Commands.DeleteExpenditure
{
    public class DeleteExpenditureCommandHandler : IRequestHandler<DeleteExpenditureCommand, bool>
    {
        private readonly IExpenditureService _expenditureService;

        public DeleteExpenditureCommandHandler(IExpenditureService expenditureService)
        {
            _expenditureService = expenditureService;
        }

        public async Task<bool> Handle(DeleteExpenditureCommand request, CancellationToken cancellationToken)
        {
            return await _expenditureService.SoftDeleteAsync(request.Id);
        }
    }
}
