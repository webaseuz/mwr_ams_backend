using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class OilModelGetListQuery : WbSortFilterPageOptions, IRequest<WbPagedResult<OilModelBriefDto>>
{
    public int StateId { get; set; }
}
