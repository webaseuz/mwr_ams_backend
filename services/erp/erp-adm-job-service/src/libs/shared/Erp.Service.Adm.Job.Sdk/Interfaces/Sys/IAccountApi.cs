using Erp.Service.Adm.Job.Models;
using Refit;

namespace Erp.Service.Adm.Job.Sdk;
public interface IAccountApi
{
    [Post("/Account/GetAuthInfo")]
    Task<UserAuthInfoDto> GetAuthInfoAsync();

    [Get("/Account/GetSecurityInfo")]
    Task<object> GetSecurityInfo();
}
