using ExpenseManagementSystem.Domain.Entities.Common;


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
    }
}
