using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Application.Features.Expenses.Commands.DeleteExpense
{
    public class DeleteExpenseCommand : IRequest<bool>
    {
        public long Id { get; set; }

        public DeleteExpenseCommand(long id)
        {
            Id = id;
        }
    }
}
