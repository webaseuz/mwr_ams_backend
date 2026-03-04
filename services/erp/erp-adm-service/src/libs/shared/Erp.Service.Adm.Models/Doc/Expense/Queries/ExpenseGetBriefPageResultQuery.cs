using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class ExpenseGetBriefPageResultQuery : WbSortFilterPageOptions,
    IRequest<WbPagedResult<ExpenseBriefDto>>
{
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public int? BranchId { get; set; }
}
