using Bms.WEBASE.Extensions;
using Bms.WEBASE.Storage;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OfficeOpenXml;
using ServiceDesk.Application.Security;

namespace ServiceDesk.Application.UseCases.Report.SpareTurnover.Query.GetSpareTurnoverReportAsPagedResult;

public class ExportSpareTurnoverReportBriefListQueryHandler :
        IRequestHandler<ExportSpareTurnoverReportBriefListQuery, Stream>
{
    private readonly IAsyncAppAuthService _authService;
    private readonly IStorageAsyncService _storageService;
    private readonly IReadEfCoreContext _context;

    public ExportSpareTurnoverReportBriefListQueryHandler(
        IAsyncAppAuthService authService,
        IReadEfCoreContext context,
        IStorageAsyncService storageAsync
        )
    {
        _storageService = storageAsync;
        _authService = authService;
        _context = context;
    }

    public async Task<Stream> Handle(
        ExportSpareTurnoverReportBriefListQuery request,
        CancellationToken cancellationToken) 
    {
        #region Get Data
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
                {request.OrderBy},
                {request.FromDate ?? DateTime.Now},
                {request.ToDate ?? DateTime.Now}
            ) AS Result")
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);

        if (jsonWrapper is null || string.IsNullOrWhiteSpace(jsonWrapper.Result))
        {
            return null;
        }

        var rawDto = JsonConvert.DeserializeObject<SpareTurnoverReportDto<SpareTurnoverReportBriefListDto>>(jsonWrapper.Result);

        var finalDto = new SpareTurnoverReportDto<SpareTurnoverReportBriefListDto>
        {
            Page = rawDto.Page,
            PageSize = rawDto.PageSize,
            Total = rawDto.Total,
            Items = rawDto.Items ?? new List<SpareTurnoverReportBriefListDto>()
        };

        #endregion

        var data = finalDto.Items.ToArray();

        #region Excel part
        MemoryStream result = new MemoryStream();
        // For Win
        //MemoryStream template = _storageService.GetStaticFile(@"exceltemplates\SpareTurnover.xlsx");
        // For Lin
        MemoryStream template = _storageService.GetStaticFile(@"exceltemplates/SpareTurnover.xlsx");

        if (data != null)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage excelPackage = new ExcelPackage(template);

            #region FirstPart
            var tRow = excelPackage.Workbook.Names["TimeInterval"].Start.Row;
            var tCol = excelPackage.Workbook.Names["TimeInterval"].Start.Column;
            var bRow = excelPackage.Workbook.Names["CurrentBranch"].Start.Row;
            var bCol = excelPackage.Workbook.Names["CurrentBranch"].Start.Column;

            if(request.FromDate.HasValue && request.ToDate.HasValue)
                excelPackage.Workbook.Names["TimeInterval"].Worksheet.Cells[tRow, tCol].Value = 
                    $"{request.FromDate.Value.ToString("dd.MM.yyyy")} - {request.ToDate.Value.ToString("dd.MM.yyyy")}";

            if (request.BranchId.HasValue)
            {
                var branchName = await _context.Branches.FirstOrDefaultAsync(x => x.Id == request.BranchId.Value);
                excelPackage.Workbook.Names["CurrentBranch"].Worksheet.Cells[bRow, bCol].Value = $"{branchName}";

            }
            #endregion

            #region SecondPart
            var namerange = excelPackage.Workbook.Names["ImportRow"];

            var currentrow = namerange.Start.Row;
            var ws = namerange.Worksheet;
            int i = 1;
            if (ws != null)
            {
                foreach (var row in data)
                {
                    ws.InsertRow(currentrow, 1, namerange.Start.Row);
                    int index = 1;
                    ws.Cells[currentrow, index++].Value = i++;
                    ws.Cells[currentrow, index++].Value = row.BranchName;
                    ws.Cells[currentrow, index++].Value = row.DeviceSpareTypeName;
                    ws.Cells[currentrow, index++].Value = row.Nomenclature;
                    ws.Cells[currentrow, index++].Value = row.FromDate.Value.ToString("dd.MM.yyyy");
                    ws.Cells[currentrow, index++].Value = row.BeginQuantity;
                    ws.Cells[currentrow, index++].Value = row.EndDate.Value.ToString("dd.MM.yyyy");
                    ws.Cells[currentrow, index++].Value = row.EndQuantity;
                    currentrow++;
                }
            }
            #endregion
            result = new MemoryStream(excelPackage.GetAsByteArray());

            excelPackage.Dispose();
        }
        result.Position = 0;
        #endregion
        return result;
    }
}