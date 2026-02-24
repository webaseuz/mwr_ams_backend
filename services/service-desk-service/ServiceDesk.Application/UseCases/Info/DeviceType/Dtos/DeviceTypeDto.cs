namespace ServiceDesk.Application.UseCases.DeviceTypes;

public class DeviceTypeDto
{
    public int Id { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public string OrderCode { get; set; }
   // public int BaseDeviceTypeId { get; set; }
    //public string BaseDeviceTypeName { get; set; }
	public int StateId { get; set; }
    public string StateName { get; set; }

    public List<DeviceTypeTranslateDto> Translates { get; set; } = new();
}
