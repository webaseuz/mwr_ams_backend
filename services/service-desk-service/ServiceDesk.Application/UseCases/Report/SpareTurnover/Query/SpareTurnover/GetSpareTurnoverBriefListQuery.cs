using MediatR;

namespace ServiceDesk.Application.UseCases.Report.SpareTurnover.Query.SpareTurnoverBriefList;

public class GetSpareTurnoverBriefListQuery :
    IRequest<SpareTurnoverReportResponseDto<SpareTurnoverBriefListResponseDto>>
{
    public int BranchId { get; set; }
    public int DeviceSpareTypeId { get; set; }
    public bool IsDebit { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public int PageSize { get; set; }
    public int Page { get; set; }
    public string Search { get; set; }
    public string SortBy { get; set; }
    public string OrderBy { get; set; }
}
