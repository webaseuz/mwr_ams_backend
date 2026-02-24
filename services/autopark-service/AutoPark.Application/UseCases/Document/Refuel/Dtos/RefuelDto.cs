using Bms.WEBASE.Helpers;
using Bms.WEBASE.Models;
using Newtonsoft.Json;

namespace AutoPark.Application.UseCases.Refuels;

public class RefuelDto :
    IHaveIdProp<long>
{
    public long Id { get; set; }
    public string DocNumber { get; set; } = null!;
    [JsonConverter(typeof(WbDateConverter))]
    public DateTime DocDate { get; set; }
    public int FuelCardId { get; set; }
    public string FuelCardNumber { get; set; }
    public int TransportId { get; set; }
    public string TransportName { get; set; }
    public int DriverId { get; set; }
    public string DriverName { get; set; }
    public int? BranchId { get; set; }
    public string BranchName { get; set; }
    public int FuelTypeId { get; set; }
    public string FuelTypeName { get; set; }
    public decimal Litre { get; set; }
    public decimal LitrePrice { get; set; }
    public decimal TotalPrice { get; set; }
    public string ChequeNumber { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string Message { get; set; }
    public int StatusId { get; set; }
    public string StatusName { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool CanCreateForAllBranch { get; set; }
    public decimal? Latitude { get; set; }
    public decimal? Longitude { get; set; }
    public List<RefuelFileDto> Files { get; set; } = new();
}
