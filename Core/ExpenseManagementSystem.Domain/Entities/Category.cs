using ExpenseManagementSystem.Domain.Entities.Common;


namespace ExpenseManagementSystem.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Expenditure> Expenditures { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }
    }
}
