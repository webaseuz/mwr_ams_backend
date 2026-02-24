using Bms.WEBASE.Helpers;
using Newtonsoft.Json;

namespace AutoPark.Application.UseCases.Expenses;

public class ExpenseBriefDto
{
    public long Id { get; set; }
    public string DocNumber { get; set; } = null!;

    [JsonConverter(typeof(WbDateConverter))]
    public DateTime DocDate { get; set; }
    public int TransportId { get; set; }
    public string TransportInfo { get; set; }
    public int DriverId { get; set; }
    public string DriverName { get; set; }
    public int? BranchId { get; set; }
    public string BranchName { get; set; }
    public string Message { get; set; }
    public bool IsDeleted { get; set; }
    public int StatusId { get; set; }
    public string StatusName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
    #region Can
    public bool CanAccept { get; set; }
    public bool CanModify { get; set; }
    public bool CanDelete { get; set; }
    public bool CanCancel { get; set; }
    public bool CanSend { get; set; }
    public bool CanRevoke { get; set; }
    #endregion
}
