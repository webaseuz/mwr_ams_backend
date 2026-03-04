using Erp.Service.Adm.Job.Models;
using Refit;

namespace Erp.Service.Adm.Job.Sdk;
public interface IFileConfigApi
{
    /// <summary>
    /// Get File Config by TableId
    /// </summary>
    [Post("/FileConfig/Get")]
    Task<IEnumerable<FileConfigDto>> GetByTableIdAsync([Body] FileConfigGetByTableIdQuery query);

}
