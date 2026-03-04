using Erp.Service.Adm.Job.Models;
using Refit;
using WEBASE;

namespace Erp.Service.Adm.Job.Sdk;
public interface IKinshipDegree
{
    // POST: /KinshipDegree/GetList
    [Post("/KinshipDegree/GetList")]
    Task<WbPagedResult<KinshipDegreeBriefDto>> GetListAsync([Body] KinshipDegreeGetListQuery query);

    // GET: /KinshipDegree/Get/{id}
    [Post("/KinshipDegree/Get/{id}")]
    Task<KinshipDegreeDto> GetByIdAsync([AliasAs("id")] int id);

    /// <summary>
    /// Get Security info
    /// </summary>
    [Get("/KinshipDegree/GetSecurityInfo")]
    Task<object> GetSecurityInfo();
}
