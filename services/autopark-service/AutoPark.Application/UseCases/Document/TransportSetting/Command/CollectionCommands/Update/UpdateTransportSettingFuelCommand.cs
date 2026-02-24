using Bms.WEBASE.Models;
using MediatR;
namespace AutoPark.Application.UseCases.TransportSettings;

public class UpdateTransportSettingFuelCommand :
    IHaveIdProp<long>,
    IRequest<IHaveId<long>>
{
    public long Id { get; set; }
    public long OwnerId { get; set; }
    public int FuelTypeId { get; set; }
    //public decimal TankVolume { get; set; }
    public decimal MonthlyLimit { get; set; }
    public decimal Remaining { get; set; }
}
