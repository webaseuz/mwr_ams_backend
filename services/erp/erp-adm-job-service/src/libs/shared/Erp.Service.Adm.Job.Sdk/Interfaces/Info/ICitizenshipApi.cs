using Erp.Service.Adm.Job.Models;
using Refit;
using WEBASE;

namespace Erp.Service.Adm.Job.Sdk;
public interface ICitizenshipApi
{
    [Post("/Citizenship/GetList")]
    Task<WbPagedResult<CitizenshipBriefDto>> GetListAsync([Body] CitizenshipGetListQuery query);

    [Post("/Citizenship/GetAsSelectList")]
    Task<WbSelectList<int, CitizenshipSelectListDto>> GetAsSelectListAsync();

    [Get("/Citizenship/GetSecurityInfo")]
    Task<object> GetSecurityInfo();
}

