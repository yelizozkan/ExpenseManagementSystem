using Microsoft.AspNetCore.Identity;


namespace ExpenseManagementSystem.Domain.Entities.Identity
{
    public class AppRole : IdentityRole<long>
    {
        public AppRole() { }

        public AppRole(string roleName) : base(roleName) { }
    }
}
