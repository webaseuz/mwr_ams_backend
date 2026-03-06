using AutoMapper;
using Erp.Core;
using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE;
using WEBASE.EntityFramework.Abstraction;
using WEBASE.i18n;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class DriverPenaltyGetListQueryHandler(
    IApplicationDbContext context,
    IMapper mapper,
    ICultureHelper cultureHelper,
    IMainAuthService authService) : IRequestHandler<DriverPenaltyGetListQuery, WbPagedResult<DriverPenaltyBriefDto>>
{
    public async Task<WbPagedResult<DriverPenaltyBriefDto>> Handle(DriverPenaltyGetListQuery request, CancellationToken cancellationToken)
    {
        var fromDate = request.ExpireFromDate ?? new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        var toDate = request.ExpireToDate ?? DateTime.Now;
        if (fromDate > toDate) (fromDate, toDate) = (toDate, fromDate);

        var domainQuery = context.DriverPenalties.AsQueryable();

        if (request.RegionId.HasValue)
            domainQuery = domainQuery.Where(dp => dp.Branch.RegionId == request.RegionId);

        if (request.BranchId.HasValue)
            domainQuery = domainQuery.Where(dp => dp.BranchId == request.BranchId);

        if (request.TransportId.HasValue)
            domainQuery = domainQuery.Where(dp => dp.TransportId == request.TransportId);

        if (request.DriverId.HasValue)
            domainQuery = domainQuery.Where(dp => dp.Person.Drivers.Any(d => d.Id == request.DriverId));

        if (!string.IsNullOrWhiteSpace(request.RegistrationNumber))
            domainQuery = domainQuery.Where(dp => dp.RegistrationNumber.Contains(request.RegistrationNumber));

        domainQuery = domainQuery.Where(dp => dp.CreatedAt >= fromDate && dp.CreatedAt <= toDate);

        if (!authService.HasPermission(AutoparkPermissionCode.DriverPenaltyAllView))
        {
            if (authService.HasPermission(AutoparkPermissionCode.DriverPenaltyBranchView))
                domainQuery = domainQuery.Where(dp => dp.BranchId == authService.User.BranchId);
            else if (authService.HasPermission(AutoparkPermissionCode.DriverPenaltyView))
                domainQuery = domainQuery.Where(dp => dp.PersonId == authService.User.PersonId);
        }

        var query = domainQuery.MapTo<DriverPenaltyBriefDto>(mapper, cultureHelper);

        if (request.HasSearch())
        {
            var target = request.Search!.ToLower();
            query = query.Where(dp => dp.FullName.ToLower().Contains(target) ||
                                      dp.TransportModelName.ToLower().Contains(target) ||
                                      dp.RegistrationNumber.ToLower().Contains(target) ||
                                      dp.MibCaseStatus.ToLower().Contains(target));
        }

        var result = await query.AsPagedResultAsync(request);

        var canPay = authService.HasPermission(AutoparkPermissionCode.DriverPenaltyPay);
        foreach (var dto in result.Rows)
            dto.CanPay = canPay;

        return result;
    }
}
