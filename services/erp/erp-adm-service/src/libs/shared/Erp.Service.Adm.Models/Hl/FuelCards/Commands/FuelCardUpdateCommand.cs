using MediatR;

namespace Erp.Service.Adm.Models;

public class FuelCardUpdateCommand : IRequest<bool>
{
    public int Id { get; set; }
    public int? DriverId { get; set; }
    public int? BranchId { get; set; }
    public int? TransportId { get; set; }
    public int PlasticCardTypeId { get; set; }
    public string CardNumber { get; set; } = null!;
    public string ExpireAt { get; set; } = null!;
}
