using Erp.Integration.Models;

namespace Erp.Integration.Service;

public interface ICashManagementService
{
    public Task<ApiResult<UserRespDto>> GetUserByPinfl(string pinfl, CancellationToken cancellationToken = default);
}
