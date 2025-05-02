using ExpenseManagementSystem.Application.Dtos.Expense;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Application.Features.Expenses.Commands.CreateExpense
{
    public class CreateExpenseCommand : IRequest<ExpenseResponseDto>
    {
        public ExpenseRequestDto Model { get; set; }

        public CreateExpenseCommand(ExpenseRequestDto model)
        {
            Model = model;
        }
    }
}
