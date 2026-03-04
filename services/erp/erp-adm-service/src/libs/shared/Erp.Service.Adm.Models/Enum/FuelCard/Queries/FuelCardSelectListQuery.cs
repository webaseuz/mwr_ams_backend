using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class FuelCardSelectListQuery : IRequest<WbSelectList<int>>
{
    public int? DriverId { get; set; }
    public int? TransportId { get; set; }
    public int? CardTypeId { get; set; }
    public int? BranchId { get; set; }
    public int? TransportSettingId { get; set; }
}