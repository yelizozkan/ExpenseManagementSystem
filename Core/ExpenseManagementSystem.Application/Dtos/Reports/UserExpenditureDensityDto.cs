namespace ExpenseManagementSystem.Application.Dtos.Reports
{
    public class UserExpenditureDensityDto
    {
        public DateTime Date { get; set; }
        public string UserName { get; set; }
        public decimal TotalAmount { get; set; }
        public int ExpenditureCount { get; set; }
    }

}
