using ExpenseManagementSystem.Application.Abstractions.Repository;
using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Abstractions.UnitOfWork;
using ExpenseManagementSystem.Persistence.Repositories;
using ExpenseManagementSystem.Persistence.Services;
using Microsoft.Extensions.DependencyInjection;


namespace ExpenseManagementSystem.Persistence
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection serviceCollection)
        {

            serviceCollection.AddScoped<ICategoryService, CategoryService>();
            serviceCollection.AddScoped<ICategoryQueryService, CategoryQueryService>();

            serviceCollection.AddScoped<ICategoryRepository, CategoryRepository>();

            serviceCollection.AddScoped<IExpenditureRepository, ExpenditureRepository>();

            serviceCollection.AddScoped<IExpenditureService, ExpenditureService>();
            serviceCollection.AddScoped<IExpenditureQueryService, ExpenditureQueryService>();


            serviceCollection.AddScoped<IExpenseService, ExpenseService>();
            serviceCollection.AddScoped<IExpenseQueryService, ExpenseQueryService>();

            serviceCollection.AddScoped<IExpenseRepository, ExpenseRepository>();
            

            serviceCollection.AddScoped<IExpenseStatusRepository, ExpenseStatusRepository>();
            serviceCollection.AddScoped<IExpenseStatusService, ExpenseStatusService>();
            serviceCollection.AddScoped<IExpenseStatusQueryService, ExpenseStatusQueryService>();

            serviceCollection.AddScoped<IAuthService, AuthService>();

            serviceCollection.AddScoped<IPaymentRepository, PaymentRepository>();
            serviceCollection.AddScoped<IPaymentService, PaymentService>();
            serviceCollection.AddScoped<IPaymentQueryService, PaymentQueryService>();

            serviceCollection.AddScoped<IUserRepository, UserRepository>();
            serviceCollection.AddScoped<IUserService, UserService>();

            serviceCollection.AddScoped<IUserRoleService, UserRoleService>();
            serviceCollection.AddScoped<IReportService, ReportService>();



            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

            return serviceCollection;
        }
    }
}
