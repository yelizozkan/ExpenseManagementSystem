using ExpenseManagementSystem.Application.Dtos.Expenditure;


namespace ExpenseManagementSystem.Application.Abstractions.Services
{
    public interface IExpenditureQueryService
    {
        Task<List<ExpenditureResponseDto>> GetAllAsync();
        Task<ExpenditureResponseDto?> GetByIdAsync(long id);
    }
}
