using Microsoft.AspNetCore.Mvc.Formatters;

namespace DotNetDevel.Providers;

public static class ControllerInjections
{
    public static IServiceCollection AddDataControllers(this IServiceCollection services)
    {
        services.AddControllers(options =>
            {
                options.OutputFormatters.RemoveType<StringOutputFormatter>();
                options.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>();
            })
            .ConfigureApiBehaviorOptions(options => { options.SuppressModelStateInvalidFilter = true; });

        services.AddRouting(options => options.LowercaseUrls = true);
        return services;
    }
}