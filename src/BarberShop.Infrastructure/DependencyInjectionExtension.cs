using BarberShop.Domain.Repositories;
using BarberShop.Domain.Repositories.Expenses;
using BarberShop.Infrastructure.DataAccess;
using BarberShop.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BarberShop.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastrcture(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
        AddRepositories(services);
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnityOfWork, UnityOfWork>();
        services.AddScoped<IExpensesReadOnlyRepository, ExpensesRepository>();
        services.AddScoped<IExpenseWriteOnlyRepository, ExpensesRepository>();
        services.AddScoped<IExpensesUpdateOnlyRepository, ExpensesRepository>();
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Connection");

        var version = new Version(8, 0, 39);
        var serverVersion = new MySqlServerVersion(version);

        services.AddDbContext<BarberShopDbContext>(config => config.UseMySql(connectionString, serverVersion));
    }
}
