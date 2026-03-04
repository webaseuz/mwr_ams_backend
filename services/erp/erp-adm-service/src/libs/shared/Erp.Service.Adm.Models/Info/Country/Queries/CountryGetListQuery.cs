using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class CountryGetListQuery : WbSortFilterPageOptions, IRequest<WbPagedResult<CountryBriefDto>>
{
    public int StateId { get; set; }
}
