
namespace ExpenseManagementSystem.Application.Abstractions.Services
{
    public interface IUserAccessor
    {
        long GetUserId();
        string GetUserRole();
    }
}
