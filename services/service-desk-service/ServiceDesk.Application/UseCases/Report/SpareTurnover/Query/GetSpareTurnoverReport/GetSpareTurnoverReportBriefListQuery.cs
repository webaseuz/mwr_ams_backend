using MediatR;

namespace ServiceDesk.Application.UseCases.Report.SpareTurnover.Query.GetSpareTurnoverReportAsPagedResult;

public class GetSpareTurnoverReportBriefListQuery :
    IRequest<SpareTurnoverReportResponseDto<SpareTurnoverReportBriefListResponseDto>>
{
    public int? BranchId { get; set; }
    public int? PageSize { get; set; }
    public int? Page { get; set; }
    public int DeviceTypeId { get; set; }
    public string Search { get; set; }
    public string SortBy { get; set; }
    public string OrderBy { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
}
