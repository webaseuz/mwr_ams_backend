using Erp.Service.Adm.Job.Models;
using Refit;

namespace Erp.Service.Adm.Job.Sdk;

/// <summary>
/// Number API client interface
/// </summary>
public interface INumberApi
{
    /// <summary>
    /// </summary>
    [Post("/Number/GetNumberNext")]
    Task<GetNumberNextDto> GetNumberNextAsync([Body] GetNumberNextQuery query);
}
