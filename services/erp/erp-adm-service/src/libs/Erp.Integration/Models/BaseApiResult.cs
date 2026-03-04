namespace Erp.Integration.Models;

public class BaseApiResult<TResponse>
{
    public bool IsSuccess { get; set; }
    public int HttpStatus { get; set; }
    public string ResponseAsString { get; set; }
    public TResponse Response { get; set; }

    public string GetErrorString() =>
        IsSuccess ? string.Empty : ResponseAsString ?? $"{HttpStatus} - Error";
}
