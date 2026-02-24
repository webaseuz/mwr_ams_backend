using Bms.WEBASE.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ServiceDesk.Application.Security;

namespace ServiceDesk.Application.UseCases.Report.SpareTurnover.Query.GetSpareTurnoverReportAsPagedResult;

public class GetSpareTurnoverReportBriefListQueryHandler :
        IRequestHandler<GetSpareTurnoverReportBriefListQuery, SpareTurnoverReportResponseDto<SpareTurnoverReportBriefListResponseDto>>
{
    private readonly IAsyncAppAuthService _authService;
    private readonly IReadEfCoreContext _context;

    public GetSpareTurnoverReportBriefListQueryHandler(
        IAsyncAppAuthService authService,
        IReadEfCoreContext context
        )
    {
        _authService = authService;
        _context = context;
    }

    public async Task<SpareTurnoverReportResponseDto<SpareTurnoverReportBriefListResponseDto>> Handle(
        GetSpareTurnoverReportBriefListQuery request,
        CancellationToken cancellationToken) 
    {
        if (request.PageSize.IsNullOrEmptyObject() || request.PageSize <= 0)
            request.PageSize = 20;

        if (request.Page.IsNullOrEmptyObject() || request.Page <= 0)
            request.Page = 1;

        if (!await _authService.HasPermissionAsync(PermissionCode.SpareTurnoverReportAllView))
            request.BranchId = (await _authService.GetUserAsync()).BranchId;

        var jsonWrapper = await _context.Results
            .FromSqlInterpolated($@"
            SELECT public.get_spare_turnover_report_json2(
                {request.BranchId},
                {request.DeviceTypeId},
                {request.PageSize ?? 10},
                {request.Page ?? 1},
                {request.Search},
                {request.SortBy},
                {request.OrderBy}
            ) AS Result")
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);

        //{request.FromDate ?? DateTime.Now},
        //{request.ToDate ?? DateTime.Now}

        if (jsonWrapper is null || string.IsNullOrWhiteSpace(jsonWrapper.Result))
        {
            return new SpareTurnoverReportResponseDto<SpareTurnoverReportBriefListResponseDto>
            {
                Page = request.Page.Value,
                PageSize = request.PageSize.Value,
                Total = 0,
                Items = new List<SpareTurnoverReportBriefListResponseDto>()
            };
        }

        var rawDto = JsonConvert.DeserializeObject<SpareTurnoverReportDto<SpareTurnoverReportBriefListDto>>(jsonWrapper.Result);

        var finalDto = new SpareTurnoverReportDto<SpareTurnoverReportBriefListDto>
        {
            Page = rawDto.Page,
            PageSize = rawDto.PageSize,
            Total = rawDto.Total,
            Items = rawDto.Items ?? new List<SpareTurnoverReportBriefListDto>()
        };

        var res = FromDto(finalDto);

        return res;
    }

    private SpareTurnoverReportResponseDto<SpareTurnoverReportBriefListResponseDto> FromDto(SpareTurnoverReportDto<SpareTurnoverReportBriefListDto> finalDto)
    {
        var res = new SpareTurnoverReportResponseDto<SpareTurnoverReportBriefListResponseDto>
        {
            Page = finalDto.Page,
            PageSize = finalDto.PageSize,
            Total = finalDto.Total,
            Items = new List<SpareTurnoverReportBriefListResponseDto>(),
        };

        foreach (var item in finalDto.Items)
        {
            var entity = new SpareTurnoverReportBriefListResponseDto()
            {
                FromDate = item.FromDate,
                BeginQuantity = item.BeginQuantity,
                EndDate = item.EndDate,
                EndQuantity = item.EndQuantity,
                DeviceSpareTypeId = item.DeviceSpareTypeId,
                DeviceSpareTypeName = item.DeviceSpareTypeName,
                Nomenclature = item.Nomenclature,
                BranchId = item.BranchId,
                BranchName = item.BranchName
            };

            res.Items.Add(entity);
        }
        return res;
    }
}



