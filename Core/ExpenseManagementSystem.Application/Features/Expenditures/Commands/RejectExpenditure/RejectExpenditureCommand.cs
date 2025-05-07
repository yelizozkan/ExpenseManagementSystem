using ExpenseManagementSystem.Application.Dtos.Expenditure;
using ExpenseManagementSystem.Application.Responses;
using MediatR;
using System.Text.Json.Serialization;

namespace ExpenseManagementSystem.Application.Features.Expenditures.Commands.RejectExpenditure
{
    public class RejectExpenditureCommand : IRequest<ExpenditureResponseDto>
    {
        [JsonIgnore]
        public long Id { get; set; }
        public string? ApprovalNote { get; set; }
    }
}
