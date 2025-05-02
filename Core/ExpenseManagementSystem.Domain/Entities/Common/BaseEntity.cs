using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Domain.Entities.Common
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;
        public DateOnly? CreatedDateOnly { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
        public DateOnly? UpdatedDateOnly { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
        public long? CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
