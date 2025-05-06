using ExpenseManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ExpenseManagementSystem.Persistence.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.PaymentDate)
                .IsRequired();

            builder.Property(x => x.Amount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.TargetIban)
                .IsRequired()
                .HasMaxLength(26);

            builder.HasOne(x => x.Expenditure)
                .WithOne(x => x.Payment)
                .HasForeignKey<Payment>(x => x.ExpenditureId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
