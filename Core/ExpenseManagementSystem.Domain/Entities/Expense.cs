using ExpenseManagementSystem.Domain.Entities.Common;
using ExpenseManagementSystem.Domain.Entities.Identity;

namespace ExpenseManagementSystem.Domain.Entities
{
    public class Expense : BaseEntity
    {
        public long UserId { get; set; }
        public virtual AppUser User { get; set; }
        public long CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public string? Description { get; set; }
        public DateTime SubmissionDate { get; set; }
        public long StatusId { get; set; }
        public virtual ExpenseStatus Status { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public long? ApprovedById { get; set; }
        public virtual AppUser ApprovedBy { get; set; }
        public string? ApprovalNote { get; set; }
        public decimal Total { get; set; }
        public virtual ICollection<Expenditure> Expenditures { get; set; } = new List<Expenditure>();

    }
}
