using Dapper;
using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Dtos.Reports;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;


namespace ExpenseManagementSystem.Persistence.Services
{
    public class ReportService : IReportService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserAccessor _userAccessor;

        public ReportService(IConfiguration configuration, IUserAccessor userAccessor)
        {
            _configuration = configuration;
            _userAccessor = userAccessor;
        }

        private IDbConnection CreateConnection()
        {
            return new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }

        public async Task<IEnumerable<UserExpenseReportDto>> GetPersonalExpenseReportAsync()
        {
            var userId = _userAccessor.GetUserId();
            var role = _userAccessor.GetUserRole();


            var sql = @"
                SELECT 
                    ""ExpenseId"",
                    ""UserId"",
                    ""ExpenseTitle"",
                    ""CategoryName"",
                    ""ExpenseDate"",
                    ""TotalAmount"",
                    ""Status"",
                    ""ExpenditureId"",
                    ""ExpenditureDescription"",
                    ""Amount"",
                    ""StatusId"",
                    ""CreatedDate""
                FROM ""vw_personal_expense_report""
                WHERE (@Role = 'Admin' OR ""UserId"" = @UserId)
                ORDER BY ""ExpenseDate"" DESC;
            ";


            using var connection = CreateConnection();
            var lookup = new Dictionary<string, UserExpenseReportDto>();

            var result = await connection.QueryAsync<UserExpenseReportDto, ExpenditureDto, UserExpenseReportDto>(
                sql,
                (expense, expenditure) =>
                {
                    if (!lookup.TryGetValue(expense.ExpenseTitle, out var reportDto))
                    {
                        reportDto = expense;
                        reportDto.Expenditures = new List<ExpenditureDto>();
                        lookup[reportDto.ExpenseTitle] = reportDto;
                    }

                    if (expenditure != null)
                        reportDto.Expenditures.Add(expenditure);

                    return reportDto;
                },
                new { UserId = userId, Role = role },
                splitOn: "ExpenditureId"
            );

            return lookup.Values;
        }


        public async Task<List<PaymentDensityDto>> GetPaymentDensityAsync(string type)
        {
            var viewName = type switch
            {
                "daily" => "\"vw_payment_density_daily\"",
                "weekly" => "\"vw_payment_density_weekly\"",
                "monthly" => "\"vw_payment_density_monthly\"",
                _ => throw new ArgumentException("Geçersiz zaman tipi", nameof(type))
            };

            var sql = $"SELECT * FROM {viewName}";

            using var connection = CreateConnection();
            var result = await connection.QueryAsync<PaymentDensityDto>(sql);
            return result.ToList();
        }


        public async Task<List<UserExpenditureDensityDto>> GetUserExpenditureDensityAsync(string type)
        {
            var viewName = type switch
            {
                "daily" => "\"vw_user_expenditure_density_daily\"",
                "weekly" => "\"vw_user_expenditure_density_weekly\"",
                "monthly" => "\"vw_user_expenditure_density_monthly\"",
                _ => throw new ArgumentException("Geçersiz zaman tipi", nameof(type))
            };

            var query = $"SELECT * FROM {viewName}";

            using var connection = CreateConnection();
            var result = await connection.QueryAsync<UserExpenditureDensityDto>(query);
            return result.ToList();
        }


        public async Task<List<ExpenseApprovalSummaryDto>> GetApprovalSummaryAsync(string type)
        {
            var viewName = type switch
            {
                "daily" => "\"vw_expenditure_approval_daily_summary\"",
                "weekly" => "\"vw_expenditure_approval_weekly_summary\"",
                "monthly" => "\"vw_expenditure_approval_monthly_summary\"",
                _ => throw new ArgumentException("Geçersiz zaman tipi", nameof(type))
            };

            var sql = $@"SELECT * FROM {viewName}";

            using var connection = CreateConnection();
            var result = await connection.QueryAsync<ExpenseApprovalSummaryDto>(sql);
            return result.ToList();

        }
    }
}
