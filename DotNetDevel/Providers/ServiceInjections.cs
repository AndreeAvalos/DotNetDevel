using AutoMapper;
using DotNetDevel.Entities;
using DotNetDevel.Models.Response.Implementation;
using DotNetDevel.Models.Response.Interface;
using DotNetDevel.Services.Implementation;
using DotNetDevel.Services.Interface;

namespace DotNetDevel.Providers;

public static class ServiceInjections
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<IResponse, ResponseImpl>();
        services.AddTransient<ILoginService, LoginSeviceImpl>();
        services.AddTransient<IService<UserEntity>, UserServiceImpl>();
        services.AddTransient<IService<SurveyEntity>, SurveyServiceImpl>();
        services.AddTransient<IService<AnswerSurveyEntity>, AnswerSurveyServiceImpl>();
        services.AddTransient<ISurveyResultService, SurveyResultServiceImpl>();
        return services;
    }
}