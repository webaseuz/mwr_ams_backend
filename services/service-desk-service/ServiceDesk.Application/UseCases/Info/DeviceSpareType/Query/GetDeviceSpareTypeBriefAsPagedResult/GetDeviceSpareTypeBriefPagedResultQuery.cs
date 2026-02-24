using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.DeviceSpareTypes;

public class GetDeviceSpareTypeBriefPagedResultQuery :
    SortFilterPageOptions,
    IRequest<PagedResultWithActionControls<DeviceSpareTypeBriefDto>>
{ }
