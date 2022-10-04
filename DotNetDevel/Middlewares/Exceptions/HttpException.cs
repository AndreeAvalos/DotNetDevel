using System.Runtime.Serialization;
using DotNetDevel.Models.Enums;
using DotNetDevel.Models.Response.Implementation;
using DotNetDevel.Models.Response.Interface;
using DotNetDevel.Models.Response.Models;

namespace DotNetDevel.Middlewares.Exceptions;

[Serializable]
public class HttpException : Exception, IResponseException
{
    public HttpEnums Code
    {
        get; set;
    }

    private readonly int _errorCode;
    private readonly IResponse _response;
    private readonly List<string> _errors;

    public HttpException(HttpEnums code, List<string> errors, IResponse response)
    {
        _response = response;
        _errors = errors;
        Code = code;
    }

    public HttpException(HttpEnums code, List<string> errors)
    {
        Code = code;
        _response = new ResponseImpl();
        _errors = errors;
    }
        
    public HttpException(HttpEnums code, int errorCode, List<string> errors)
    {
        Code = code;
        _response = new ResponseImpl();
        _errors = errors;
        _errorCode = errorCode;
    }

    protected HttpException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
        Code = HttpEnums.InternalServerError;
        _response = new ResponseImpl();
        _errors = new List<string> { "Default Serializable Constructor" };
    }

    public ResponseError GetResponseError()
    {
        return _response.GetResponseError(Code, _errorCode, _errors);
    }
}