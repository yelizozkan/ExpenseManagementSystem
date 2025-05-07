using ExpenseManagementSystem.Application.Dtos.Expenditure;
using MediatR;
using System.Text.Json.Serialization;

namespace ExpenseManagementSystem.Application.Features.Expenditures.Commands.ApproveExpenditure
{
    public class ApproveExpenditureCommand : IRequest<ExpenditureResponseDto>
    {
        [JsonIgnore]
        public long Id { get; set; }
        public string? ApprovalNote { get; set; }

    }
}
