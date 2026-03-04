using Erp.Core;


namespace Erp.Service.Adm.Job.Application.Services.JobRunners;

public interface ISyncUserWithEmployeeJobRunner : ICustomJobRunner
{
}

public class SyncUserWithEmployeeJobRunner
    : CustomJobRunner<SyncUserWithEmployeeJobRunnerActionInputData, ISyncUserWithEmployeeActionInputDataSource, ISyncUserWithEmployeeActionExecutor>
    , ISyncUserWithEmployeeJobRunner
{
    public SyncUserWithEmployeeJobRunner(IServiceProvider serviceProvider)
        : base(serviceProvider)
    {
    }

    public override int JobTypeId => CustomJobTypeIdConst.SYNC_USER_WITH_EMPLOYEE;
}
