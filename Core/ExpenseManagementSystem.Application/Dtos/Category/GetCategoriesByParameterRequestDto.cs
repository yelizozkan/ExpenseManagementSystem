

namespace ExpenseManagementSystem.Application.Dtos.Category
{
    public class GetCategoriesByParameterRequestDto
    {
        public string? Name { get; set; }
        public bool? IsActive { get; set; }
    }
}
