using Bms.WEBASE.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ServiceDesk.Application.Security;

namespace ServiceDesk.Application.UseCases.Report.SpareTurnover.Query.SpareTurnoverBriefList;

public class GetSpareTurnoverBriefListQueryHandler :
    IRequestHandler<GetSpareTurnoverBriefListQuery, SpareTurnoverReportResponseDto<SpareTurnoverBriefListResponseDto>>
{
    private readonly IAsyncAppAuthService _authService;
    private readonly IReadEfCoreContext _context;

    public GetSpareTurnoverBriefListQueryHandler(
        IAsyncAppAuthService authService,
        IReadEfCoreContext context
        )
    {
        _authService = authService;
        _context = context;
    }

    public async Task<SpareTurnoverReportResponseDto<SpareTurnoverBriefListResponseDto>> Handle(
        GetSpareTurnoverBriefListQuery request,
        CancellationToken cancellationToken)
    {
        if (request.PageSize.IsNullOrEmptyObject() || request.PageSize <= 0)
            request.PageSize = 20;

        if (request.Page.IsNullOrEmptyObject() || request.Page <= 0)
            request.Page = 1;

        if (!await _authService.HasPermissionAsync(PermissionCode.SpareTurnoverReportAllView))
            request.BranchId = (await _authService.GetUserAsync()).BranchId.Value;

        var jsonWrapper = await _context.Results
            .FromSqlInterpolated($@"
            SELECT public.get_turnovers(
                {request.BranchId},
                {request.DeviceSpareTypeId},
                {request.IsDebit},
                {request.PageSize},
                {request.Page},
                {request.FromDate},
                {request.ToDate},
                {request.Search},
                {request.SortBy},
                {request.OrderBy}
            ) AS Result")
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);

        if (jsonWrapper is null || string.IsNullOrWhiteSpace(jsonWrapper.Result))
        {
            return new SpareTurnoverReportResponseDto<SpareTurnoverBriefListResponseDto>
            {
                Page = 1,
                PageSize = 20,
                Total = 0,
                Items = new List<SpareTurnoverBriefListResponseDto>()
            };
        }

        var rawDto = JsonConvert.DeserializeObject<SpareTurnoverReportDto<SpareTurnoverBriefListDto>>(jsonWrapper.Result);

        var finalDto = new SpareTurnoverReportDto<SpareTurnoverBriefListDto>
        {
            Page = rawDto.Page,
            PageSize = rawDto.PageSize,
            Total = rawDto.Total,
            Items = rawDto.Items
        };

        var res = FromDto(finalDto);

        return res;
    }

    private SpareTurnoverReportResponseDto<SpareTurnoverBriefListResponseDto> FromDto(SpareTurnoverReportDto<SpareTurnoverBriefListDto> finalDto)
    {
        var res = new SpareTurnoverReportResponseDto<SpareTurnoverBriefListResponseDto>
        {
            Page = finalDto.Page,
            PageSize = finalDto.PageSize,
            Total = finalDto.Total,
            Items = new List<SpareTurnoverBriefListResponseDto>(),
        };

        if (finalDto.Items == null)
            return res;

        foreach (var item in finalDto.Items)
        {
            var entity = new SpareTurnoverBriefListResponseDto()
            {
                BranchName = item.BranchName,
                Nomenclature = item.Nomenclature,
                DeviceSpareTypeName = item.DeviceSpareTypeName,
                Quantity = item.Quantity,
                IsDebit = item.IsDebit,
                CreatedAt = item.CreatedAt,
            };

            res.Items.Add(entity);
        }
        return res;
    }
}
