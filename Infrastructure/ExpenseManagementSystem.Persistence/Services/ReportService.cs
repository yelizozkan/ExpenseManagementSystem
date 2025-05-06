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
                    e.""Description"" AS ExpenseTitle,
                    c.""Name"" AS CategoryName,
                    e.""SubmissionDate"" AS ExpenseDate,
                    e.""Total"" AS TotalAmount,
                    s.""Name"" AS Status,
                    ex.""Description"" AS Description,
                    ex.""Amount"" AS Amount,
                    ex.""IsApprovedForPayment"" AS IsApproved,
                    ex.""CreatedDate"" AS CreatedDate
               FROM ""table"".""Expenses"" e
               JOIN ""table"".""Categories"" c ON e.""CategoryId"" = c.""Id""
               JOIN ""table"".""ExpenseStatuses"" s ON e.""StatusId"" = s.""Id""
               LEFT JOIN ""table"".""Expenditures"" ex ON ex.""ExpenseId"" = e.""Id""
               WHERE (@Role = 'Admin' OR e.""UserId"" = @UserId)
               ORDER BY e.""SubmissionDate"" DESC;
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
                splitOn: "Description"
            );

            return lookup.Values;
        }


        public async Task<List<PaymentDensityDto>> GetPaymentDensityAsync(string type)
        {
            var dateColumn = type switch
            {
                "daily" => "DATE(p.\"PaymentDate\")",
                "weekly" => "DATE_TRUNC('week', p.\"PaymentDate\")",
                "monthly" => "DATE_TRUNC('month', p.\"PaymentDate\")",
                _ => throw new ArgumentException("Invalid type", nameof(type))
            };

            var query = $@"
                SELECT 
                    {dateColumn} AS Date,
                    SUM(p.""Amount"") AS TotalAmount,
                    COUNT(p.""Id"") AS PaymentCount,
                    u.""FirstName"" || ' ' || u.""LastName"" AS EmployeeName,
                    a.""FirstName"" || ' ' || a.""LastName"" AS ApproverName,
                    c.""Name"" AS CategoryName
                FROM ""table"".""Payments"" p
                JOIN ""table"".""Expenditures"" ex ON p.""ExpenditureId"" = ex.""Id""
                JOIN ""table"".""Expenses"" e ON ex.""ExpenseId"" = e.""Id""
                JOIN ""table"".""Users"" u ON e.""UserId"" = u.""Id""
                LEFT JOIN ""table"".""Users"" a ON e.""ApprovedById"" = a.""Id""
                JOIN ""table"".""Categories"" c ON ex.""CategoryId"" = c.""Id""
                GROUP BY Date, EmployeeName, ApproverName, CategoryName
                ORDER BY Date;
            ";

            using var connection = CreateConnection();
            var result = await connection.QueryAsync<PaymentDensityDto>(query);
            return result.ToList();
        }


        public async Task<List<UserExpenditureDensityDto>> GetUserExpenditureDensityAsync(string type)
        {
            var dateColumn = type switch
            {
                "daily" => "DATE(ex.\"Date\")",
                "weekly" => "DATE_TRUNC('week', ex.\"Date\")",
                "monthly" => "DATE_TRUNC('month', ex.\"Date\")",
                _ => throw new ArgumentException("Invalid type", nameof(type))
            };

            var query = $@"
                SELECT 
                    {dateColumn} AS Date,
                    u.""FirstName"" || ' ' || u.""LastName"" AS UserName,
                    SUM(ex.""Amount"") AS TotalAmount,
                    COUNT(ex.""Id"") AS ExpenditureCount
                FROM ""table"".""Expenditures"" ex
                JOIN ""table"".""Expenses"" e ON ex.""ExpenseId"" = e.""Id""
                JOIN ""table"".""Users"" u ON e.""UserId"" = u.""Id""
                GROUP BY {dateColumn}, UserName
                ORDER BY {dateColumn};
            ";

            using var connection = CreateConnection();
            var result = await connection.QueryAsync<UserExpenditureDensityDto>(query);
            return result.ToList();
        }


    }
}
