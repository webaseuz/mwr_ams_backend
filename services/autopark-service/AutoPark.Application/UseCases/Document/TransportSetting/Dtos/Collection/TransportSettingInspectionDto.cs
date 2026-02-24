namespace AutoPark.Application.UseCases.TransportSettings;

public class TransportSettingInspectionDto
{
    public long Id { get; set; }
    public DateTime DateAt { get; set; }
    public DateTime ExpireAt { get; set; }
    public long ResponsiblePersonId { get; set; }
    public string ResponsiblePersonName { get; set; }
    public string Details { get; set; }
    public int NotifyBeforeDay { get; set; }
}
