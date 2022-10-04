using DotNetDevel.Middlewares;
using DotNetDevel.Providers;
using DotNetDevel.Settings;

namespace DotNetDevel;

public class Startup
{
    private IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDataControllers();
        services.AddDatabase(Configuration.Get<Root>());
        services.AddCors(options =>
        {
            options.AddPolicy("_AllowAllOriginsPolicy",
                policy =>
                {
                    policy.AllowAnyMethod();
                    policy.AllowAnyHeader();
                });
        });
        services.AddMiddlewares();
        services.AddRepositories();
        services.AddServices();
        services.AddSwaggerGen();


    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseHttpLogging();
        app.UseMiddleware<ErrorMiddleware>();
        app.UseRouting();
        app.UseCors("_AllowAllOriginsPolicy");
        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Site v1"));

        
    }
}