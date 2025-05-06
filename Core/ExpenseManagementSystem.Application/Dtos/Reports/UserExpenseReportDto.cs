namespace ExpenseManagementSystem.Application.Dtos.Reports
{
    public class UserExpenseReportDto
    {
        public string ExpenseTitle { get; set; }
        public string CategoryName { get; set; }
        public DateTime ExpenseDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public List<ExpenditureDto> Expenditures { get; set; }
    }

    public class ExpenditureDto
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public bool IsApproved { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
