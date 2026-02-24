
namespace ServiceDesk.Application.UseCases.Report.SpareTurnover;

public class SpareTurnoverReportResponseDto<TResult>
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int Total { get; set; }
    public List<TResult> Items { get; set; } = new();
}
