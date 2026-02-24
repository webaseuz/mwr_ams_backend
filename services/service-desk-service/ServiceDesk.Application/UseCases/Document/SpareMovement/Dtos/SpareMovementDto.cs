using Bms.WEBASE.Helpers;
using Bms.WEBASE.Models;
using Newtonsoft.Json;

namespace ServiceDesk.Application.UseCases.SpareMovements;

public class SpareMovementDto :
	IHaveIdProp<long>
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
    public bool CanCreateForAllBranch { get; set; }
    public List<SpareMovementTableDto> Tables { get; set; } = new();
}
