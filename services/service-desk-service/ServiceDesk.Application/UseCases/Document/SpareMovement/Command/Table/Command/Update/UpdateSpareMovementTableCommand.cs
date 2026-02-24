using Bms.WEBASE.Models;
using MediatR;
namespace ServiceDesk.Application.UseCases.SpareMovements;
public class UpdateSpareMovementTableCommand :
	IHaveIdProp<long>,
	IRequest<long>
{
	public long Id { get; set; }
	public long OwnerId { get; set; }
	public int DeviceSpareTypeId { get; set; }
	public int Quantity { get; set; }
}
