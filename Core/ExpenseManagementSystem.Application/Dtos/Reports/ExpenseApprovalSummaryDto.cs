
namespace ExpenseManagementSystem.Application.Dtos.Reports
{
    public class ExpenseApprovalSummaryDto
    {
        public DateTime Date { get; set; }
        public string StatusName { get; set; } 
        public decimal TotalAmount { get; set; }
        public int Count { get; set; }
    }

}
