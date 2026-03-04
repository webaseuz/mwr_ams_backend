using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class TireSizeGetListQuery : WbSortFilterPageOptions, IRequest<WbPagedResult<TireSizeBriefDto>>
{
    public int StateId { get; set; }
}
