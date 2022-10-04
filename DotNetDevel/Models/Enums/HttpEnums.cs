namespace DotNetDevel.Models.Enums;

public enum HttpEnums
{
    //200
    Ok = 200,
    Created = 201,
    Accepted = 202,
    NoContent = 204,
    //400
    BadRequest = 400,
    Unathorized = 401,
    Forbidden = 403,
    NotFound = 404,
    MethodNotAllowed = 405,
    NotAcceptable = 406,
    Conflict = 409,
    UriToLong = 414,
    UnprocessableEntity = 422,
    //500
    InternalServerError = 500,
    BadGateway = 502,
    ServiceUnavailable = 503

}