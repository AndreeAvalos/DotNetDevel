using DotNetDevel.Models.Response.Models;

namespace DotNetDevel.Middlewares.Exceptions;

public interface IResponseException
{
    ResponseError GetResponseError();
}