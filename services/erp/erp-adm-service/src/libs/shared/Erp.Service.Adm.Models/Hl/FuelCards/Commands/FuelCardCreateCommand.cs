using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class FuelCardCreateCommand : IRequest<WbHaveId<int>>
{
    public int? DriverId { get; set; }
    public int? BranchId { get; set; }
    public int? TransportId { get; set; }
    public int PlasticCardTypeId { get; set; }
    public string CardNumber { get; set; } = null!;
    public string ExpireAt { get; set; } = null!;
}
