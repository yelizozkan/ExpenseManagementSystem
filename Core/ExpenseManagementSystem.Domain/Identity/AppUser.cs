using ExpenseManagementSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;


namespace ExpenseManagementSystem.Domain.Identity
{
    public class AppUser : IdentityUser<long> 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IBAN { get; set; }
        public string DepartmentName { get; set; }
        public string Position { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }

        public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();
    }
}
