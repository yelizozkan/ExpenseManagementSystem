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
        public long StatusId { get; set; }
        public string StatusName { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public string? ApprovalNote { get; set; }
        public long? ApprovedById { get; set; }
        public string? ApprovedByName { get; set; }
        public bool IsActive { get; set; }
    }
}
