namespace ExpenseManagementSystem.Application.Dtos.Expense
{
    public class ExpenseRequestDto
    {
        public string? Description { get; set; }
        public long CategoryId { get; set; }
    }
}
