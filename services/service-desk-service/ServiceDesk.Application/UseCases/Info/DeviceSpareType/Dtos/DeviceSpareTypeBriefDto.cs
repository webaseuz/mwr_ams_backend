namespace ServiceDesk.Application.UseCases.DeviceSpareTypes;

public class DeviceSpareTypeBriefDto
{
	public int Id { get; set; }
	public string ShortName { get; set; }
	public string FullName { get; set; }
	public string OrderCode { get; set; }
	public string Nomenclature { get; set; }
	public int DeviceTypeId { get; set; }
	public string DeviceTypeName { get; set; }
	public int DevicePartId { get; set; }
	public string DevicePartName { get; set; }
	public int DeviceModelId { get; set; }
	public string DeviceModelName { get; set; }
	public int StateId { get; set; }
	public string StateName { get; set; }
	public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }

	public bool CanModify { get; set; }
	public bool CanDelete { get; set; }
	public bool CanView { get; set; }
}
