using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class UserGetListQuery : WbSortFilterPageOptions,
    IRequest<WbPagedResult<UserBriefDto>>
{
}
