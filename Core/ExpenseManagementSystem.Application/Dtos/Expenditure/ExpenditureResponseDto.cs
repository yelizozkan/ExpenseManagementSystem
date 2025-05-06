namespace ExpenseManagementSystem.Application.Dtos.Expenditure
{
    public class ExpenditureResponseDto
    {
        public long Id { get; set; }
        public long ExpenseId { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public long CategoryId { get; set; }
        public decimal Amount { get; set; }
        public decimal TaxAmount { get; set; }
        public string ReceiptFilePath { get; set; }
        public string ReceiptNumber { get; set; }
        public long? PaymentId { get; set; }
        public bool? IsApprovedForPayment { get; set; }
        public bool IsActive { get; set; }
    }
}
