using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Application.Dtos.Expense
{
    public class ExpenseResponseDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string UserFullName { get; set; }
        public DateTime SubmissionDate { get; set; }
        public string? Description { get; set; }
        public long StatusId { get; set; }
        public string StatusName { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public long? ApprovedById { get; set; }
        public string? ApprovedByFullName { get; set; }
        public string? ApprovalNote { get; set; }
        public decimal Total { get; set; }
        public long? PaymentId { get; set; }
        public string? PaymentReferenceNumber { get; set; }
    }
}
