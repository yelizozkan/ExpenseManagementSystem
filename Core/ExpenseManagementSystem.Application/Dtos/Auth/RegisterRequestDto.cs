
namespace ExpenseManagementSystem.Application.Dtos.Auth
{
    public class RegisterRequestDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string IBAN { get; set; }
        public string DepartmentName { get; set; }
        public string Position { get; set; }
        public string Role { get; set; } 
    }
}
