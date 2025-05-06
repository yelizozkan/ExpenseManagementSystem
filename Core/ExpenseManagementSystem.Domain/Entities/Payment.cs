using ExpenseManagementSystem.Domain.Entities.Common;

namespace ExpenseManagementSystem.Domain.Entities
{
    public class Payment : BaseEntity
    {
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string TargetIban { get; set; }    
        public long ExpenditureId { get; set; }
        public virtual Expenditure Expenditure { get; set; }     
    }

}
