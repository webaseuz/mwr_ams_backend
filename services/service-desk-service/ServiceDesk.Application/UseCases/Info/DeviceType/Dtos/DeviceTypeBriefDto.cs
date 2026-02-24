namespace ServiceDesk.Application.UseCases.DeviceTypes;

public class DeviceTypeBriefDto
{
	public int Id { get; set; }
	public string ShortName { get; set; }
	public string FullName { get; set; }
	public string OrderCode { get; set; }
	//public int BaseDeviceTypeId { get; set; }
	//public string BaseDeviceTypeName { get; set; }
	public int StateId { get; set; }
	public string StateName { get; set; }
	public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }

	public bool CanModify { get; set; }
	public bool CanDelete { get; set; }
	public bool CanView { get; set; }
}
