using System.Runtime.Serialization;
using DotNetDevel.Models.Enums;
using DotNetDevel.Models.Response.Implementation;
using DotNetDevel.Models.Response.Interface;
using DotNetDevel.Models.Response.Models;

namespace DotNetDevel.Middlewares.Exceptions;

[Serializable]
public class DatabaseException : Exception, IResponseException
{
    public HttpEnums Code { get; set; }
    private readonly IResponse _response;
    private readonly List<string> _errors;

    public DatabaseException(HttpEnums code, List<string> errors, IResponse response)
    {
        _response = response;
        _errors = errors;
        Code = code;
    }

    public DatabaseException(HttpEnums statusCode, List<string> errors)
    {
        Code = statusCode;
        _response = new ResponseImpl();
        _errors = errors;
    }

    protected DatabaseException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
        Code = HttpEnums.InternalServerError;
        _response = new ResponseImpl();
        _errors = new List<string> { "Default Serializable Constructor" };
    }

    public ResponseError GetResponseError()
    {
        return _response.GetResponseError(Code, _errors);
    }
}