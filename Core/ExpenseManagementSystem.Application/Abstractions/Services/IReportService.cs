using ExpenseManagementSystem.Application.Dtos.Reports;

namespace ExpenseManagementSystem.Application.Abstractions.Services
{
    public interface IReportService
    {
        Task<IEnumerable<UserExpenseReportDto>> GetPersonalExpenseReportAsync();
        Task<List<PaymentDensityDto>> GetPaymentDensityAsync(string type);
        Task<List<UserExpenditureDensityDto>> GetUserExpenditureDensityAsync(string type);
        Task<List<ExpenseApprovalSummaryDto>> GetApprovalSummaryAsync(string type);

    }
}
