
namespace ServiceDesk.Application.UseCases.ServiceApplications;

public class ServiceApplicationSpareDto
{
    public long Id { get; set; }
    public long OwnerId { get; set; }
    public int DeviceSpareTypeId { get; set; }
    public string DeviceSpareTypeName { get; set; }
    public string Nomenclature { get; set; } = null!;
    public int Quantity { get; set; }
}
