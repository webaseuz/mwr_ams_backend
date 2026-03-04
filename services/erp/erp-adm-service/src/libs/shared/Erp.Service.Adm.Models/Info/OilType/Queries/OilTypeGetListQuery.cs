using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class OilTypeGetListQuery : WbSortFilterPageOptions, IRequest<WbPagedResult<OilTypeBriefDto>>
{
    public int StateId { get; set; }
}
