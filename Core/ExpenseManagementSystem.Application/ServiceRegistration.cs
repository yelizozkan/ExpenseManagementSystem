using ExpenseManagementSystem.Application.Features.Auth.Commands.Login;
using ExpenseManagementSystem.Application.Features.Auth.Commands.RefreshToken;
using ExpenseManagementSystem.Application.Features.Auth.Commands.Register;
using ExpenseManagementSystem.Application.Features.Categories.Commands.CreateCategory;
using ExpenseManagementSystem.Application.Features.Categories.Commands.DeleteCategory;
using ExpenseManagementSystem.Application.Features.Categories.Commands.UpdateCategory;
using ExpenseManagementSystem.Application.Features.Expenditures.Commands.ApproveExpenditure;
using ExpenseManagementSystem.Application.Features.Expenditures.Commands.CreateExpenditure;
using ExpenseManagementSystem.Application.Features.Expenditures.Commands.DeleteExpenditure;
using ExpenseManagementSystem.Application.Features.Expenditures.Commands.UpdateExpenditure;
using ExpenseManagementSystem.Application.Features.Expenses.Commands.CreateExpense;
using ExpenseManagementSystem.Application.Features.Expenses.Commands.DeleteExpense;
using ExpenseManagementSystem.Application.Features.Expenses.Commands.UpdateExpense;
using ExpenseManagementSystem.Application.Features.ExpenseStatuses.Commands.CreateExpenseStatus;
using ExpenseManagementSystem.Application.Features.Payments.Commands.CreatePayment;
using ExpenseManagementSystem.Application.Features.Payments.Commands.DeletePayment;
using ExpenseManagementSystem.Application.Features.Payments.Commands.UpdatePayment;
using ExpenseManagementSystem.Application.Features.Users.Commands.AssignRole;
using ExpenseManagementSystem.Application.Features.Users.Commands.UpdateUser;
using ExpenseManagementSystem.Application.Features.Users.Commands.UpdateUserProfile;
using ExpenseManagementSystem.Application.Helpers;
using ExpenseManagementSystem.Application.Mapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;


namespace ExpenseManagementSystem.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection serviceCollection)
        {

            serviceCollection.AddAutoMapper(typeof(IAssemblyMarker).Assembly);
            serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(IAssemblyMarker).Assembly));
            serviceCollection.AddValidatorsFromAssemblyContaining<IAssemblyMarker>();

        }
    }
}
