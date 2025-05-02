using ExpenseManagementSystem.Application.Dtos.Expense;
using MediatR;


namespace ExpenseManagementSystem.Application.Features.Expenses.Queries.GetAllExpenses
{
    public class GetAllExpensesQuery : IRequest<List<ExpenseResponseDto>>
    {
    }
}
