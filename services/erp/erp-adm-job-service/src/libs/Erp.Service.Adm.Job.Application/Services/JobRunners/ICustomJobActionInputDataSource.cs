using Erp.Core.Service.Domain;

namespace Erp.Service.Adm.Job.Application.Services.JobRunners;

public interface ICustomJobActionInputDataSource<TActionInputData>
{
    Task<TActionInputData[]> GetSource(CustomJob entity);
}
