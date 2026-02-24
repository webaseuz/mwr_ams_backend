using AutoPark.Integration.Models;

namespace AutoPark.Integration.Service;

public class CashManagementService : ICashManagementService
{
    private readonly AutoParkHttpClient _httpClient;
    public CashManagementService(AutoParkHttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<ApiResult<UserRespDto>> GetUserByPinfl(string pinfl, CancellationToken cancellationToken = default)
    {
        var uri = $"Integration/Hr/GetUserByPinfl?pinfl={pinfl}";

        return await _httpClient.SendAsync<UserRespDto>(HttpMethod.Get, uri, cancellationToken);
    }

}
