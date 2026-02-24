using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Expenses;

public class GetExpenseBriefPageResultQuery :
    SortFilterPageOptions,
    IRequest<PagedResultWithActionControls<ExpenseBriefDto>>
{
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public int? BranchId { get; set; }
}
