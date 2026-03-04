using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class BatteryTypeGetListQuery : WbSortFilterPageOptions, IRequest<WbPagedResult<BatteryTypeBriefDto>>
{
    public int StateId { get; set; }
}
