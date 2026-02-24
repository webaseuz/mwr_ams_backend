using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.DeviceSpareTypes;

public class GetDeviceSpareTypeSelectListQuery : IRequest<SelectList<int>>
{
    public bool FromTurnover { get; set; }
    public int BranchId { get; set; }
}
