using Erp.Core;

namespace Erp.Service.Adm.Job.Application.Services.JobRunners;

public interface IUpdatePersonDataJobRunner : ICustomJobRunner
{
}

public class UpdatePersonDataJobRunner
    : CustomJobRunner<
        UpdatePersonDataActionInputData,
        IUpdatePersonDataActionInputDataSource,
        IUpdatePersonDataActionExecutor>
    , IUpdatePersonDataJobRunner
{
    public UpdatePersonDataJobRunner(IServiceProvider serviceProvider)
        : base(serviceProvider)
    {
    }

    public override int JobTypeId => CustomJobTypeIdConst.UPDATE_PERSON_DATA;
}
