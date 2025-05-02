using ExpenseManagementSystem.Domain.Entities.Common;

namespace ExpenseManagementSystem.Domain.Entities
{
    public class Payment : BaseEntity
    {
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } = "EFT";
        public string? TransactionReference { get; set; } 
        public string TargetIban { get; set; }    
        public long ExpenseId { get; set; }
        public virtual Expense Expense { get; set; }     
    }

}
