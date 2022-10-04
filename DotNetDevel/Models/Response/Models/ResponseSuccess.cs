using System.Text.Json.Serialization;

namespace DotNetDevel.Models.Response.Models;

public class ResponseSuccess<TResponse> : AResponse
{
    [JsonPropertyName("data")]
    public TResponse Data
    {
        get;
        set;
    } = default!;

    public ResponseSuccess(int statusCode, TResponse data)
        : base(statusCode)
    {
        Data = data;
    }

    public ResponseSuccess(int statusCode, string operationId, TResponse data)
        : base(statusCode)
    {
        Data = data;
    }

    [JsonConstructor]
    public ResponseSuccess()
    {
    }
}