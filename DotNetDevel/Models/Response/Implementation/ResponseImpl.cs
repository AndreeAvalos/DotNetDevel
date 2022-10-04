using DotNetDevel.Models.Enums;
using DotNetDevel.Models.Response.Interface;
using DotNetDevel.Models.Response.Models;

namespace DotNetDevel.Models.Response.Implementation;

public class ResponseImpl: IResponse
{
    public ResponseError GetResponseError(HttpEnums httpEnum, List<string> errors)
    {
        return new ResponseError((int)httpEnum, errors);
    }
    
    public ResponseError GetResponseError(HttpEnums httpEnum, int errorCode, List<string> errors)
    {
        return new ResponseError((int)httpEnum, errorCode, errors);
    }

    public ResponseSuccess<TResponse> GetResponseSuccess<TResponse>(HttpEnums httpEnum, TResponse data)
    {
        return new ResponseSuccess<TResponse>((int)httpEnum, data);
    } 
}