using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class TireModelGetListQuery : WbSortFilterPageOptions, IRequest<WbPagedResult<TireModelBriefDto>>
{
    public int StateId { get; set; }
}
