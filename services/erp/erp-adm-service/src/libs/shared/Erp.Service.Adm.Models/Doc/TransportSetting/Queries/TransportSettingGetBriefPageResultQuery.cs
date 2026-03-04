using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class TransportSettingGetBriefPageResultQuery : WbSortFilterPageOptions,
    IRequest<WbPagedResult<TransportSettingBriefDto>>
{
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public int? BranchId { get; set; }
    public int? DriverId { get; set; }
}
