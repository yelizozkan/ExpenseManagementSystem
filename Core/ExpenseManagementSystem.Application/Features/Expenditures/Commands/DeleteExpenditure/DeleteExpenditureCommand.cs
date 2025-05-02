using MediatR;


namespace ExpenseManagementSystem.Application.Features.Expenditures.Commands.DeleteExpenditure
{
    public class DeleteExpenditureCommand : IRequest<bool>
    {
        public long Id { get; set; }

        public DeleteExpenditureCommand(long id)
        {
            Id = id;
        }
    }
}
