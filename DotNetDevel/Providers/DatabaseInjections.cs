using DotNetDevel.Database;
using DotNetDevel.Settings;
using Microsoft.EntityFrameworkCore;

namespace DotNetDevel.Providers;

public static class DatabaseInjections
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, Root root)
    {
        string connectionString = root.DatabaseSettings.ConnectionString;
        services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString));
        Console.WriteLine(connectionString);
        return services;
    }
}