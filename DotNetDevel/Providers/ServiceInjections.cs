using DotNetDevel.Models.Response.Implementation;
using DotNetDevel.Models.Response.Interface;

namespace DotNetDevel.Providers;

public static class ServiceInjections
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<IResponse, ResponseImpl>();
        return services;
    }
}