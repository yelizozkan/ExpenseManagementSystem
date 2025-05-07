using ExpenseManagementSystem.Domain.Entities.Common;
using ExpenseManagementSystem.Domain.Entities.Identity;


namespace ExpenseManagementSystem.Domain.Entities
{
    public class Expenditure : BaseEntity
    {
        public long ExpenseId { get; set; }
        public virtual Expense Expense { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public long CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public decimal Amount { get; set; }
        public decimal TaxAmount { get; set; }
        public string ReceiptFilePath { get; set; }    
        public string ReceiptNumber { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public long? ApprovedById { get; set; }
        public virtual AppUser ApprovedBy { get; set; }
        public string? ApprovalNote { get; set; }
        public long StatusId { get; set; }
        public virtual ExpenseStatus Status { get; set; }
        public long? PaymentId { get; set; }
        public virtual Payment? Payment { get; set; }
    }
}
