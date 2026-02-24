using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Roles;

public class GetRoleBriefPagedResultQuery :
    SortFilterPageOptions,
    IRequest<PagedResultWithActionControls<RoleBriefDto>>
{
}
