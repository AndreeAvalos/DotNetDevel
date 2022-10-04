using System.Text.Json.Serialization;

namespace DotNetDevel.Models.Response.Models;

public abstract class AResponse
{
    [JsonPropertyName("transactionId")]
    public string TransactionId { get; set; } = null!;

    [JsonPropertyName("statusCode")]
    public int StatusCode
    {
        get; set;
    }

    [JsonPropertyName("transactionName")]
    public string TransactionName { get; set; } = null!;

    protected AResponse(int statusCode)
    {
        TransactionId = Guid.NewGuid().ToString();
        StatusCode = statusCode;
        TransactionName = "Method:  - Path:  ";
    }
    [JsonConstructor]
    protected AResponse()
    {

    }
}