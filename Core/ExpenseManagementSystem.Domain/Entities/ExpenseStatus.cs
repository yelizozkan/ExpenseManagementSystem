using ExpenseManagementSystem.Domain.Entities.Common;


namespace ExpenseManagementSystem.Domain.Entities
{
    public class ExpenseStatus : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int DisplayOrder { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }
    }
}
