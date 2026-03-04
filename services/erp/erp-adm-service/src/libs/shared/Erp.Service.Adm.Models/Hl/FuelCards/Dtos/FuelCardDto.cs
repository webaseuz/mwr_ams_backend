namespace Erp.Service.Adm.Models;

public class FuelCardDto
{
    public int Id { get; set; }
    public int? DriverId { get; set; }
    public int? BranchId { get; set; }
    public int? TransportId { get; set; }
    public int PlasticCardTypeId { get; set; }
    public string CardNumber { get; set; } = null!;
    public string ExpireAt { get; set; } = string.Empty;
    public int StateId { get; set; }
    public string StateName { get; set; } = null!;
    public string DriverName { get; set; }
    public string PlasticCardTypeName { get; set; } = null!;
    public string TransportStateNumber { get; set; }
    public string TransportModelName { get; set; }
    public DateTime CreatedAt { get; set; }
}
