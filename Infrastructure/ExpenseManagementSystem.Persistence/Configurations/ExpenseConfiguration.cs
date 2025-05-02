using ExpenseManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ExpenseManagementSystem.Persistence.Configurations
{
    public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description)
                   .HasMaxLength(300);

            builder.Property(x => x.ApprovalNote)
                   .HasMaxLength(300);


            builder.HasOne(x => x.User)
                   .WithMany(u => u.Expenses) 
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.ApprovedBy)
                   .WithMany() 
                   .HasForeignKey(x => x.ApprovedById)
                   .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.Status)
                   .WithMany(x => x.Expenses)
                   .HasForeignKey(x => x.StatusId)
                   .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.Payment)
                   .WithOne(x => x.Expense)
                   .HasForeignKey<Payment>(x => x.ExpenseId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
