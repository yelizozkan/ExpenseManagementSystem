namespace ExpenseManagementSystem.Application.Dtos.Reports
{
    public class PaymentDensityDto
    {
        public DateTime GroupedDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int PaymentCount { get; set; }
        public string EmployeeName { get; set; }
        public string ApproverName { get; set; }
        public string CategoryName { get; set; }
    }
}
