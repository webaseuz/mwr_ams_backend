using Erp.Core.Service.Domain;

namespace Erp.Service.Adm.Job.Application.Services.JobRunners;

public interface ICustomJobActionExecuter<TActionInputData>
{
    Task<CustomJobActionExecuteResult> Execute(CustomJob job, TActionInputData actionInputData);
}
