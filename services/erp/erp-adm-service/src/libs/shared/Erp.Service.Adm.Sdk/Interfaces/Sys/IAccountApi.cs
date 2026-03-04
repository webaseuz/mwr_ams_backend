using Erp.Service.Adm.Models;
using Refit;

namespace Erp.Service.Adm.Sdk;
public interface IAccountApi
{
    [Post("/Account/GetAuthInfo")]
    Task<UserAuthInfoDto> GetAuthInfoAsync();

    [Get("/Account/GetSecurityInfo")]
    Task<object> GetSecurityInfo();
}
