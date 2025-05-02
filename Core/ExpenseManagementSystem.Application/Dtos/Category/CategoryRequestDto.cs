

namespace ExpenseManagementSystem.Application.Dtos.Category
{
    public class CategoryRequestDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
    }
}
