using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;


using ExpenseManagementSystem.Persistence.Contexts;

namespace ExpenseManagementSystem.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ExpenseManagementSystemDbContext>
    {
        public ExpenseManagementSystemDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ExpenseManagementSystemDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql(Configuration.ConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
