using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.MobileAppVersions;

public class GetMobileAppVersionBriefPagedResultQuery :
    SortFilterPageOptions,
    IRequest<PagedResultWithActionControls<MobileAppVersionBriefDto>>
{ }
