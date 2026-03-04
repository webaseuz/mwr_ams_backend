

namespace Erp.Service.Adm.Job.Application.Services.JobRunners;

public interface ICustomJobInputDataSource<TActionInputData>
{
    Task<CustomJobActionExecuteResult> Execute(TActionInputData item);
}
