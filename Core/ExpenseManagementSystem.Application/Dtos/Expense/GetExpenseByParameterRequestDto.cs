
namespace ExpenseManagementSystem.Application.Dtos.Expense
{
    public class GetExpenseByParameterRequestDto
    {
        public long? UserId { get; set; }
        public long? StatusId { get; set; }
        public DateTime? SubmissionDateStart { get; set; }
        public DateTime? SubmissionDateEnd { get; set; }
        public decimal? MinTotal { get; set; }
        public decimal? MaxTotal { get; set; }
        public long? ApprovedById { get; set; }
    }
}
