using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Transports;

public class GetTransportSelectListQuery :
    IRequest<SelectList<int>>
{
    public int? BranchId { get; set; }
    public int? DriverId { get; set; }
    public bool? FromSetting { get; set; }
}
