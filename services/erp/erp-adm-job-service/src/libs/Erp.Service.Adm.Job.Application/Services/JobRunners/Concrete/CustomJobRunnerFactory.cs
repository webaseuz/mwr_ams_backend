using Erp.Core;
using Erp.Service.Adm.Job.Application.Services.JobRunners;
using Microsoft.Extensions.DependencyInjection;


namespace Erp.Service.Adm.Job.Application.Services.JobRunners;


public interface ICustomJobRunnerFactory
{
    ICustomJobRunner GetJobRunner(int jobTypeId);
}

public class CustomJobRunnerFactory : ICustomJobRunnerFactory
{
    private readonly IServiceProvider _serviceProvider;

    public CustomJobRunnerFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public ICustomJobRunner GetJobRunner(int jobTypeId)
    {
        switch (jobTypeId)
        {
            case CustomJobTypeIdConst.SYNC_USER_WITH_EMPLOYEE:
                return GetRequiredService<ISyncUserWithEmployeeJobRunner>();
            
            case CustomJobTypeIdConst.UPDATE_PERSON_DATA:
                return GetRequiredService<IUpdatePersonDataJobRunner>();
            
            default:
                throw new NotImplementedException($"CustomJobRunner for jobTypeId = {jobTypeId} not implemented");
        }
    }

    private TService GetRequiredService<TService>()
    {
        return _serviceProvider.GetRequiredService<TService>();
    }
}
