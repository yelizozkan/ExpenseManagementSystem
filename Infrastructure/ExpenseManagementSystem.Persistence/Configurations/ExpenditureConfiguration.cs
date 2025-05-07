using ExpenseManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseManagementSystem.Persistence.Configurations
{
    public class ExpenditureConfiguration : IEntityTypeConfiguration<Expenditure>
    {
        public void Configure(EntityTypeBuilder<Expenditure> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description)
                .HasMaxLength(300);

            builder.Property(x => x.ReceiptFilePath)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.ReceiptNumber)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Amount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.TaxAmount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.ApprovalNote)
                  .HasMaxLength(300);

            builder.HasOne(x => x.ApprovedBy)
                   .WithMany()
                   .HasForeignKey(x => x.ApprovedById)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Expense)
                .WithMany(x => x.Expenditures)
                .HasForeignKey(x => x.ExpenseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Expenditures)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Status)
               .WithMany(x => x.Expenditures)
               .HasForeignKey(x => x.StatusId)
               .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.Payment)
                .WithOne(x => x.Expenditure)
                .HasForeignKey<Expenditure>(x => x.PaymentId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
