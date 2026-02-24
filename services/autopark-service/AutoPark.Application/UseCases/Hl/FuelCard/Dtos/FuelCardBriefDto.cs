namespace AutoPark.Application.UseCases.FuelCards;

public class FuelCardBriefDto
{
    public int Id { get; set; }
    public int? DriverId { get; set; }
    public int? BranchId { get; set; }
    public int? TransportId { get; set; }
    public int PlasticCardTypeId { get; set; }
    public string CardNumber { get; set; } = null!;
    public string ExpireAt { get; set; }
    public int StateId { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    //public virtual Driver Driver { get; set; }
    public string DriverName { get; set; }
    public string PlasticCardTypeName { get; set; } = null!;
    public string StateName { get; set; } = null!;
    public string TransportStateNumber { get; set; }
    public string TransportModelName { get; set; }

    public bool CanModify { get; set; }
    public bool CanDelete { get; set; }
    public bool CanView { get; set; }
}
