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
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.PaymentMethod)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.TargetIban)
                .IsRequired()
                .HasMaxLength(26);

            builder.Property(x => x.TransactionReference)
                .HasMaxLength(100);

            builder.HasOne(x => x.Expense)
                .WithOne(x => x.Payment)
                .HasForeignKey<Payment>(x => x.ExpenseId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
