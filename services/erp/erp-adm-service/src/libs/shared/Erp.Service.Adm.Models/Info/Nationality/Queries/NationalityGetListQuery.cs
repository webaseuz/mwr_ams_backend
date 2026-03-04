using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class NationalityGetListQuery : WbSortFilterPageOptions, IRequest<WbPagedResult<NationalityBriefDto>>
{
    public int StateId { get; set; }
}
