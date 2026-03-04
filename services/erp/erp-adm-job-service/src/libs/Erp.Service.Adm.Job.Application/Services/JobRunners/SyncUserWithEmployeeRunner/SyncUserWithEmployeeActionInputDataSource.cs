using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Microsoft.EntityFrameworkCore;


namespace Erp.Service.Adm.Job.Application.Services.JobRunners;

public interface ISyncUserWithEmployeeActionInputDataSource : ICustomJobActionInputDataSource<SyncUserWithEmployeeJobRunnerActionInputData>
{
}

public class SyncUserWithEmployeeActionInputDataSource : ISyncUserWithEmployeeActionInputDataSource
{
    private readonly IApplicationDbContext _dbContext;

    public SyncUserWithEmployeeActionInputDataSource(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<SyncUserWithEmployeeJobRunnerActionInputData[]> GetSource(CustomJob entity)
    {
        return await _dbContext.EmployeeManages
            .Where(a => a.EndOn == null && a.IsDeleted == false)
            .Select(a => new SyncUserWithEmployeeJobRunnerActionInputData()
            {
                PersonId = a.Employee.PersonId
            })
            .Distinct()
            .ToArrayAsync();
    }
}
