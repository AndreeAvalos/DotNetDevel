using System.Text.Json.Serialization;

namespace DotNetDevel.Models.Response.Models;

public class ResponseError: AResponse
{
    [JsonPropertyName("errors")]
    public List<string> Errors
    {
        get;
        set;
    } = null!;
    
    [JsonPropertyName("errorCode")]
    public int ErrorCode
    {
        get;
        set;
    }

    public ResponseError(int statusCode, List<string> errors)
        : base(statusCode)
    {
        Errors = errors;
    }
    
    
    public ResponseError(int statusCode, int errorCode, List<string> errors) : base(statusCode)
    {
        Errors = errors;
        ErrorCode = errorCode;
    }

    [JsonConstructor]
    public ResponseError()
    {

    }
}