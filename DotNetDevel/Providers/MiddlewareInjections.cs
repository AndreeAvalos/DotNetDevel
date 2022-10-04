using DotNetDevel.Middlewares;

namespace DotNetDevel.Providers;

public static class MiddlewareInjections
{
    public static IServiceCollection AddMiddlewares(this IServiceCollection services)
    {
        services.AddTransient<ErrorMiddleware>();
        return services;
    }
}