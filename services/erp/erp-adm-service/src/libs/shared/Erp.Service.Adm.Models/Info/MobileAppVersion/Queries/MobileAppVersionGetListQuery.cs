using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class MobileAppVersionGetListQuery : WbSortFilterPageOptions, IRequest<WbPagedResult<MobileAppVersionBriefDto>>
{
    public int StateId { get; set; }
}
