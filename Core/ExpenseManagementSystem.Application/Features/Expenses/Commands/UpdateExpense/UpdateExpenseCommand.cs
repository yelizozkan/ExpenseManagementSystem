using ExpenseManagementSystem.Application.Dtos.Expense;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Application.Features.Expenses.Commands.UpdateExpense
{
    public class UpdateExpenseCommand : IRequest<ExpenseResponseDto>
    {
        public long Id { get; set; }
        public ExpenseRequestDto Model { get; set; }

        public UpdateExpenseCommand(long id, ExpenseRequestDto model)
        {
            Id = id;
            Model = model;
        }
    }
}
