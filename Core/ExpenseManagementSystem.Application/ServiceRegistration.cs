using ExpenseManagementSystem.Application.Features.Auth.Commands.Login;
using ExpenseManagementSystem.Application.Features.Auth.Commands.RefreshToken;
using ExpenseManagementSystem.Application.Features.Auth.Commands.Register;
using ExpenseManagementSystem.Application.Features.Categories.Commands.CreateCategory;
using ExpenseManagementSystem.Application.Features.Categories.Commands.DeleteCategory;
using ExpenseManagementSystem.Application.Features.Categories.Commands.UpdateCategory;
using ExpenseManagementSystem.Application.Features.Expenditures.Commands.CreateExpenditure;
using ExpenseManagementSystem.Application.Features.Expenditures.Commands.DeleteExpenditure;
using ExpenseManagementSystem.Application.Features.Expenditures.Commands.UpdateExpenditure;
using ExpenseManagementSystem.Application.Features.Expenses.Commands.CreateExpense;
using ExpenseManagementSystem.Application.Mapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;


namespace ExpenseManagementSystem.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(CreateCategoryCommand).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(CreateExpenditureCommand).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(CreateExpenseCommand).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(LoginCommand).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(RegisterCommand).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(RefreshTokenCommand).Assembly);
            });

            // AutoMapper
            serviceCollection.AddAutoMapper(typeof(MapperConfig).Assembly);

            // FluentValidation
            serviceCollection.AddValidatorsFromAssembly(typeof(CreateCategoryCommandValidator).Assembly);
            serviceCollection.AddValidatorsFromAssembly(typeof(UpdateCategoryCommandValidator).Assembly);
            serviceCollection.AddValidatorsFromAssembly(typeof(DeleteCategoryCommandValidator).Assembly);
            serviceCollection.AddValidatorsFromAssembly(typeof(CreateExpenditureCommandValidator).Assembly);
            serviceCollection.AddValidatorsFromAssembly(typeof(UpdateExpenditureCommandValidator).Assembly);
            serviceCollection.AddValidatorsFromAssembly(typeof(DeleteExpenditureCommandValidator).Assembly);
            serviceCollection.AddValidatorsFromAssemblyContaining<CreateExpenseCommandValidator>();
            serviceCollection.AddValidatorsFromAssemblyContaining<LoginCommandValidator>();
        }
    }
}
