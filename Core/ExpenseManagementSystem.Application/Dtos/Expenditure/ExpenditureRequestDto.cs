

using Microsoft.AspNetCore.Http;

namespace ExpenseManagementSystem.Application.Dtos.Expenditure
{
    public class ExpenditureRequestDto
    {
        public long ExpenseId { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public long CategoryId { get; set; }
        public decimal Amount { get; set; }
        public decimal TaxAmount { get; set; }
        public IFormFile? ReceiptFile { get; set; }
        public string ReceiptNumber { get; set; }
    }
}
