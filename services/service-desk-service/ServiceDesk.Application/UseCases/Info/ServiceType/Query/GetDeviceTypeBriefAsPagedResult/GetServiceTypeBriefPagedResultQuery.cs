using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.ServiceTypes;

public class GetServiceTypeBriefPagedResultQuery :
    SortFilterPageOptions,
    IRequest<PagedResultWithActionControls<ServiceTypeBriefDto>>
{ }
