namespace Erp.Service.Adm.Job.Application.Services.JobRunners;

public interface ICustomJobRunner
{
    Task Run(long jobId, string backgroundJobId = null);
}
