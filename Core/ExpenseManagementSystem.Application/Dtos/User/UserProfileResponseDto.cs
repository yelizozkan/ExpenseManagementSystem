namespace ExpenseManagementSystem.Application.Dtos.User
{
    public class UserProfileResponseDto
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Iban { get; set; }
        public string DepartmentName { get; set; }
        public string Position { get; set; }
        public string Role { get; set; }

    }
}
