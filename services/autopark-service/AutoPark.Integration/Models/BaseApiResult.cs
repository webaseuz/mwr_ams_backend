using Ihma.Core.PrivateSdk.Models;
using Newtonsoft.Json;
using StatusGeneric;

namespace AutoPark.Integration.Models;
public class BaseApiResult<TResponse>
{
    public bool IsSuccess { get; set; }
    public int HttpStatus { get; set; }
    public string ResponseAsString { get; set; }
    public TResponse Response { get; set; }

    public virtual IStatusGeneric GetStatusGeneric(string separator = null)
    {
        var status = new StatusGenericHandler();

        if (!IsSuccess)
        {
            try
            {
                var modelState = JsonConvert.DeserializeObject<ErrorModelState>(ResponseAsString ?? string.Empty);

                if (modelState != null && modelState.Errors != null)
                {
                    foreach (var item in modelState.Errors)
                        status.AddError(string.Join(separator ?? Environment.NewLine, item.Value), item.Key);
                }
                else
                {
                    status.AddError($"{HttpStatus} - Error");
                }
            }
            catch
            {
                status.AddError(ResponseAsString ?? $"{HttpStatus} - Error");
            }
        }

        return status;
    }
}
