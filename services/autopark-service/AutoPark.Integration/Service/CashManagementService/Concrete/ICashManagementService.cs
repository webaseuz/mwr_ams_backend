using AutoPark.Integration.Models;

namespace AutoPark.Integration.Service;

public interface ICashManagementService
{
    public Task<ApiResult<UserRespDto>> GetUserByPinfl(string pinfl, CancellationToken cancellationToken = default);
}
