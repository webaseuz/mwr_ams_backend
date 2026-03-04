using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class CurrencyGetListQuery : WbSortFilterPageOptions, IRequest<WbPagedResult<CurrencyBriefDto>>
{
    public int StateId { get; set; }
}
