using ExpenseManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            builder.HasOne(x => x.Expense)
                .WithMany(x => x.Expenditures)
                .HasForeignKey(x => x.ExpenseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Expenditures)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
