using ExpenseManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseManagementSystem.Persistence.Configurations
{
    public class ExpenseStatusConfiguration : IEntityTypeConfiguration<ExpenseStatus>
    {
        public void Configure(EntityTypeBuilder<ExpenseStatus> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Description)
            .HasMaxLength(250);

            builder.HasMany(x => x.Expenses);    

            builder.HasMany(x => x.Expenditures);

        }
    }
}
