namespace AutoPark.Integration.Models;

public class ApiResult<TResponse> : BaseApiResult<TResponse>
{
    public string GetErrorString()
    {
        if (!IsSuccess)
            return ResponseAsString;
        return $"{HttpStatus} - Error";
    }
}
