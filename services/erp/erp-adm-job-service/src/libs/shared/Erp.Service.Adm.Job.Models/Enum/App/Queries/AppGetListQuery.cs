using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;

public class AppGetListQuery : WbSortFilterPageOptions,
    IRequest<WbPagedResult<AppBriefDto>>
{
}
