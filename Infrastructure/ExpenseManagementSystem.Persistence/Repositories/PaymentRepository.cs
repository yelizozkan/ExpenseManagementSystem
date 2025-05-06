using ExpenseManagementSystem.Application.Abstractions.Repository;
using ExpenseManagementSystem.Domain.Entities;
using ExpenseManagementSystem.Persistence.Contexts;

namespace ExpenseManagementSystem.Persistence.Repositories
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        public PaymentRepository(ExpenseManagementSystemDbContext context) : base(context)
        {
        }
    }
}
