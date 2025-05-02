using ExpenseManagementSystem.Application.Abstractions.Token;
using ExpenseManagementSystem.Infrastructure.Services.Token;
using Microsoft.Extensions.DependencyInjection;


namespace ExpenseManagementSystem.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ITokenHandler, TokenHandler>();

        }
    }
}
