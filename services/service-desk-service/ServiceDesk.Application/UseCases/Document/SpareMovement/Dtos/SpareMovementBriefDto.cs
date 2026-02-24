using Bms.WEBASE.Helpers;
using Newtonsoft.Json;

namespace ServiceDesk.Application.UseCases.SpareMovements;

public class SpareMovementBriefDto
{
	public long Id { get; set; }
	public string DocNumber { get; set; } = null!;
    [JsonConverter(typeof(WbDateConverter))]
    public DateTime DocDate { get; set; }
	public int MovementTypeId { get; set; }
	public string MovementTypeName { get; set; }
	public int? FromBranchId { get; set; }
    public string FromBranchName { get; set; }
    public int? ToBranchId { get; set; }
    public string ToBranchName { get; set; }
    public int? FromUserId { get; set; }
    public string FromUserName { get; set; }
    public int? ToUserId { get; set; }
    public string ToUserName { get; set; }
    public int StatusId { get; set; }
	public string StatusName { get; set; }
	public DateTime CreatedAt { get; set; }

	#region Can
	public bool CanAccept { get; set; }
	public bool CanModify { get; set; }
	public bool CanDelete { get; set; }
	public bool CanCancel { get; set; }
	public bool CanSend { get; set; }
	public bool CanRevoke { get; set; }
	#endregion
}
