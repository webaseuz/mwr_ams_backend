using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Drivers;

public class GetDriverSelectListQuery :
    IRequest<SelectList<int>>
{
    public int? BranchId { get; set; }
    public int? TransportId { get; set; }
    public long? TransportSettingId { get; set; }
}