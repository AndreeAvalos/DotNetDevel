using DotNetDevel.Models.Enums;
using DotNetDevel.Models.Response.Models;

namespace DotNetDevel.Models.Response.Interface;

public interface IResponse
{
    ResponseError GetResponseError(HttpEnums httpEnum, List<string> errors);
    ResponseError GetResponseError(HttpEnums httpEnum, int errorCode, List<string> errors);
    ResponseSuccess<TResponse> GetResponseSuccess<TResponse>(HttpEnums httpEnum, TResponse data);
}