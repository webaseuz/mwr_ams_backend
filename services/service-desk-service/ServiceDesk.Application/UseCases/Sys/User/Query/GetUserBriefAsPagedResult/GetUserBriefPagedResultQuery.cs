using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Users;

public class GetUserBriefPagedResultQuery :
    SortFilterPageOptions,
    IRequest<PagedResultWithActionControls<UserBriefDto>>
{ }
