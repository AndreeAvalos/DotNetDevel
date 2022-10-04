using DotNetDevel.Entities;
using DotNetDevel.Repositories.Implementation;
using DotNetDevel.Repositories.Interface;

namespace DotNetDevel.Providers;

public static class RepositoryInjections
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IRepository<UserEntity>, UserRepositoryImpl>();
        services.AddTransient<IRepository<SurveyEntity>, SurveyRepositoryImpl>();
        services.AddTransient<IRepository<FieldSurveyEntity>, FieldSurveyRepositoryImpl>();
        services.AddTransient<IRepository<AnswerSurveyEntity>, AnswerSurveyRepositoryImpl>();
        return services;
    }
    

}