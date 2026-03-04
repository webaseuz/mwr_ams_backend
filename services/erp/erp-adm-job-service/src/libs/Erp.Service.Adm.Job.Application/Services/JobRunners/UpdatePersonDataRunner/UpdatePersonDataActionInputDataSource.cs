using Erp.Core;
using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Job.Application.Services.JobRunners;

public interface IUpdatePersonDataActionInputDataSource
    : ICustomJobActionInputDataSource<UpdatePersonDataActionInputData>
{
}

public class UpdatePersonDataActionInputDataSource : IUpdatePersonDataActionInputDataSource
{
    private readonly IApplicationDbContext _dbContext;

    public UpdatePersonDataActionInputDataSource(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UpdatePersonDataActionInputData[]> GetSource(CustomJob entity)
    {
        var employeeQuery = _dbContext.Employees
            .Where(e =>
                e.Person != null &&
                !string.IsNullOrEmpty(e.Person.Pinfl) && e.StateId == WbStateIdConst.ACTIVE);

        var studentQuery = _dbContext.Students
            .Where(s =>
                s.Person != null &&
                !string.IsNullOrEmpty(s.Person.Pinfl) && s.StateId == WbStateIdConst.ACTIVE);

        if (entity.RegionId.HasValue && entity.RegionId > 0)
        {
            employeeQuery = employeeQuery.Where(e =>
                e.Organization != null &&
                e.Organization.RegionId == entity.RegionId.Value);

            studentQuery = studentQuery.Where(s =>
                s.Organization != null &&
                s.Organization.RegionId == entity.RegionId.Value);
        }

        if (entity.DistrictId.HasValue && entity.DistrictId > 0)
        {
            employeeQuery = employeeQuery.Where(e =>
                e.Organization != null &&
                e.Organization.DistrictId == entity.DistrictId.Value);

            studentQuery = studentQuery.Where(s =>
                s.Organization != null &&
                s.Organization.DistrictId == entity.DistrictId.Value);
        }

        if (entity.OrganizationId.HasValue && entity.OrganizationId > 0)
        {
            employeeQuery = employeeQuery.Where(e =>
                e.Organization != null &&
                e.OrganizationId == entity.OrganizationId.Value);

            studentQuery = studentQuery.Where(s =>
                s.Organization != null &&
                s.OrganizationId == entity.OrganizationId.Value);
        }


        //if (!entity.IsForceUpdate)
        //{
        //    employeeQuery = employeeQuery.Where(e =>
        //        !_dbContext.HrmDocumentFiles.Any(df =>
        //            df.DocumentId == e.PersonId &&
        //            df.TableId == TableIdConst.ADM_HL_PERSON &&
        //            !df.IsDeleted));

        //    studentQuery = studentQuery.Where(s =>
        //        !_dbContext.StdDocumentFiles.Any(df =>
        //            df.DocumentId == s.PersonId &&
        //            df.TableId == TableIdConst.ADM_HL_PERSON &&
        //            !df.IsDeleted));
        //}

        var employeeData = employeeQuery
            .Select(e => new UpdatePersonDataActionInputData
            {
                PersonId = e.PersonId,
                Pinfl = e.Person.Pinfl,
                PassportNumber = (e.Person.DocSeria ?? "") + (e.Person.DocNumber ?? ""),
                BirthDate = e.Person.BirthOn
            });

        var studentData = studentQuery
            .Select(s => new UpdatePersonDataActionInputData
            {
                PersonId = s.PersonId,
                Pinfl = s.Person.Pinfl,
                PassportNumber = (s.Person.DocSeria ?? "") + (s.Person.DocNumber ?? ""),
                BirthDate = s.Person.BirthOn
            });

        var result = await employeeData.Union(studentData).Distinct().ToArrayAsync();


        return result;
    }
}
