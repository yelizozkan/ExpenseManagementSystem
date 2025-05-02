using ExpenseManagementSystem.Application.Dtos.Expenditure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Application.Features.Expenditures.Queries.GetExpenditureById
{
    public class GetExpenditureByIdQuery : IRequest<ExpenditureResponseDto>
    {
        public long Id { get; set; }

        public GetExpenditureByIdQuery(long id)
        {
            Id = id;
        }
    }
}
