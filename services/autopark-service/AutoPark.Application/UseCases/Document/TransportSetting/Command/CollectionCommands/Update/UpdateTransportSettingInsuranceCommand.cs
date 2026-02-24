using Bms.WEBASE.Models;
using MediatR;
namespace AutoPark.Application.UseCases.TransportSettings;

public class UpdateTransportSettingInsuranceCommand :
    IHaveIdProp<long>,
    IRequest<IHaveId<long>>
{
    public long Id { get; set; }
    public long OwnerId { get; set; }
    public int InsuranceTypeId { get; set; }
    public string InsNumber { get; set; } = null!;
    public DateTime ExpireAt { get; set; }
    public long ContractorId { get; set; }
    public long ResponsiblePersonId { get; set; }
    public string Details { get; set; }
    public int NotifyBeforeDay { get; set; }
}
