namespace ServiceDesk.Application.UseCases.Info.ApplicationPurposes;

public class ApplicationPurposeDto
{
    public int Id { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public string OrderCode { get; set; }
    public int DeviceTypeId { get; set; }
    public string DeviceTypeName { get; set; }
    public int StateId { get; set; }
    public string StateName { get; set; }
    public List<ApplicationPurposeTranslateDto> Translates { get; set; } = new();
}
