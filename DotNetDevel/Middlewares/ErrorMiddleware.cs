using System.Text.Json;
using DotNetDevel.Middlewares.Exceptions;
using DotNetDevel.Models.Enums;
using DotNetDevel.Models.Response.Interface;
using DotNetDevel.Models.Response.Models;

namespace DotNetDevel.Middlewares;

public class ErrorMiddleware : IMiddleware
{
    private readonly IResponse _response;
    public ErrorMiddleware(IServiceProvider provider)
    {
        _response = provider.GetRequiredService<IResponse>();
    }
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (DatabaseException databaseException)
        {
            await BuildResponseAsync(context, databaseException.GetResponseError(),databaseException);
        }
        catch (HttpException httpException)
        {
            await BuildResponseAsync(context,
                httpException.GetResponseError(), httpException);
        }
        catch (Exception ex)
        {
            await BuildResponseAsync(context,
                _response.GetResponseError(HttpEnums.InternalServerError,
                    new List<string> {"Internal Server Error"}), ex);
        }
    }
    private async Task BuildResponseAsync(HttpContext httpContext, ResponseError responseError, Exception err)
    {
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = responseError.StatusCode;
        Console.WriteLine(err);
        await httpContext.Response.WriteAsync(JsonSerializer.Serialize(responseError));
        
        
    }
}