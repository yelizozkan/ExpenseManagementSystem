using ExpenseManagementSystem.Application.Dtos.Expenditure;

namespace ExpenseManagementSystem.Application.Dtos.Expense
{
    public class ExpenseResponseDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime SubmissionDate { get; set; }
        public string? Description { get; set; }
        public long StatusId { get; set; }
        public string StatusName { get; set; }
        public decimal Total { get; set; }
        public List<ExpenditureResponseDto>? Expenditures { get; set; }

    }
}
