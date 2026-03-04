using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class LiquidTypeGetListQuery : WbSortFilterPageOptions, IRequest<WbPagedResult<LiquidTypeBriefDto>>
{
    public int StateId { get; set; }
}
