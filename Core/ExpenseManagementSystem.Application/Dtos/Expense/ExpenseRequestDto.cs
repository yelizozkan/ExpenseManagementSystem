
namespace ExpenseManagementSystem.Application.Dtos.Expense
{
    public class ExpenseRequestDto
    {
        public string? Description { get; set; }
        public decimal Total { get; set; }
        public long? PaymentId { get; set; }
    }
}
