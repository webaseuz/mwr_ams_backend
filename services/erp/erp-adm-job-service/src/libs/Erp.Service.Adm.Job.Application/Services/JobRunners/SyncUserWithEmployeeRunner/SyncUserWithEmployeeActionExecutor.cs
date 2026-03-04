using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;
using Microsoft.EntityFrameworkCore;


namespace Erp.Service.Adm.Job.Application.Services.JobRunners;


public interface ISyncUserWithEmployeeActionExecutor : ICustomJobActionExecuter<SyncUserWithEmployeeJobRunnerActionInputData>
{
}

public class SyncUserWithEmployeeJobActionExecutor : ISyncUserWithEmployeeActionExecutor
{
    private readonly IApplicationDbContext _dbContext;

    public SyncUserWithEmployeeJobActionExecutor(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CustomJobActionExecuteResult> Execute(CustomJob job, SyncUserWithEmployeeJobRunnerActionInputData actionInputData)
    {
        var result = new CustomJobActionExecuteResult { };

        var anyEmpManage = await _dbContext.EmployeeManages
           .Include(a => a.Organization)
           .Where(x =>
               x.Employee.PersonId == actionInputData.PersonId &&
               !x.IsDeleted &&
               !x.EndOn.HasValue)
           .ToListAsync();

        var cmd = new SyncUserWithEmployeeCommand();

        cmd.UserEmployees.Add(new UserEmployeeDto
        {
            PersonId = actionInputData.PersonId,
            PhoneNumber = actionInputData.PhoneNumber,
            Assignments = anyEmpManage.Select(a => new UserEmployeeAssignmentDto
            {
                OrganizationId = a.OrganizationId,
                PositionId = a.PositionId,
                OrganizationTypeId = a.Organization.OrganizationTypeId,
                InstitutionTypeId = a.Organization.InstitutionTypeId
            }).ToList()
        });

        //var resId = await _userApi.SyncUserWithEmployeeAsync(cmd);

        return result;
    }
}
