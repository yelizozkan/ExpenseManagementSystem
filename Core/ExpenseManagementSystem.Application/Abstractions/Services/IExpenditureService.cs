using ExpenseManagementSystem.Application.Dtos.Expenditure;
using ExpenseManagementSystem.Domain.Entities;


namespace ExpenseManagementSystem.Application.Abstractions.Services
{
    public interface IExpenditureService
    {
        Task<Expenditure> CreateAsync(ExpenditureRequestDto model);
        Task<Expenditure> UpdateAsync(long id, ExpenditureRequestDto model);
        Task<bool> SoftDeleteAsync(long id);
    }
}
