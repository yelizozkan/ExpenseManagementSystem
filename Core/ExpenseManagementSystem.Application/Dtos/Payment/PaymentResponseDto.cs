namespace ExpenseManagementSystem.Application.Dtos.Payment
{
    public class PaymentResponseDto
    {
        public long Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string TargetIban { get; set; }
        public long ExpenditureId { get; set; }
    }
}
