namespace ServiceDesk.Application.UseCases.SpareMovements;

public class SpareMovementTableDto
{
	public long Id { get; set; }
	public long OwnerId { get; set; }
	public int DeviceSpareTypeId { get; set; }
	public string DeviceSpareTypeName { get; set; }
	public int Quantity { get; set; }
	public DateTime CreatedAt { get; set; }
	public int? CreatedBy { get; set; }
}
