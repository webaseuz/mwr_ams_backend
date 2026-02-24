using Bms.WEBASE.Helpers;
using Newtonsoft.Json;

namespace AutoPark.Application.UseCases.Refuels;

public class RefuelBriefDto
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
    public long PersonId { get; set; }

    #region Can
    public bool CanAccept { get; set; }
    public bool CanModify { get; set; }
    public bool CanDelete { get; set; }
    public bool CanCancel { get; set; }
    public bool CanSend { get; set; }
    public bool CanRevoke { get; set; }
    #endregion
}
