using Erp.Service.Adm.Job.Models;
using Refit;
using WEBASE;

namespace Erp.Service.Adm.Job.Sdk;
public interface IEduYearApi
{
    [Post("/EduYea/Create")]
    Task<WbHaveId<int>> CreateAsync([Body] EduYearCreateCommand command);

    [Post("/EduYea/Update")]
    Task<bool> UpdateAsync([Body] EduYearUpdateCommand command);

    [Post("/EduYea/GetList")]
    Task<WbPagedResult<EduYearBriefDto>> GetListAsync([Body] EduYearGetListQuery query);

    [Post("/EduYea/Delete/{id}")]
    Task<bool> DeleteAsync(int id);

    [Post("/EduYea/Get")]
    Task<EduYearDto> GetAsync();

    [Post("/EduYea/Get/{id}")]
    Task<EduYearDto> GetByIdAsync(int id);


    [Post("/EduYea/GetAsSelectList")]
    Task<WbSelectList<int, EduYearSelectListDto>> GetAsSelectListAsync();

    /// <summary>
    /// Get Security info
    /// </summary>
    [Get("/EduYea/GetSecurityInfo")]
    Task<object> GetSecurityInfo();
}

