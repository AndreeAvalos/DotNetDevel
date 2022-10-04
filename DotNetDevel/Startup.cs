using DotNetDevel.Mapper;
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

        services.AddJwt(Configuration.Get<Root>());
        services.AddMiddlewares();
        services.AddRepositories();
        services.AddServices();
        services.AddSwaggerGen();
        services.AddHttpContextAccessor();
        services.AddAutoMapper(x => x.AddProfile(new MapperProfile()));


        services.AddSingleton(Configuration.Get<Root>().JwtSettings);

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {


        app.UseHttpLogging();
        app.UseMiddleware<ErrorMiddleware>();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Site v1"));
        app.UseRouting();
        app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}