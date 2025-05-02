
namespace ExpenseManagementSystem.Application.Dtos.Expenditure
{
    public class GetExpenditureByParameterRequestDto
    {
        public long? ExpenseId { get; set; }
        public long? CategoryId { get; set; }
        public DateTime? Date { get; set; }
        public bool? IsActive { get; set; }
    }
}
